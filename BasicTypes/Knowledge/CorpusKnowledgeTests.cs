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
        public static string SampleText3 =
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

        //fixed: ona lukin taso e kasi suli mute. => ona li lukin taso e kasi suli mute.
        public static string Gilgamesh = @"jan Kikamesi. 

jan Kikamesi li utala e jan Kunpapa.
jan Kikamesi li jan lawa pi ma tomo Uluku. jan Enkitu li kama tan ma nena. jan Enkitu li jan pona tawa jan Kikamesi. ona li jan sama. ona li wawa mute.

wile wawa.
jan Enkitu li toki ala. ona li pilin ike li pana e telo oko. jan Kikamesi li lukin e ona li toki e ni: 'jan sama o, sina pilin ike tan seme?'. jan Enkitu li open e uta ona li toki e ni: 'luka mi li kama wawa ala. wawa mi li kama lili'. jan Kikamesi li toki tawa ona li toki e ni: 'o tawa! mi tu o tawa nena pi kasi suli. nena ni li weka tan ni. ona li lon tawa nasin pi anpa suno. kasi suli mute li lon ma ni. palisa pi kasi ni li sewi li kiwen. kasi suli sama li lon ala ma mi. taso jan Kuwawa li lon nena pi kasi suli. jan li kama tawa kasi suli ni li wile pakala e ona li wile kama jo e ona la jan Kuwawa li utala e ona li moli e ona. jan Kuwawa li ike li wawa mute. mi wile e ni: jan ike li lon ala ma. o tawa sewi nena! sina en mi li utala e ona, li anpa e ona, li moli e ona!'.

wile pi nimi suli.
jan Enkitu li toki e ni: 'jan sama o, jan sewi li wile e ni: jan Kuwawa li lon ma kasi ni. jan sewi An li wile e ni: jan Kuwawa li moli e jan. soweli li tawa lon ma kasi la jan Kuwawa li ken kute e kalama lili weka. jan seme li ken kama tawa ma kasi ni? kalama uta pi jan Kuwawa li sama kalama pi telo suli wawa. uta ona li sama seli. kon pi uta ona li sama moli. sina wile utala e jan ni tan seme? mi tu li wawa sama ala jan ni. mi ken ala anpa e ona'.

jan Kikamesi li toki tawa jan Enkitu li toki e ni: 'jan pona mi o, jan seme li ken tawa sewi kon sewi? jan sewi taso li moli ala. tenpo suno mute pi jan ma li kama pini. jan li moli. jan li pali e ijo. taso ijo ali ni li sama kon. tenpo ni la sina pilin ike tan ni: sina ken moli. wawa sina li lon seme? pona. mi lawa e sina. tenpo pi tawa mi li kama la sina toki e ni tawa mi: «o tawa, o pilin ike ala!». jan ike ni li anpa e mi li moli e mi la jan mute li toki e ni: »jan Kikamesi li utala e jan wawa Kuwawa li kama anpa li kama moli«. tenpo kama la jan lili mi li toki e ni: «jan Kikamesi li utala e jan wawa Kuwawa». tenpo mute kama la jan li toki e ni: «jan Kikamesi li utala e jan wawa Kuwawa lon nena pi kasi suli li kama moli lon utala ni». nimi mi li kama suli'.

kulupu pi jan sona.
jan Kikamesi en jan Enkitu li tawa supa pi ma tomo. jan lawa Kikamesi li toki e ni: 'jan ali o kute! mi wile kama tawa jan wawa Kuwawa li moli e ona. jan li jo ala e mama li jo ala e meli la mi wile e ni: jan ni tawa poka mi'. jan mute li kulupu poka ona. jan Kikamesi en jan Enkitu li tawa jan pali pi ilo utala. ona li pali e ilo suli pi kasi suli e ilo palisa utala suli li pana e ilo ni tawa ona.

jan Kikamesi li kama tawa kulupu pi jan sona pi ma tomo Uluku li toki e ni: 'mi wile kama tawa jan Kuwawa li utala e ona li moli e ona. nimi mi li kama suli. nimi pi jan tan ma tomo Uluku li kama suli''. jan sona li toki tawa jan Kikamesi li toki e ni: 'jan lawa o! sina wile utala e jan ike ni tan seme? pilin sina li suli li wawa sama pilin pi jan lili. taso sona sina li suli ala. jan Kuwawa li ike lukin li wawa mute. kalama uta pi jan Kuwawa li sama kalama pi telo suli wawa. uta ona li sama seli. kon pi uta ona li sama moli. sina ken ala anpa e ona. wile sina li pona ala'.

jan Kikamesi li toki tawa jan Enkitu li toki e ni: 'jan pona mi o! jan ni li toki e nimi Kuwawa taso la ona li pilin ike kin'. ona li toki e ni: 'jan sona pi ma tomo Uluku o! mi jan lawa. jan Enkitu li tawa poka mi. ona li kama tan ma nena li suli li wawa. mi tu li ken anpa e jan wawa Kuwawa lon nena pi kasi suli'.

jan sona li toki tawa jan Kikamesi li toki e ni: 'o tawa! o jan sewi sina li pana e pona tawa sina!'.

jan sewi Utu.
jan Kikamesi li tawa tomo pi jan sewi Utu. ona li moli e soweli lili li sewi e luka ona. ona li toki e ni: 'jan sewi Utu o! mi wile kama tawa jan Kuwawa li utala e ona. mi wile e ni: nimi mi li kama suli. sina sona li pona. o pana e pona tawa mi! o kama e ni: mi anpa e jan wawa ni li jo e sijelo pona li tawa ma tomo Uluku'. taso jan sewi li toki ala.

jan Kikamesi li pana e telo oko. ona li toki e ni: 'jan sewi Utu o! mi moli e jan Kuwawa la mi toki mute e pona sina li pali e sitelen sina kiwen'. telo oko pi jan Kikamesi li pona tawa jan sewi Utu. ona li toki tawa jan Kikamesi li toki e ni: 'jan Kikamesi o pilin pona. mi lawa e kon tawa. mi jo e kon tawa seli. mi jo e kon tawa lete. mi jo e kon tawa telo. mi jo e kon tawa pi ko kiwen lili. mi jo e kon tawa tan ma lete. mi jo e kon tawa tan ma seli. o tawa nena pi kasi suli! o utala e ike'. jan sewi Utu li kulupu e kon tawa mute lon insa lupa pi nena kiwen.

jan sewi Nintu.
jan Kikamesi li toki tawa jan Enkitu li toki e ni: 'jan pona o kama poka mi. o tawa tomo suli pi mama sewi mi'. jan Kikamesi li lawa e jan Enkitu tawa tomo pi jan sewi Nintu. ona li kama lon insa tomo li toki e ni: 'mama o, mi wile kama tawa jan Kuwawa ike li moli e ona. o toki pona e mi tawa jan sewi Utu!'. jan sewi Nintu li telo e sijelo ona li len e len pona lukin. ona li pana e linja sike tawa anpa lawa ona. jan Nintu li tawa tomo sewi pi jan sewi Utu li sewi e luka li toki e ni: 'jan sewi Utu o! sina li pilin ike tawa ike ali. jan lili mi li wile anpa e ike. jan Kikamesi li wile anpa e jan wawa Kuwawa. o pana e pona tawa jan lili mi'.

jan sewi Nintu li toki tawa jan Enkitu li toki e ni: 'sina jan pona pi jan Kikamesi. sina jan sama pi jan lili mi. jan Enkitu o, sina jan lili mi'. ona li toki e nimi ni: 'jan lili mi o tawa poka jan Kikamesi! o pana e pona tawa ona. o utala e ike ali poka ona'. jan sewi Nintu li toki e nimi pona wawa li pana e linja sike pi anpa lawa tawa jan Enkitu.

nasin tawa pi ma pi kasi suli.
ona li kama tawa. jan Kikamesi li lawa. ona li jo e ilo suli pi kasi suli e ilo utala palisa suli. jan Enkitu li tawa lon monsi pi jan Kikamesi. ona kin li jo e ilo pi kasi suli e ilo utala palisa. kulupu pi jan mute li tawa lon monsi jan Enkitu li jo e ilo pi kasi suli. ona li tawa nasin tawa pi nena pi kasi suli.

tenpo suno la ona li tawa. ona li tawa weka mute tan ma tomo Uluku. tenpo pimeja li kama la ona li pali e lupa pi telo pona. tenpo suno sin la ona li weka e telo pona lili tawa jan sewi Utu. jan sewi li lukin e ona li pilin pona. tenpo suno sin la ona li tawa nasin pi nena pi kasi suli li tawa weka mute mute tan ma tomo. tenpo pimeja sin la ona li pali e lupa pi telo pona li weka e telo pona lili tawa jan sewi.

lape pi jan Kikamesi.
ona li tawa nena suli loje walo. jan Kikamesi li weka e ko pan pona tawa ma li toki e ni: 'nena o pana e lape pona tawa mi!'. tenpo pimeja li kama. jan Kikamesi en jan Enkitu li anpa. ona tu li pilin e luka pi jan sama li lape. jan Kikamesi li pini wawa e lape ona li toki e ni: 'jan Enkitu o, sina toki ala toki tawa mi? sina pilin ala pilin e mi? lape mi li pini tan seme? mi lape li lukin e ni: mi utala e soweli wawa. ona li tawa wawa e noka ona li tawa e ko kiwen. tan ni la kon li pimeja. luka mi li wawa ala. mi ken ala anpa e ona. jan ante li tawa mi li pana e telo tawa mi. ona li pona'.

jan Enkitu li toki e ni: 'jan pona mi o, lukin lape sina li pona. jan Kuwawa li nasa lukin li wawa lukin. taso ona li sama ala soweli wawa ni. soweli wawa pi lape sina li jan sewi Utu. tenpo utala la ona li pana e pona tawa mi tu. mama sina kin li pana e telo tawa sina. ona li jan lawa Lukapanta'.

ma pi kasi suli.
tenpo suno li kama. ona li tawa sewi nena li kama tawa poka pi ma pi kasi suli. ona li awen li toki ala. ona li lukin taso e kasi suli mute. ona li lukin e ni: kasi suli li sewi mute. nasin pona li lon insa pi ma pi kasi suli. tenpo mute la jan Kuwawa li tawa lon nasin ni. noka ona li pali e nasin ni. seli suno li ken ala kama tawa insa pi ma kasi tan ni: kasi ni li suli mute. pimeja ni li lete li pona.

ona li tawa lon insa ma pi kasi suli. jan Kikamesi li lukin li toki e ni: 'ni li kasi suli pona'. ona li kama jo e ilo li anpa e kasi suli. jan Enkitu li weka e palisa tan kasi suli ni.

wawa sewi.
jan Kuwawa li kute e kalama li pilin ike wawa. ona li toki wawa e ni: 'jan seme li kama tawa ma mi li pakala e kasi suli mi?'. jan Kuwawa li pana e wawa sewi tawa kalama ni. wawa sewi ni li sama kon li sama suno. ona li tawa sama ilo moli linja. jan Kikamesi li kama anpa li lape. jan Enkitu li lape. jan ante tan ma tomo Uluku li lape sama soweli pona lili.

jan Enkitu li pini e lape. kalama ala li lon. ona li pilin e jan Kikamesi kepeken luka ona. jan Kikamesi li tawa ala. jan Enkitu li toki wawa e ni: 'jan Kikamesi o! jan sama o! tenpo pi suli seme la sina li lape kin?'. jan Enkitu li tawa wawa e ona li toki wawa tawa ona.

jan Kikamesi li open e oko ona li tawa sewi. ona li toki e ni: 'ike a! jan ni li jan ma anu jan sewi?'. jan Enkitu li toki e ni: 'jan Kuwawa li wawa mute. jan pona o tawa ala jan ni! mi mute o tawa weka tan ma ni. o tawa ma tomo Uluku'. jan Kikamesi li toki tawa jan Enkitu li toki e ni: 'mi wile lukin e jan ni, li utala e ona. o pilin pona. jan tu li ken ala moli. sina en mi li ken anpa e ona'.

utala li kama.
jan sewi Utu li toki tawa jan Kikamesi li toki e ni: 'o awen ala! jan Kuwawa li len e wawa sewi wan taso. ona li jo e wawa sewi mute lon tomo ona. sina awen la ona li ken len e wawa sewi ali. o tawa!'.

ona tu li tawa wawa tomo pi jan Kuwawa. jan Kuwawa li tawa ona. jan Kikamesi li toki wawa e ni: 'mi jan Kikamesi li jan lawa pi ma tomo Uluku! jan Kuwawa ike o kama moli!'. ona li wile utala e jan Kuwawa kepeken ilo utala palisa. jan Enkitu li kama tawa utala kin poka ona. taso ona li ken ala utala e ona. jan Kuwawa li tawa wawa weka tan nasin pi ilo utala. kalama uta ona li sama kalama pi telo suli wawa. uta ona li sama seli. ona li utala la ma li pakala. nena suli li tawa. kon li kama pimeja. jan Kikamesi li pilin ike li pana e telo oko. ona li toki e ni: 'a! ona li wawa mute. mi ken anpa ala e ona. jan sewi Utu o! o pana e pona tawa mi!'.

kon tawa mute.
jan sewi Utu li kute e toki pi jan Kikamesi. ona li weka e kon tawa mute tan insa lupa pi nena kiwen. kon tawa seli li utala e jan Kuwawa. kon tawa lete li utala e ona. kon tawa telo li utala e jan Kuwawa. kon tawa pi ko kiwen lili li utala e ona. kon tawa tan ma lete li utala e jan Kuwawa. kon tawa tan ma seli li utala e ona. kon tawa mute li utala e jan Kuwawa. ona li ken ala tawa. tenpo ni la jan Kikamesi en jan Enkitu li ken tawa ona li ken utala e ona kepeken ilo utala ona.

jan Kuwawa li awen. sinpin pi lawa ona li kama pona lukin. ona li toki e ni: 'jan Kikamesi o kute e mi! jan lawa wawa o moli ala e mi! mi sona ala e mama mi. nena suli li mama mi. jan sewi An li wile e ni: jan li wile pakala e kasi suli ni la mi utala e ona li moli e ona. o pilin ike ala tawa mi! mi wile e ni: sina jan lawa mi. mi anpa e kasi suli mi li pana e ona mute tawa sina. o moli ala e mi. o weka e mi'.

moli pi jan Kuwawa.
jan Kikemesi li pini pilin e ike tawa jan Kuwawa. ona li toki tawa jan Enkitu li toki e ni: 'jan li kama jo e waso lili la jan li wile weka e ona li wile e ni: ona li tawa mama ona. ni li pona ala pona?'. jan Enkitu li toki e ni: 'o kute ala e jan Kuwawa. ona li ike. o weka ala e ona. sina weka e ona la ona li pakala e nasin tawa ma tomo Uluku lon ma ni li utala e mi mute'. jan Kuwawa li toki e ni: 'jan Enkitu o, toki sina li toki ike li toki utala. jan lawa sina li pana e moku tawa sina. tan ni taso la sina tawa lon monsi ona. tan ni la sina wile ala e ni: jan Kikamesi li jan lawa mi kin. jan anpa o! o toki ala!'.

jan Enkitu li pilin ike wawa. ona li utala wawa e jan Kuwawa kepeken ilo utala palisa li weka e lawa ona tan sijelo ona. jan Kuwawa li anpa lon ma. kasi suli mute li kalama sama pilin ike.

nimi suli.
jan Kikamesi en jan Enkitu li anpa e kasi suli. jan Uluku li pali poka ona. jan Enkitu li toki e ni: 'jan sewi Utu li pona mute. mi wile pali e sinpin suli pi lupa pi tomo ona. kasi suli ni li pona mute tawa pali ni'. ona mute li anpa e kasi suli mute.

ona li kama jo e kasi suli mute li tawa tan nena pi kasi suli tawa telo tawa Pulatu. ona li wan e kasi suli mute li pali e supa tawa mute. ona li tawa lon supa ni li tawa e ona lon telo tawa kepeken palisa. nasin ni la ona li tawa lon telo. tenpo suno mute lili pini la ona li tawa ma tomo Uluku. jan mute li kulupu li toki e ni: 'o lukin! o pilin pona! ona li jan utala pona kin!'. nimi ona li suli.";

        //taso ona sewi
        public static readonly string SampleText = @"jan Oliwa en jan Malija li uta e sama li pilin suwi e sijelo sama la jan Oliwa li toki e ni:'mi pilin e ni: tenpo ni li tenpo tawa ..' jan Malija li toki kin: 'mi tu li unpa. a! lon! o mi tu li kama tawa tomo mi.' 

ona tu kama. 

tomo lape la jan Oliwa li open weka e len pi jan Malija. taso meli li toki e ni. 'o pini. o mi tu li kepeken e tenpo suli tawa open musi. open la mi weka e len sina. ni pini la sina pali e mi.' meli li open weka e len mije. nanpa wan la meli li weka e len noka anpa pi tu en tu mije. meli li uta e noka mije li pilin suwi e ona. nanpa tu la meli li weka e len Sjelo sewi kepeken nasin ni: meli li open e nena len li uta e selo pi lukin sin. meli li pali e ni tawa nena Ali. taso meli li lukin e sike pi loje walo la meli li awen li uta suwi e ona li kama e ni: ona li kama nena. ni pini la meli li awen open sin. jan MaliyA li pini weka e len sijelo sewi la ona li open weka e len noka sewi. kin la ona li pali ni la palisa mije pi jan Oliwa li kama suli li kama kiwen. tan ni la meli li open e len sijelo sewi la len walo li nena wawa. meli li pilin suwi e ona li a li awen weka e len. meli li pini weka e len mije la jan Oliwa li toki e ni: 'tenpo ni la mi ken weka e len sina. mi musi mute ni.' taso ona li sewi e len meli la jan Malija li len kin e ala e len insa anpa ala e poki pi nena meli ala. jan Maliaja li lon wawa e selo unpa lon palisa pi jan Oliwai li anpa wawa lon supa lape. 

jan Oliwa li lon e noka sama lon insa pi noka meli. mije li open uta e sike pi loje walo li kama e ni: ona li nena. palisa luka mije li pilin suwi e nena unpa li kama e ni: jan Malija li A li A e kalama ni:'jan Oliwa o, o, o. Oli, o unpa e mi, unpa, unpa'. tenpo ni la meli li jo e palisa mije L lawa e ona tawa lupa meli. palisa pi jan Oliwa li tawa insa, mije li tawa en tan li tawa en tan. tenpo tawa Ali la meli li sewi e nena monsi sama li utala e palisa tawa. ona tu li kalama wawa. jan Oliwa li A e ni: 'jan Malija o, o, Mali o, ma, o, mama o' jan Malija li A wawa li anpa wawa sama lape. tenpo sama la jan Oliwa li A wawa li pana e linja suli pi telo walo mije li anpa wawa tawa sewi meli. tenpo lili pini la jan Malija li weka e selo jo pi telo walo li kama jo e len telo seli. meli li pona e sama kepeken len ni. ni pini la meli li open pona e palisa mije. tenpo ni la ona li suli ala li kiwen ala. 

taso meli li pona e ona la meli li wile pilin suwi e ona. tan ni la palisa li kama suli li kama kiwen.. jan Malija li lon e ona lon uta sama li pilin suwi e lawa ona kepeken loje uta sama. meli li tawa en tan lon palisa kepeken uta en luka. jan Oliwa li A wawa li sewi e nena monsi mije. jan MaliyA li kon kepeken uta li tawa en tan wawa mute. jan Oliwa li A wawa mute li pana e linja suli pi telo walo tawa nena meli. meli li pilin sike e telo sama pona selo. meli li anpa lon supa li anpa e noka sama tawa supa anpa. 

jan Oliwa li anpa e sama lon insa pi noka sama li lon e sinpin lawa ona lon insa pi noka meli. mije li open pilin suwi e Nene unpa meli kepeken loje uta sama. meli li open A li sewi e nena monsi li tawa en tan wawa. taso A pini meli kama la meli li kama jo e mije li lon e ona lon monsi mije li kama lon sewi mije li kama jo palisa mije li lawa e ona tawa lupa sama. meli li awen linja e monsi sama li tawa en tan wawa. nena meli kin li tawa en tan, li kama nena pi suli en kiwen. tenpo ni la jan Malija kama tawa A pini. jan Oliwa kin li A li pana e wan pi telo walo. jan Malija li kama jo sin e len telo seli li pona e sama en mije. tenpo lili kama la jan Oliwa en jan Malija li kulupu kepeken luka en noka li kama lape. taso ni kama la ona tu li toki e ni tawa sama: 'mi olin e sina'
";
    }
}
