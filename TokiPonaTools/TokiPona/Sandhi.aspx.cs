using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class Sandhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = { "a","akesi","ala","alasa","ale","ali","anpa","ante","anu","awen","e","en","esun","ijo","ike","ilo","insa","jaki","jan","jelo","jo","kala","kalama","kama","kasi","ken","kepeken","kili","kin","kipisi","kiwen","ko","kon","kule","kulupu","kute","la","lape","laso","lawa","len","lete","li","lili","linja","lipu","loje","lon","luka","lukin","lupa","ma","mama","mani","meli","mi","mije","moku","moli","monsi","mu","mun","musi","mute","namako","nanpa","nasa","nasin","nena","ni","nimi","o","oko","olin","ona","open","pakala","pali","palisa","pan","pana","pi","pilin","pimeja","pini","pipi","poka","poki","pona","pu","sama","seli","selo","seme","sewi","sijelo","sike","sin","sina","sinpin","sitelen","sona","soweli","suli","suno","supa","suwi","tan","taso","tawa","telo","tenpo","toki","tomo","tu","unpa","uta","utala","walo","wan","waso","wawa","weka","wile" };
            ArrayList illegal = new ArrayList() { "ji", "wu", "wo", "ti", "nm", "nn" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            for (int i = 0; i < vowels.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    illegal.Add(vowels[i]+vowels[j]);
                }
            }

            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                        string wordPair = words[i] + words[j];
                        string wordPairWithSpace = words[i] + " " +words[j];
                        bool isLegal = true;
                        for (int l = 0; l < illegal.Count; l++)
                        {
                            if (wordPair.Contains(illegal[l].ToString()))
                            {
                                isLegal = false;
                            }
                        }
                        if (!isLegal)
                        {
                             sb.Append(count + ": " + wordPairWithSpace + "<br/>");
                            count++;
                        }//if
                    }//for
                }//for
            OutText.Text = sb.ToString();
            }//Page_Load 
            
        }
    }
