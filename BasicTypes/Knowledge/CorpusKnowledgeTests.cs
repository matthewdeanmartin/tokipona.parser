using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Knowledge;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class CorpusKnowledgeTests
    {
        [Test]
        public void ArrayExtensionsTest()
        {
            string[] oneTwo = new string[] { "one", "two" };
            string[] tail = ArrayExtensions.Tail(oneTwo);
            Assert.AreEqual(1, tail.Length);
            Assert.AreEqual("two", tail[0]);
        }

        [Test]
        public void ArrayExtensionsTest2()
        {
            string[] oneTwoThree = new string[] { "one", "two", "three" };
            string[] tail = ArrayExtensions.Tail(oneTwoThree);
            Assert.AreEqual(2, tail.Length);
            Assert.AreEqual("two", tail[0]);
            Assert.AreEqual("three", tail[1]);
        }


        [Test]
        public void ParseAndToStringSimpleIntransitive()
        {
            string sample = "jan Mato li jan soweli.";
            Config dialect = Config.DialectFactory;
            dialect.TargetGloss = "en";

            CorpusKnowledge ck = new CorpusKnowledge(sample, dialect);
            Discourse[] s = ck.MakeSentences();
            foreach (Discourse d in s)
            {
                foreach (Sentence js in d)
                {
                    Sentence sentence = js;
                    Console.WriteLine(sentence.ToString());
                    Console.WriteLine(sentence.ToString("b"));

                    Assert.AreEqual(sample, sentence.ToString());    
                }
            }
        }


        [Test]
        public void SplitRealTest()
        {
            Config dialect = Config.DialectFactory;
            dialect.TargetGloss = "en";

            CorpusKnowledge c = new CorpusKnowledge(SampleText,dialect);
            int i = 0;
            foreach (string sentence in c.Setences)
            {
                i++;
                Console.WriteLine(i + ") " + sentence);
            }
        }

        //Added . to title.
        //Add + to en e.g. ma Napli en Inteja
        //Deferred dealing with direct speech as a content word  jan li toki e 'mi suli kin!'
        //Defer dealing with 'nimi' li sona e ni: 'nimi'
        public static string SampleText =
            @"jan Puta li jan lili. jan Puta li lon poka ma Nepali en+ Inteja. mama mije pi jan Puta li jan lawa lili pi ma tomo. mama mije pi jan Puta li wile e ni taso: jan Puta li tawa pona. mama mije pi jan Puta li weka e ijo ike tan nasin pi jan Puta lili. jan Puta li lukin ala e ijo ike. mama mije li pana ala e ken tawa jan Puta tawa tomo mute tawa. tenpo ale la jan Puta li lon insa tomo mute. tawa pi jan Puta li pona.

jan Puta li pilin ala pi musi pona li tawa tan tomo mute sama. mama mije li sona ala e ni li pana ala e ken. jan Puta li lukin e jan pi sijelo ike e jan sin ala e jan moli. ijo ni li sin tawa jan Puta lili! jan Puta li toki e nimi ni: 'ike a! tenpo kama la mi kama jan pi sijelo ike li kama jan sin ala e jan moli. jan ale li sama! ike a!' jan Puta li tawa noka tan tomo mute. jan Puta li weka e meli olin e jan mije lili kin. jan Puta li jan taso li jan sewi ala.

jan Puta li tawa ma pi kasi suli li kama alasa e jan sona mute. jan ni li jo ala e pali e kulupu mama. 'jan sona pi ma pi kasi suli o! o sona e mi e ijo sina' jan sona ni li pilin e ni. jan li wile e sona e wawa tan ike la o moku ala o wile ala o pali e sama e ike. jan Puta li moku ala li wile ala li pali e ike tawa sama kin. sijelo pi jan Puta li kama sama linja. taso tenpo ni kin la jan Puta li pilin ike. meli li lukin e jan Puta li pilin ike tawa jan nasa ni li pana e moku pan tawa jan Puta. sin la sijelo pi jan Puta li kama pona. tan ni la jan Puta li pilin e ni: nasin pi jo ale li ike. nasin pi jo ala li ike. jan Puta li toki e ni tawa jan sona pi ma pi kasi suli: 'mi tawa. mi alasa e nasin ante. ken la mi alasa e nasin insa.'

jan Puta li ken awen ala li wile kama sona e nasin sin. jan Puta li toki e ni: 'mi awen lon anpa kasi suli ni li kama sona e nasin sin. anu mi tawa ala.' jan Puta li pilin li pilin li pilin. jan Puta li lukin e kon ike Mawa. kon ike Mawa li toki e ni tawa jan Puta: 'o pali ala! sina ken musi! sina ken jo e mani e unpa e moku!' jan Puta li awen. kon ike Mawa li toki e ni: 'o pali ala! mi ken ala e sina! sina li seli li pilin ike li moli!' jan Puta li awen. tenpo ni la jan Puta li pilin e ma kepeken luka li toki e ni: 'o ma li lukin e ni: mi kama sona e pini pi nasin pi pilin ike.' kon ike Mawa li anpa li tawa.

jan Puta li tawa ma pi kasi suli li toki e ni: 'jan pona mi o! mi sona e sona pi pini pi nasin pi pilin ike.' jan sona li toki e ni: 'kin la? o toki!'

jan Puta li toki:

'ale li ike.
ike li tan wile.
wile li ken pini.
nasin li lon li jo e kipisi luka tu tu.

o lukin pona o pilin pona. o toki pona o pali pona o mani pona. o wawa pona o sona pona o awen pona.'

jan son pi ma pi kasi suli li toki e ni: 'a? mi ken sona ala e nimi sina. o suli e nimi sina.'

jan Puta li toki e ni: 'o lukin pona o pilin pona' ni li sona e ni: sina ken sona e lon. lon li ike li ante li jo ala e sama. sina ken sona e ni. kin la sina li pilin e ni: 'mi wile ala e ma li tawa nasin ante'

jan sona pi ma pi kasi suli li toki e ni: 'a! ni li sona suli kin. o toki e ijo pi toki en pali en mani!'

jan Puta li toki e ni: 'o toki pona o pali pona o mani pona!' ni li sona e ni: 'o toki ala e ijo pi lon ala. o toki ala e ike tawa jan ante. o pali ala e ike. o moli ala. o unpa ike ala. o pali ala e ike tawa mani. o moku ala e telo nasa'

jan sona pi ma pi kasi suli li toki e ni: 'a! ni li sin ala. nasin ale li toki li pilin e ni. o toki e ijo pi wawa en sona en awen!'

jan Puta li toki e ni: 'o wawa pona o sona pona o awen pona!' ni li sona e ni: 'o awen e monsi sina lon ma o lukin lon insa e lawa insa sama o kama alasa e wawa sina e sona sina e awen wawa sina. tan ni la sina pini lape.'

jan sona pi ma pi kasi suli li toki e ni: 'sina nasa'

jan Puta li toki ala e ike li toki e ni: 'o kama! o lukin sama e lon!'

jan sona pi ma pi kasi suli li tawa kepeken jan Puta li tawa ma ale. jan Puta li pana e sona sama tawa jan mute. jan Puta li wile ala pali e ike tawa mani. tan ni la jan Puta li jo ala e mani pi kiwen suno. jan Puta en jan pona ona li kama jo e moku tan jan pi tomo mute. jan li pana e moku soweli ike tawa jan Puta. jan Puta li ken pilin taso e pilin pona pi kama jo li moku e soweli moli ike ni. jan Puta li moli.

jan sona pi jan Puta li tawa nasin Puta li pana e sona pi nasin Puta tawa jan pi ma ale. tenpo ni la kipisi pi nasin Puta li mute. jan li ante. jan li wile e sona ante. taso ale li sama lon insa nasin sona ni. ale li ike. ike li tan wile. wile li ken pini.";


        public static string SampleText1 = @"
jan lawa lili. 

tenpo pi lili mi la mi lukin e sitelen pona. akesi linja li moku e soweli suli. ni li sitelen: 

lipu li toki e ni: akesi linja li moku li tawa ala e nena uta. ona li moku la ona li lape. mi pilin pona tan ni. mi pali e sitelen pi nanpa wan: 

mi toki tawa jan suli: o lukin! sina pilin ike ala pilin ike tan sitelen ni?

ona li toki: mi pilin ike tan len lawa anu seme?

sitelen mi li ala e len lawa. sitelen mi li ni: akesi linja li moku e soweli suli mute. 

jan suli li sona taso e toki pona. mi pali e sitelen pi nanpa tu. ona li insa pi akesi linja: 

jan suli li toki: o pali ala e sitelen akesi anu insa akesi. o sona e sona nanpa e sona ma e sona tenpo e sona toki!

jan suli li pilin ike tawa sitelen mi la mi pali ala e sitelen sin. 

mi pali e ijo ante. mi kepeken e tomo-tawa-kon. ni li lon: sona ma li pona tawa mi. mi ken sona e ante pi ma Kina en ma Alisona. tenpo pimeja la sona ni li pona. 

tenpo lili la mi sona mute e jan suli. taso, mi pilin ike tan ni! 

tenpo ijo la mi pilin e ni: jan suli ni li pona. mi pana e sitelen pi nanpa wan tawa ona. mi wile sona e ni: jan ni li jo ala jo e pi sona pona? 

tenpo ali la jan suli li toki: ni li len lawa.  mi toki ala e akesi e ma kasi e sike sewi lili tawa ona tan ni. mi toki e musi pi jan suli e nasin wawa e len pi anpa lawa. jan suli li pilin pona tawa mi tan ni.";
    }
}
