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
    public partial class Logaphones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            long pageMaximum = 2000;
            string[] consonants = {"p", "t", "k", "s", "m", "n", "l", "j", "w", ""};
            string[] vowels = {"a", "e", "i", "o", "u"};
            string[] finalconsonants = {"n", ""};
            string[] illegal = {"ji", "wu", "wo", "ti", "nm", "nn"};

            ArrayList syllables = new ArrayList();
            ArrayList syllablesSecond = new ArrayList();

            int count = 0;

            for (int i = 0; i < consonants.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    for (int k = 0; k < finalconsonants.Length; k++)
                    {
                        string word = consonants[i] + vowels[j] + finalconsonants[k];
                        bool isLegal = true;
                        for (int l = 0; l< illegal.Length; l++)
                        {
                            if (word.Contains(illegal[l]))
                            {
                                isLegal = false;
                            }
                        }
                        if (isLegal)
                        {
                            syllables.Add(word);
                            if (
                                !(word.StartsWith("a") || word.StartsWith("e") || word.StartsWith("i") ||
                                  word.StartsWith("o") || word.StartsWith("u")))
                            {
                                syllablesSecond.Add(word);
                            }
                            sb.Append(count + ": (1 syllable) : " + word + "<br/>");
                            if (count > pageMaximum)
                            {
                                OutText.Text = sb.ToString();
                                return;
                            }
                            
                            count++;
                        }
                    }
                }
            } // top for loop

            for (int i = 0; i < syllables.Count; i++)
            {
                for (int j = 0; j < syllablesSecond.Count; j++)
                {
                    string word = syllables[i].ToString() + syllablesSecond[j].ToString();
                    bool isLegal = true;
                    for (int l = 0; l < illegal.Length; l++)
                    {
                        if (word.Contains(illegal[l]))
                        {
                            isLegal = false;
                        }
                    }
                    if (isLegal)
                    {
                        sb.Append(count + " : (2 syllable) : " + word + "<br/>");
                        if (count > pageMaximum)
                        {
                            OutText.Text = sb.ToString();
                            return;
                        }
                        count++;
                    }
                }
            }

            for (int i = 0; i < syllables.Count; i++)
            {
                for (int j = 0; j < syllablesSecond.Count; j++)
                {
                    for (int k = 0; k < syllablesSecond.Count; k++)
                    {
                        string word = syllables[i].ToString() + syllablesSecond[j].ToString() +
                                      syllablesSecond[k].ToString();
                        bool isLegal = true;
                        for (int l = 0; l < illegal.Length; l++)
                        {
                            if (word.Contains(illegal[l]))
                            {
                                isLegal = false;
                            }
                        }
                        if (isLegal)
                        {
                            sb.Append(count + " : (3 syllable) : " + word + "<br/>");
                            if (count > pageMaximum)
                            {
                                OutText.Text = sb.ToString();
                                return;
                            }
                            count++;
                        }//if
                    }//for
                }//for
            }//for

            
        }
    }
}