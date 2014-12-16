using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic;

namespace TokiPona
{
    public partial class CussWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            Load += Page_Load;
            this.BtnCuss.Click += new EventHandler(BtnCussClick);
            base.OnInit(e);
        }

        void BtnCussClick(object sender, EventArgs e)
        {
            WordGenerator rator = new WordGenerator();

            int rounds = 1000;
            Dictionary<string, int> words =new Dictionary<string, int>(rounds);

            for(int i = 1; i<rounds; i++)
            {
                string word = rator.ReturnAWord();
                if(word.Length==2) continue;
                if(words.ContainsKey(word))
                {
                    words[word]++;
                }
                else
                {
                    words.Add(word, 1);
                }
            }

            Dictionary<string, int> cusswords = new Dictionary<string, int>(rounds);

            for(int i =(rounds/10); i>2; i--)
            {
                if(words.ContainsValue(i))
                {
                    foreach (KeyValuePair<string, int> word in words)
                    {
                        if(word.Value==i)
                        {
                            cusswords.Add(word.Key, word.Value);
                        }
                    }
                }
                if(cusswords.Count>50)
                {
                    break;
                }
            }

            TxtOutput.Text = "";
            foreach (KeyValuePair<string, int> cuss in cusswords)
            {
                TxtOutput.Text += cuss.Key +", " + cuss.Value +"<br>";
            }
            //ArrayList list = new ArrayList();
            
                
            
        }
    }
}
