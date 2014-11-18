using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Web.Http;
using TokiPonaApi.Controllers;
using TokiPonaApi.Filters;
using TokiPonaApi.Hal;

namespace TokiPonaApi.Controllers
{
    /// <summary>
    /// Proof of concepts to be transferred to FitTool, Mapping and UserProfile 
    /// </summary>
    public class ValuesV2Controller : BaseApiController
    {

        public ValuesV2Controller()
        {
            Version = "2";
        }
        //Domain model-- no WebAPI concepts here!
        public class DatedValueV2
        {
            public int Id { get; set; }
            public string Value { get; set; }
            public string FamilyValues { get; set; }
            public DateTime LastModified { get; set; } //This can't be DateTime.MinValue or you get f'd up caching logic.
        }

        //Simulated Repo
        private static readonly Dictionary<int, DatedValueV2> values = new Dictionary<int, DatedValueV2>
        {
            {0, new DatedValueV2 { Id=0, Value = "value1",FamilyValues = "Modern Kind" ,LastModified = DateTime.Now}},
            {1, new DatedValueV2 {Id=1,Value = "value2", FamilyValues = "Old Time" , LastModified = DateTime.Now}}
        };

        //HATEAOS pattern

        [DataContract]
        [KnownType(typeof(Hal.Link))]
        [KnownType(typeof(Hal.Link[]))]
        public class ValueViewModel:HalItemBase
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "value")]
            public string Value { get; set; }

            [DataMember(Name = "familyValues")]
            public string FamilyValues { get; set; }

            [DataMember(Name = "lastModified")]
            public DateTime LastModified { get; set; }
        }

        [DataContract (Name="Value")]
        [KnownType(typeof(Hal.Link))]
        [KnownType(typeof(Hal.Link[]))]
        public class ValueViewModelXml 
        {
            [DataMember(Name = "Id")]
            public int Id { get; set; }

            [DataMember(Name = "Value")]
            public string Value { get; set; }

            [DataMember(Name = "FamilyValues")]
            public string FamilyValues { get; set; }

            [DataMember(Name = "LastModified")]
            public DateTime LastModified { get; set; }
        }
      

        [DataContract]
        [KnownType(typeof(ValueViewModel))]
        [KnownType(typeof(Hal.Link))]
        [KnownType(typeof(Hal.Link[]))]
        public class ValueViewModelCollection:HalCollectionBase
        {
            [DataMember(Name = "lastModified")]
            public DateTime LastModified { get; set; }
        }


        private ValueViewModel ViewModelFactory(KeyValuePair<int, DatedValueV2> kvp)
        {
            //TODO: use automapper here.
            return new ValueViewModel
            {
                Links = SelfParentLinks(kvp.Key),
                Id=kvp.Value.Id,
                Value= kvp.Value.Value,
                FamilyValues = kvp.Value.FamilyValues,
                LastModified = kvp.Value.LastModified,
                EmbeddedValue = null
            };
        }


        [AcceptVerbs ("GET","HEAD")]
        [BasicAuthentication]
        public ValueViewModelCollection Get()
        {
            try
            {
                ValueViewModelCollection col = new ValueViewModelCollection();
                col.Links = new Dictionary<string, object>()
                {
                    {
                        "self", new Link() {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), null))}
                    },
                    {
                        "addValue", new Link() {Href = AddFormat(Url.Link(RouteName("ControllerOnly"), null))}
                    }
                };
                var items = (from KeyValuePair<int, DatedValueV2> s in values
                    select ViewModelFactory(s).LastModified).ToList();
                if (items.Any())
                {
                    col.LastModified = items.Max();
                }
                
                col.EmbeddedValue = new EmbeddedValues()
                {
                    Values = (from KeyValuePair<int, DatedValueV2> s in values
                              select ViewModelFactory(s)).ToArray()
                };
                return col;
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw;
            }
        }

        // GET api/values/5
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Instance is disposed elsewhere")]
        [AcceptVerbs("GET", "HEAD")]
        [BasicAuthentication]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                if (!values.ContainsKey(id))
                {
                    //Add extra message to distinguish from mere routing problems.
                    return Request.CreateResponse(HttpStatusCode.NotFound, "That id is not in the dictionary.");
                }
                DatedValueV2 value = values[id];

                //Cache stale or no IfModifiedSince date
                if (Request.Headers.IfModifiedSince == null || value.LastModified > Request.Headers.IfModifiedSince)
                {
                    ValueViewModel result = (from KeyValuePair<int, DatedValueV2> s in values
                                             where s.Key == id
                                             select ViewModelFactory(s)).First();
                    HttpResponseMessage m = Request.CreateResponse(HttpStatusCode.OK, result);
                    //DateTime d = DateTime.UtcNow;
                    //string dateInRFormat = value.LastModified.ToUniversalTime().ToString("r");
                    //
                    //m.Headers.ETag = new EntityTagHeaderValue(dateInRFormat);
                    m.Headers.CacheControl = new CacheControlHeaderValue()
                    {
                        NoCache = false,
                        Public = false,
                        Private = true,
                        MaxAge = new TimeSpan(24, 0, 0)
                    };
                    return m;
                }


                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw;
            }
        }

        //POST /TokiPonaApi/api/Values HTTP/1.1
        //Host: localhost
        //Content-Type: application/json
        //Cache-Control: no-cache
        //
        //"42"
        [BasicAuthentication]
        public HttpResponseMessage Post([FromBody]DatedValueV2 value) //Insert Value
        {
            try
            {
                //Simple types are harder to post than complex types!
                //http://weblog.west-wind.com/posts/2012/Mar/21/ASPNET-Web-API-and-Simple-Value-Parameters-from-POSTed-data
                if (value == null)
                {
                    throw new InvalidOperationException("Expected value in body, got " + Request.Content.ReadAsStringAsync().Result);
                }

                int id = (from int key in values.Keys
                    select key).Max() +1;
                DatedValueV2 justCreated = new DatedValueV2
                {
                    Id = values.Count,
                    Value = value.Value,
                    FamilyValues = value.FamilyValues,
                    LastModified = DateTime.Now
                };
                values.Add(values.Count, justCreated);

                //Return address to resource just created.

                return DefaultPostResponse(id, justCreated);
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw;
            }
        }

        

        // PUT api/values/5
        [BasicAuthentication]
        public HttpResponseMessage Put([FromBody]DatedValueV2 value)
        {
            try
            {
                //Update existing
                value.LastModified = DateTime.Now;
                value.FamilyValues = value.FamilyValues;
                values[value.Id] = value;

                //Tricky... this will *only* be called by jquery xhr!
                return DefaultPutResponse(value.Id, value);
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw;
            }
        }

        

        // DELETE api/values/5
        [BasicAuthentication]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (!values.ContainsKey(id))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                values.Remove(id);
                return DefaultDeleteResponse(id.ToString());
            }
            catch (Exception ex)
            {
                Tracing.Err.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw;
            }
        }


        [BasicAuthentication]
        public HttpResponseMessage Patch(int id, [FromBody] string value)
        {
            //Demo...
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}