using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokiPonaApi.Formatters
{
    public class Html5Utils
    {
        public enum Html5Rels
        {
            alternate,//	Hyperlink	Hyperlink	Gives alternate representations of the current document.
            author,//	Hyperlink	Hyperlink	Gives a link to the author of the current document or article.
            bookmark,//	not allowed	Hyperlink	Gives the permalink for the nearest ancestor section.
            help,//	Hyperlink	Hyperlink	Provides a link to context-sensitive help.
            //icon,//	External Resource	not allowed	Imports an icon to represent the current document.
            license,//	Hyperlink	Hyperlink	Indicates that the main content of the current document is covered by the copyright license described by the referenced document.
            next,//	Hyperlink	Hyperlink	Indicates that the current document is a part of a series, and that the next document in the series is the referenced document.
            nofollow,//	not allowed	Annotation	Indicates that the current document's original author or publisher does not endorse the referenced document.
            noreferrer,//	not allowed	Annotation	Requires that the user agent not send an HTTP Referer (sic) header if the user follows the hyperlink.
            prefetch,//	External Resource	External Resource	Specifies that the target resource should be preemptively cached.
            prev,//	Hyperlink	Hyperlink	Indicates that the current document is a part of a series, and that the previous document in the series is the referenced document.
            search,//	Hyperlink	Hyperlink	Gives a link to a resource that can be used to search through the current document and its related pages.
            //stylesheet,//	External Resource	not allowed	Imports a stylesheet.
            tag//	not allowed	Hyperlink	Gives a tag (identified by the given address) that applies to the current document.
        }

        public enum Html4SeriesRels
        {
            Start,
            //Refers to the first document in a collection of documents. This link type tells search engines which document is considered by the author to be the starting point of the collection.
            Next,
            //Refers to the next document in a linear sequence of documents. User agents may choose to preload the "next" document, to reduce the perceived load time.
            Prev,
            //Refers to the previous document in an ordered series of documents. Some user agents also support the synonym "Previous".

            Alternate,
            //Designates substitute versions for the document in which the link occurs. When used together with the lang attribute, it implies a translated version of the document. When used together with the media attribute, it implies a version designed for a different medium (or media).
        }

        public enum Html4BookRels
        {
            Stylesheet,
            //Refers to an external style sheet. See the section on external style sheets for details. This is used together with the link type "Alternate" for user-selectable alternate style sheets.

            Contents,
            //Refers to a document serving as a table of contents. Some user agents also support the synonym ToC (from "Table of Contents").
            Index,
            //Refers to a document providing an index for the current document.
            Glossary,
            //Refers to a document providing a glossary of terms that pertain to the current document.
            Copyright,
            //Refers to a copyright statement for the current document.
            Chapter,
            //Refers to a document serving as a chapter in a collection of documents.
            Section,
            //Refers to a document serving as a section in a collection of documents.
            Subsection,
            //Refers to a document serving as a subsection in a collection of documents.
            Appendix,
            //Refers to a document serving as an appendix in a collection of documents.
            Help,
            //Refers to a document offering help (more information, links to other sources information, etc.)
            Bookmark
            //Refers to a bookmark. A bookmark is a link to a key entry point within an extended document. The title attribute may be used, for example, to label the bookmark. Note that several bookmarks may be defined in each document.    
        }

    }
}