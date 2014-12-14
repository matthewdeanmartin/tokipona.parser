using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Persist
{
    public class Snippet
    {
        public Guid SnippetId { get; set; }
        public Guid UserId { get; set; }
        public string Original { get; set; }
        public string[] Drafts { get; set; }
        public string DateTime { get; set; }
    }
}
