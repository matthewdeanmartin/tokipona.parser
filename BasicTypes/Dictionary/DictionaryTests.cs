using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Dictionary
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void ExclamationsToday()
        {
            int count = 0;
            foreach (Word word in Words.Dictionary.Values)
            {
                var map = Words.Glosses[word.Text];
                
                var en = map["en"];
                //foreach (KeyValuePair<string, string[]> pair in en)
                {
                    //string pos = pair.Key;
                    //string[] possibilities = pair.Value;

                    if (en.ContainsKey("interj"))
                    {
                        count++;
                        Console.WriteLine(word);//+ " is interjection"
                    }
                }
            }
        }

        [Test]
        public void ThatLanuageDoesntHaveAWordFor()
        {
            int count = 0;
            foreach (Word word in Words.Dictionary.Values)
            {
                var map = Words.Glosses[word.Text];
                var eo = map["eo"];
                var en = map["en"];

                if (map["eo"].Count==0)
                {
                    count++;
                    Console.WriteLine("That's odd, eo has no word for " + word + "(AT ALL)");
                }

                if (map["en"].Count==0)
                {
                    count++;
                    Console.WriteLine("That's odd, en has no word for " + word + "(AT ALL)");
                }

                
                foreach (KeyValuePair<string, string[]> pair in en)
                {
                    string pos = pair.Key;
                    string[] possibilities = pair.Value;

                    if (!eo.ContainsKey(pos) || (eo[pos].Length == 0 && possibilities.Length>0))
                    {
                        count++;
                        Console.WriteLine("That's odd, eo has no word for " + word + "(" + pos + "), en does");
                    }

                    if (!en.ContainsKey(pos) || (en[pos].Length == 0 && possibilities.Length > 0))
                    {
                        count++;
                        Console.WriteLine("That's odd, en has no word for " + word + "(" + pos + "), eo does");
                    }
                }
            }
            Assert.AreEqual(0,count,"Found dictionary oddities");
        }
    }
}
