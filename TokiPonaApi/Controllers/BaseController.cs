
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Http;
using AutoMapper;
using TokiPonaApi.Hal;

namespace TokiPonaApi.Controllers
{
    public static class PropertyInfoExtensions
    {
        public static bool IsNullableType(this Type obj)
        {
            if (Nullable.GetUnderlyingType(obj) != null)
            {
                // It's nullable
                return true;
            }
            return false;
        }
    }

    public class BaseApiController : ApiController
    {
        protected void LogErrorMessage(Exception ex)
        {
            HttpResponseException rex = ex as HttpResponseException;

            string content = "";
            if (rex != null)
            {
                if (rex.Response != null)
                {
                    if (rex.Response.Content != null)
                    {
                        content = rex.Response.Content.ReadAsStringAsync().Result ?? "null";
                    }
                    content += "Status code:" + rex.Response.StatusCode;
                }
            }
            Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString() + content);
        }

        protected string Version { get; set; }

        protected bool ViewModelHasAllNullableProperties(Type t)
        {
            List<string> invalidProps = null;
            foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.PropertyType.IsNullableType() && prop.PropertyType.IsValueType)
                {
                    continue;
                }

                if (!prop.PropertyType.IsValueType)
                {
                    continue;
                }

                if (invalidProps == null)
                {
                    invalidProps = new List<string>();
                }
                invalidProps.Add(prop.Name);
            }
            if (invalidProps == null)
            {
                return true;
            }
            throw new InvalidOperationException("These aren't nullable-- can't do merge/PATCH logic: " + string.Join(",", invalidProps.ToArray()));
        }

        protected T ApplyPatch<T>(T completeObject, T patch)
        {
            if (!ViewModelHasAllNullableProperties(typeof(T)))
            {
                throw new InvalidOperationException("This type has non-nullable properties, can't be used in PATCH scenarios because I can't tell the difference between a default value and a value that hasn't been set.");
            }
            //Elsewhere....
            //Mapper.CreateMap<FitToolViewModel, FitToolViewModel>()
            //    .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));

            
            Mapper.Map(patch, completeObject);
            return completeObject;
        }

        protected static void ValidatePutWithGuidId<T>(Guid id, T viewModel) where T : class
        {
            if (id == null)
            {
                throw new ArgumentException("id is missing from the URL, it is null");
            }
            if (viewModel == null)
            {
                throw new ArgumentException("viewModel is missing from the body (or failed to deserialize)-- it is null. Check to see if content type is set, for example Content-Type: application/json");
            }
            if (id == new Guid())
            {
                throw new ArgumentException("id is missing from the URL, it is all zeros");
            }
        }

        private bool EnableAllTransactions()
        {
            return ConfigurationManager.AppSettings["enableAllTransactions"] == "true";
        }

        private bool RestrictDiagnosticsToLocal()
        {
            return ConfigurationManager.AppSettings["diagnosticsModeIsLocalOnly"] == "true";
        }

        internal void AssertSafeToUseDiagnosticsPage()
        {
            //Must be authenticated.
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                throw new HttpException(404, "Page not found");
            }
            //All transactions enabled (mostly affects DELETE and GET(all) and POST (new user)
            if (!EnableAllTransactions())
            {
                throw new HttpException(404, "Page not found");
            }
            //Some things we might want to diagnose, but not if it is on the open internet.
            if (RestrictDiagnosticsToLocal() && !Request.IsLocal())
            {
                throw new HttpException(404, "Page not found");
            }
        }

        protected bool IncludeHalExtensions()
        {
            if (!Request.GetQueryStrings().ContainsKey("rootOnly")) return true;

            return Request.GetQueryStrings()["rootOnly"] != "true";
        }

        protected TraceSource Err = new TraceSource("err");

        protected HttpResponseMessage DefaultGet<T>(T message)
        {
            HttpResponseMessage rm = Request.CreateResponse(HttpStatusCode.OK, message);
            return rm;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Instance is disposed elsewhere")]
        protected HttpResponseMessage ReturnLatestOrNotModified<T>(DateTime? lastModified, T message)
        {
            //Content can vary if modified (diff last mod date), diff media type, diff request style, e.g. root/bare/etc.
            string etagString = "\"" +
                lastModified +
                String.Join(",", Request.Headers.Accept).Replace("\"", "-") +
                Request.GetUrlHelper().Request.RequestUri.Query + "\"";

            HttpHeaderValueCollection<EntityTagHeaderValue> etags = Request.Headers.IfNoneMatch;
            bool etagsDiffer = false;
            if (etags.Count == 1)
            {
                if (etagString != etags.First().Tag)
                {
                    etagsDiffer = true;
                }
            }
            else if (etags.Count > 1)
            {
                throw new InvalidOperationException("Found more than 1 etag. This API doesn't know what to do with that.");
            }

            bool clientIsStale = ClientIsStale(lastModified) || etagsDiffer;
            if (!clientIsStale)
                return new HttpResponseMessage(HttpStatusCode.NotModified);

            HttpResponseMessage rm = Request.CreateResponse(HttpStatusCode.OK, message);

            rm.Headers.CacheControl = new CacheControlHeaderValue
            {
                NoCache = false,
                Public = false,
                Private = true,
                MaxAge = new TimeSpan(24, 0, 0)
            };
            rm.Headers.ETag = new EntityTagHeaderValue(etagString);
            rm.Content.Headers.LastModified = (lastModified ?? DateTime.MinValue);
            return rm;
        }

        protected bool ClientIsStale(DateTime? lastModified)
        {
            bool clientIsStale = false;

            //Cache stale or no IfModifiedSince date
            int seconds = 0;
            if (lastModified.HasValue && Request.Headers.IfModifiedSince.HasValue)
            {
                TimeSpan span = lastModified.Value - Request.Headers.IfModifiedSince.Value;
                seconds = span.Seconds;
                Debug.Write("It's been " + seconds + " seconds");
            }

            if (Request.Headers.IfModifiedSince == null || Math.Abs(seconds) > 1)
            {
                clientIsStale = true;
            }
            return clientIsStale;
        }



        protected Dictionary<string, object> SelfParentLinks(object key, string controller)
        {
            return new Dictionary<string, object>
            {
                {
                    "parent", new Link {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), new {controller}))}
                },
                {"self", new Link {Href = AddFormat(Url.Link(RouteName(), new {controller, id = key, version=Version}))}},
                {
                    "_curies", new[]
                    {
                        new Link
                        {
                            Href = Url.Link("DefaultApi", new {controller = "HelpRelations"}) + "?rel={0}",
                            Templated = true
                        }
                    }
                }
            };
        }

        protected string RouteName(string regularName = null)
        {
            if (regularName == null)
            {
                return Version == null ? "DefaultApi" : "VersionedApi";
            }
            return Version == null ? regularName : "Versioned" + regularName;
        }

        protected Dictionary<string, object> SelfParentLinksMappingTool(Guid id, Guid userId)
        {
            return new Dictionary<string, object>
            {
                {
                    "parent", new Link {Href = AddFormat(Url.Link("DefaultApi", new { controller="User", id = userId}))}
                },
                {"self", new Link {Href = AddFormat(Url.Link(RouteName(), new {id, version=Version}))}},
                {
                    "_curies", new[]
                    {
                        new Link
                        {
                            Href = Url.Link("DefaultApi", new {controller = "HelpRelations"}) + "?rel={0}",
                            Templated = true
                        }
                    }
                }
            };
        }

        protected Dictionary<string, object> SelfParentLinks(object key)
        {
            return new Dictionary<string, object>
            {
                {
                    "parent", new Link {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), null))}
                },
                {"self", new Link {Href = AddFormat(Url.Link(RouteName(), new {id = key}))}},
                {
                    "_curies", new[]
                    {
                        new Link
                        {
                            Href = Url.Link("DefaultApi", new {controller = "HelpRelations"}) + "?rel={0}",
                            Templated = true
                        }
                    }
                }
            };
        }

        protected Dictionary<string, object> SelfAddLinks()
        {
            return new Dictionary<string, object>
           {
                    {
                        "self", new Link {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), null))}
                    },
                    {
                        "addValue", new Link {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), null))}
                    }
                };
        }


        protected string AddFormat(string url)
        {
            Uri current = new Uri(url);
            var qs = Request.RequestUri.ParseQueryString();
            string format = qs["format"];
            if (format == null) return url;
            if (current.Query.Length > 0)
            {
                return url + "&format=" + format;
            }
            return url + "?format=" + format;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Instance is disposed elsewhere")]
        protected HttpResponseMessage DefaultPostResponse<T>(object key, T value)
        {
            //See other suggest to client that it should (optionally) go the new link to see what the resource looks like now

            HttpResponseMessage response;
            if (Request.Headers.UserAgent.Any() && Request.Headers.UserAgent.First().Product.Name.Contains("HttpClient"))
            {
                //HTTP Client tries to follow redirects w/o resigning.
                //Created doesn't do anything intuitive for a browser.
                response = Request.CreateResponse(HttpStatusCode.Created, value);
            }
            else
            {
                //Created doesn't do anything intuitive for a browser.
                //See other encourages redirect behavior, which works but not for signed messages.
                response = Request.CreateResponse(HttpStatusCode.SeeOther, value);
            }

            string uri = Url.Link(RouteName(), new { id = key.ToString(), version = Version });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Instance is disposed elsewhere")]
        protected HttpResponseMessage DefaultPutResponse<T>(object objectId, T value)
        {
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NoContent);//Doesn't do anything interesting.

            //This allows the client to navigate to the new item.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, value);
            string uri = Url.Link(RouteName(), new { id = objectId, version = Version });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Instance is disposed elsewhere")]
        protected HttpResponseMessage DefaultDeleteResponse(string id)
        {
            HttpResponseMessage deletedResponse = Request.CreateResponse(HttpStatusCode.OK);
            deletedResponse.Content = new StringContent("The resource " + id + " has been deleted");
            return deletedResponse;
        }

        //Not necessarily honest
        protected HttpResponseMessage DefaultOptionsOnParameterless()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            //resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS");
            //resp.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,PATCH,HEAD");
            return resp;
        }

        //Not necessarily honest
        protected HttpResponseMessage DefaultOptionsOnKeyedRequest()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            //resp.Headers.Add("Access-Control-Allow-Origin", "*");

            resp.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,PATCH,HEAD,DELETE,OPTIONS");

            //resp.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,PATCH,HEAD");

            return resp;
        }
    }
}
