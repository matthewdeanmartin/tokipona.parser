using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;
using BasicTypes.Extensions;
using BasicTypes.Knowledge;
using BasicTypes.Parser;
using BasicTypes.Parts;
using NUnit.Framework;

namespace BasicTypes.Dictionary
{
    [TestFixture]
    public class ExtractNewLexemes
    {
        [Test]
        public void NewThings()
        {
            string[] samples =
                   new string[]
                {
                    CorpusTexts.ProfesorAndMadMan,
                CorpusTexts.UnpaText,
                CorpusTexts.Gilgamesh,
                CorpusTexts.SampleText1,
                CorpusTexts.SampleText3,
                CorpusTexts.Lao,
                CorpusTexts.GeorgeSong,
                    CorpusTexts.CrazyAnimal,
                    CorpusTexts.CrazyAnimal2
                    //,CorpusTexts.JanSin  //Too many neologisms to cope. 
                    ,CorpusTexts.RuneDanceSong
                    ,CorpusTexts.janPusaRice
                    ,CorpusTexts.janPend
                };

            foreach (string sample in samples)
            {
                //Split, normalize, tokenize, find words.
                TokenParserUtils tp = new TokenParserUtils();
                Dictionary<string, string> stuff = new Dictionary<string, string>();
                foreach (Token toke in tp.ValidTokens(sample).Distinct())
                {
                    if (toke.CheckIsCompoundWord(toke.Text))
                    {
                        if(!stuff.ContainsKey(toke.Text))
                            stuff.Add(toke.Text,"Compound");
                        
                    }
                    if (toke.Text.StartCheck("#") && toke.CheckIsNumber(toke.Text))
                    {
                        //Should just have to verify we can parse. No need for dictionary.
                        if (!stuff.ContainsKey(toke.Text))
                            stuff.Add(toke.Text, "Number");
                    }
                    if (toke.CheckIsProperModifier(toke.Text))
                    {
                        if (!stuff.ContainsKey(toke.Text))
                            stuff.Add(toke.Text, "Proper");
                    }
                    if (ForeignWord.IsForeign(toke.Text))
                    {
                        if (!stuff.ContainsKey(toke.Text))
                            stuff.Add(toke.Text, "Proper");
                    }

                    if (Neologism.IsNeologism(toke.Text))
                    {
                        if (!stuff.ContainsKey(toke.Text))
                            stuff.Add(toke.Text, "Neologism");
                    }
                }

                foreach (var t in stuff  )
                {
                    Console.WriteLine(t.Value + " " + t.Key);
                }
            }
        }
        
    }
}
