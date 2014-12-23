using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class TransliteratePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnInit(EventArgs e)
        {
            Load += Page_Load;
            DoTransliteration.Command += TransliterateCommand;
            base.OnInit(e);
        }

        void TransliterateCommand(object sender, CommandEventArgs e)
        {
            string input = HttpUtility.HtmlEncode(ToTransliterate.Text);
            TransliterateEngine transliterator = new TransliterateEngine();
            string trace;
            List<string> list = new List<string>();

            StringBuilder sb = new StringBuilder();
            sb.Append("<br/>");
            sb.Append("<b>Default Options:  </b>");
            string result = transliterator.Transliterate(input, out trace, TransliterateEngine.DefaultOptions());
            list.Add(result);
            sb.Append(result);
            sb.Append("<br/>");

            if(input.Contains("r")||input.Contains("R"))
            {

                Options r = TransliterateEngine.DefaultOptions();
                r.RLanguage = LanguageForR.FrenchGerman;
                result = transliterator.Transliterate(input, out trace,r);
                
                if(!list.Contains(result))
                {
                    sb.Append("<b>French German R:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }
                
                
                r.RLanguage = LanguageForR.TrilledTapped;
                result = transliterator.Transliterate(input, out trace, r);
                if(!list.Contains(result))
                {
                    sb.Append("<b>Trilled Tapped R:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }
                
            }

            Options vowels = TransliterateEngine.DefaultOptions();
            vowels.VowelCluster = ClusterPreference.Split;
            result = transliterator.Transliterate(input, out trace, vowels);
            if (!list.Contains(result))
            {
                sb.Append("<b>Split vowels:  </b>");
                sb.Append(result);
                sb.Append("<br/>");
                list.Add(result);
            }


            if (input.Contains("r") || input.Contains("R"))
            {

                Options r = TransliterateEngine.DefaultOptions();
                r.RLanguage = LanguageForR.FrenchGerman;
                r.VowelCluster = ClusterPreference.Split;
                result = transliterator.Transliterate(input, out trace, r);

                if (!list.Contains(result))
                {
                    sb.Append("<b>French German R, split vowels:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }


                r.RLanguage = LanguageForR.TrilledTapped;
                r.VowelCluster = ClusterPreference.Split;
                result = transliterator.Transliterate(input, out trace, r);

                if (!list.Contains(result))
                {
                    sb.Append("<b>Trilled Tapped R, split vowels:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }

            }

          

            
            Options consontants = TransliterateEngine.DefaultOptions();
            consontants.ConsonantCluster = ClusterPreference.Split;
            result = transliterator.Transliterate(input, out trace, consontants);
            if(!list.Contains(result))
            {
                sb.Append("<b>Split consonants: </b> ");
                sb.Append(result);
                sb.Append("<br/>");
                list.Add(result);
            }


            if (input.Contains("r") || input.Contains("R"))
            {

                Options r = TransliterateEngine.DefaultOptions();
                r.RLanguage = LanguageForR.FrenchGerman;
                r.ConsonantCluster = ClusterPreference.Split;
                result = transliterator.Transliterate(input, out trace, r);

                if (!list.Contains(result))
                {
                    sb.Append("<b>French German R, split consonants:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }


                r.RLanguage = LanguageForR.TrilledTapped;
                r.ConsonantCluster = ClusterPreference.Split;
                result = transliterator.Transliterate(input, out trace, r);

                if (!list.Contains(result))
                {
                    sb.Append("<b>Trilled Tapped R, split consonants:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }

            }


            if(input.ToLower().Contains("th"))
            {
                consontants.SorT = "s";
                result = transliterator.Transliterate(input, out trace, consontants);
                if (!list.Contains(result))
                {
                    sb.Append("<b>Prefer s for th:  </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }


                consontants.SorT = "t";
                result = transliterator.Transliterate(input, out trace, consontants);
                if (!list.Contains(result))
                {
                    sb.Append("<b>Prefer t for th: </b>");
                    sb.Append(result);
                    sb.Append("<br/>");
                    list.Add(result);
                }
            }
            
            TokiPonaOutput.Text =sb.ToString() ;
        }
    }
}
