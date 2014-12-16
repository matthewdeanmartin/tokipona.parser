using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class LoremIpsumGenerator
    {
        private readonly Random r;
        private readonly Lexicon lexicon;
        private List<string> nounsRandom;
        private List<string> modifiersRandom;
        private List<string> verbsTransitiveRandom;
        private List<string> verbsIntranitiveRandom;
        private List<string> adverbsRandom;
        private List<string> modalsRandom;
        private List<string> prepPhrases;

        public LoremIpsumGenerator(int seed)
        {
            lexicon = new Lexicon();
            r = new Random(seed);
            
            nounsRandom = new List<string>(lexicon.nouns.Count);
            nounsRandom.AddRange(lexicon.nouns.Keys);

            modifiersRandom = new List<string>(lexicon.modifers.Count);
            modifiersRandom.AddRange(lexicon.modifers.Keys);

            verbsTransitiveRandom = new List<string>(lexicon.transitiveVerbs.Count);
            verbsTransitiveRandom.AddRange(lexicon.transitiveVerbs.Keys);

            verbsIntranitiveRandom = new List<string>(lexicon.intransitiveVerbs.Count);
            verbsIntranitiveRandom.AddRange(lexicon.intransitiveVerbs.Keys);

            //adverbsRandom = new List<string>(lexicon.adverbs.Count);
            //adverbsRandom.AddRange(lexicon.adverbs.Keys);

            modalsRandom = new List<string>(lexicon.modals.Count);
            modalsRandom.AddRange(lexicon.modals.Keys);

            prepPhrases = new List<string>(lexicon.prepPhrases.Count);
            prepPhrases.AddRange(lexicon.prepPhrases.Keys);
        }

        public string Generate(long sentences)
        {
            StringBuilder sb = new StringBuilder();
            long sentenceCount=0;
            long paracount = 0;
            
            
            while(sentenceCount<sentences)
            {
                if(paracount==0)
                {
                    sb.Append("<p>");
                }

                //Fragments
                double time = r.NextDouble();
                if (time < .05)
                {
                    sb.Append("tenpo pini la ");
                }
                else if(time<.10)
                {
                    sb.Append("tenpo lili la ");
                }
                else if (time < .15)
                {
                    sb.Append("tenpo kama la ");
                }
                else if (time < .17)
                {
                    sb.Append("tenpo suno ni la ");
                }
                else if (time < .18)
                {
                    sb.Append("tenpo pimeja la ");
                }
                else if (time < .19)
                {
                    sb.Append("tenpo ni la ");
                }

                if(r.NextDouble()<.25)
                {
                    FullSentence(sb);
                    sb.Append(" la ");
                }
                
                FullSentence(sb);
                //Todo: S li (M) PP (E) PP

                if (sb[sb.Length - 1] == ' ')
                    sb.Remove(sb.Length - 1, 1);
                sb.Append(".  ");
                sentenceCount++;
                paracount++;
                if(paracount==4)
                {
                    sb.Append("</p>");
                    paracount = 0;
                }
            }

            return sb.ToString().Replace("  ", " ").Replace("  ", " ").Replace(" .",".").Trim();
        }

        private void FullSentence(StringBuilder sb)
        {
            RandomNounPhrase(sb);
            if (sb[sb.Length-1] == ' ')
                sb.Remove(sb.Length-1, 1);

            //Predicate
            double sentenceType = r.NextDouble();
            if(sentenceType<.25)
            {
                sb.Append(" li ");
                RandomNounPhrase(sb);
                //TODO: can also be single modifier.
                if (sb[sb.Length - 1] == ' ')
                    sb.Remove(sb.Length - 1, 1);
            }
            else if(sentenceType<.35)
            {
                sb.Append(" li ");
                RandomPrepPhrases(sb);
                if (sb[sb.Length - 1] == ' ')
                    sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                //Li chain with vt and vi
                RandomVerbPhrase(sb);
            }
        }

        public void RandomVerbPhrase(StringBuilder sb)
        {
            int liChains = r.Next(1, 3);//1 or 2
            
            for (int i = 0; i < liChains; i++)
            {
                sb.Append(" li ");
                //Modals
                int modalCount = r.Next(0, 2);
                string modalsString="";
                for(int k=0;k<modalCount;k++)
                {
                    int n = r.Next(0, modalsRandom.Count - 1);
                    string modalWord = modalsRandom[n].Trim();
                    if(!modalsString.Contains(modalWord))
                        modalsString = modalsString + " " + modalWord;
                }
                sb.Append(modalsString);
                sb.Append(" ");
                
                //Core Verb
                if(r.NextDouble()<.75)
                {
                    int n = r.Next(0, verbsTransitiveRandom.Count - 1);
                    sb.Append(verbsTransitiveRandom[n].Trim());
                    //Adverb

                    int echains = r.Next(1, 3);//1 or 2
                    for (int e = 0; e < echains;e++)
                    {
                        sb.Append(" e ");
                        RandomNounPhrase(sb);
                    }
                }
                else
                {
                    int n = r.Next(0, verbsIntranitiveRandom.Count - 1);
                    sb.Append(verbsIntranitiveRandom[n].Trim());
                    //Adverb
                }
                
                RandomPrepPhrases(sb);

                ////how many modifiers?
                //int modifiers = 0;
                //if (i >= 1 && i <= liChains - 1)
                //{
                //    modifiers = r.Next(0, 2);
                //}
                //else
                //{
                //    modifiers = r.Next(2, 3);
                //}
                //for (int j = 1; j < modifiers; j++)
                //{
                //    int m = r.Next(0, modifiersRandom.Count - 1);
                //    sb.Append(nounsRandom[m].Trim());
                //    sb.Append(" ");
                //}
                
            }
        }

        public void RandomPrepPhrases(StringBuilder sb)
        {
            int phrases = r.Next(0, 3);//0,1,2

            sb.Append(" ");
            for (int i =0; i < phrases;i++ )
            {
                int n = r.Next(0,prepPhrases.Count-1);
                sb.Append(prepPhrases[n].Trim());
                sb.Append(" ");
                RandomNounPhrase(sb);
                sb.Append(" ");
            }
        }

        public void RandomNounPhrase(StringBuilder sb)
        {
            int piChains = r.Next(1, 3);//1 or 2
            
            for (int i =0; i < piChains;i++ )
            {
                int n = r.Next(0, nounsRandom.Count-1);
                sb.Append(nounsRandom[n].Trim());
                sb.Append(" ");

                //how many modifiers?
                int modifiers = 0;
                if(i<piChains-1 || piChains==1)
                {
                     modifiers = r.Next(0, 2);//0 or 1
                }
                else
                {
                    modifiers = r.Next(2, 3);//
                }
                for (int j = 1; j <= modifiers; j++)
                {
                    int m = r.Next(0, modifiersRandom.Count-1);
                    sb.Append(modifiersRandom[m].Trim());
                    sb.Append(" ");
                }
                sb.Append("pi ");
            }

            sb.Remove(sb.Length - 3, 3);
        }
    }
}
