using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.MoreTypes;

namespace BasicTypes
{
    //Can configure additional knowledge here (is animate, etc)
    public static class Words
    {
        static Words()
        {
            Dictionary = new Dictionary<string, Word>
            {
                {"a",Words.a},
                {"akesi",Words.akesi},
                {"ala",Words.ala},
                {"alasa",Words.alasa},
                {"ale",Words.ale},
                {"ali",Words.ali},
                {"anpa",Words.anpa},
                {"ante",Words.ante},
                {"awen",Words.awen},
                {"esun",Words.esun},
                {"ijo",Words.ijo},
                {"ike",Words.ike},
                {"ilo",Words.ilo},
                {"jan",Words.jan},
                {"jelo",Words.jelo},
                {"jo",Words.jo},
                {"kala",Words.kala},
                {"kalama",Words.kalama},
                {"kama",Words.kama},
                {"ken",Words.ken},
                
                {"luka", Words.luka},

                {"mi",Words.mi},
                {"moku",Words.moku},

                {"mute",Words.mute},

                {"ni",Words.ni},

                {"nanpa",Words.nanpa},

                {"ona",Words.ona},

                {"seme",Words.seme},

                {"sina",Words.sina},
                {"suli",Words.suli},

                {"tu",Words.tu},

                {"wan",Words.wan},
                {"wawa",Words.wawa},


            };
        }

        //Need name, equivalent versions, gloss.
        public static readonly Dictionary<string, Word> Dictionary;

        public static Word a = new Word("a",
            Map(interjection: "ah"));
        public static Word akesi = new Word("akesi",
            Map(noun: "beast", adjective: "beastlike", adverb: "beastly"));
        public static Word ala = new Word("ala",
            Map(noun: "no", adjective: "not", adverb: "not"));
        public static Word alasa = new Word("alasa",
            Map(noun: "gathering", adjective: "gathered", verbIntransitive: "gather"));

        public static Word ale = new Word("ale",
            Map(noun: "everything", adjective: "every"));
        public static Word ali = new Word("ali",
            Map(noun: "everything", adjective: "every"));

        public static Word anpa = new Word("anpa",
            Map(noun: "bottom", adjective: "lower", adverb: "lowely", verbIntransitive: "defeat"));

        //conj	otherwise, or else
        public static Word ante = new Word("ante",
            Map(noun: "difference", adjective: "different", verbIntransitive: "change"));

        //anu - conjunction

        public static Word awen = new Word("awen",
            Map(noun: "permanance", adjective: "stationary",
                verbIntransitive: "stay", verbTransitive: "keep"));

        //        vi	stay, wait, remain
        //vt	keep
        //mod	remaining, stationary, permanent, sedentary
        public static Word esun = new Word("esun",
            Map(noun: "market", adjective: "commercial", verbTransitive: "sell"));

        public static Word ijo = new Word("ijo",
            Map(noun: "thing", adjective: "of something", verbTransitive: "objectify"));
        //        n	thing, something, stuff, anything, object
        //mod	of something
        //vt	objectify

        public static Word ike = new Word("ike",
            Map(noun: "evil", adjective: "bad", verbTransitive: "make worse", verbIntransitive: "is bad"));
        //mod	bad, negative, wrong, evil, overly complex, (figuratively) unhealthy
        //interj	oh dear! woe! alas! ****
        //n	negativity, badness, evil
        //vt	to make bad, to worsen, to have a negative effect upon
        //vi	to be bad, to suck

        public static Word ilo = new Word("ilo",
            Map(noun: "tool", adjective: "mechanical", verbTransitive: "manufacture", verbIntransitive: "is a machine"));
        //n	tool, device, machine, thing used for a specific purpose

        public static Word jan = new Word("jan",
            Map(noun: "person", adjective: "human", adverb: "humanly"));

        public static Word jelo = new Word("jelo",
            Map(noun: "something yellow", adjective: "yellow", adverb: "in a yellow fashion"));


        public static Word jo = new Word("jo",
            Map(noun: "possession", adjective: "owned", verbTransitive: "have"));

        //vt	have, contain
        //n	having
        //kama	receive, get, take, obtain

        public static Word kala = new Word("kala",
            Map(noun: "fish", adjective: "fishy", adverb: "fishyly"));
        //    kala 魚, 鱼 (zh) yu2
        //n	fish, sea creature

        public static Word kalama = new Word("kalama",
            Map(noun: "noise", adjective: "noisy", adverb: "noisyly", verbIntransitive: "make a noise", verbTransitive: "sound"));

        //kalama 音 (jp), 音(zh) yin4
        //    n	sound, noise, voice
        //    vi	make noise
        //    vt	sound, ring, play (an instrument)


        public static Word kama = new Word("kama",
            Map(noun: "event", adjective: "coming", adverb: "noisyly", verbIntransitive: "come", verbTransitive: "bring about"));

        //    kama 来 (jp), 到 (zh) dao4
        //vi	come, become, arrive, happen, pursue actions to arrive to (a certain state), manage to, start to
        //n	event, happening, chance, arrival, beginning
        //mod	coming, future
        //vt	bring about, summon

        public static Word kasi = new Word("kasi",
            Map(noun: "plant", adjective: "vegetable"));
        //    kasi 木 (jp), 木 (zh) mu4
        //n	plant, leaf, herb, tree, wood

        public static Word ken = new Word("ken",
          Map(noun: "permission", adjective: "possible", adverb: "possibly", verbIntransitive: "can", verbTransitive: "enable"));
        //    ken 能 (jp), 能 (zh) neng2
        //vi	can, is able to, is allowed to, may, is possible
        //n	possibility, ability, power to do things, permission
        //vt	make possible, enable, allow, permit
        //cont	it is possible that

        
        public static Word lon = new Word("lon",
          Map(noun: "existence", adjective: "actual", adverb: "truely", verbIntransitive: "exists", verbTransitive: "placed"));
        //prep	be (located) in/at/on
        //vi	be there, be present, be real/true, exist, be awake

        public static Word luka = new Word("luka",
          Map(noun: "hand", adjective: "hand-like", adverb: "with hands", verbIntransitive: "is a hand", verbTransitive: "put hand on"));
//        luka 手 (jp), 手 (zh) shou3
//n	hand, arm

        public static Word mi = new Word("mi",
            Map(noun: "I", adjective: "my"));


        //        moku 食 (jp), 菜 (zh) cai4
        //n	food, meal
        //vt	eat, drink, swallow, ingest, consume
        public static Word moku = new Word("moku",
            Map(noun: "food", adjective: "edible", adverb: "food-like", verbIntransitive: "is food", verbTransitive: "eat"));

        public static Word mute = new Word("mute",
            Map(noun: "a lot", adjective: "many", verbTransitive: "make many "));

//mod	many, very, much, several, a lot, abundant, numerous, more
//n	amount, quantity
//vt	make many or much

        public static Word ni = new Word("ni",
            Map(noun: "this", adjective: "that's"));

        public static Word nanpa = new Word("nanpa",
            Map(noun: "number", adjective: "numeric", adverb: "numerously", verbIntransitive: "is a number", verbTransitive: "count"));

        public static Word ona = new Word("ona",
            Map(noun: "they", adjective: "their")); //he/she/it/they

        public static Word seme = new Word("seme",
            Map(noun: "what", adjective: "what sort", adverb: "how", verbIntransitive: "did what to", verbTransitive: "is what"));
        public static Word sina = new Word("sina",
            Map(noun: "you", adjective: "your"));

        public static Word suli = new Word("suli",
            Map(noun: "size", adjective: "large", adverb: "largely", verbIntransitive: "grow", verbTransitive: "enlarge"));

        //        suli 大 (jp), 高 (zh) gao1
        //mod	big, tall, long, adult, important
        //vt	enlarge, lengthen
        //n	size

        public static Word tu = new Word("tu",
            Map(noun: "two", adjective: "two", adverb: "doublely", verbIntransitive: "is two", verbTransitive: "split"));

        public static Word wan= new Word("wan",
            Map(noun: "one", adjective: "one", adverb: "singularly", verbIntransitive: "is one", verbTransitive: "unite"));


        public static Word wawa = new Word("wawa",
            Map(noun: "energy", adjective: "energetic", adverb: "largely", verbIntransitive: "is powerful", verbTransitive: "strengthen"));

        
        //        wawa 力 (jp), 力 (zh) li4
        //n	energy, strength, power
        //mod	energetic, strong, fierce, intense, sure, confident
        //vt	strengthen, energize, empower


        public static Dictionary<string, Dictionary<string, string[]>> Map(string language = "en", string noun = null, string adjective = null, string verbIntransitive = null, string verbTransitive = null, string adverb = null, string interjection = null)
        {
            Dictionary<string, Dictionary<string, string[]>> s = new Dictionary<string, Dictionary<string, string[]>>();
            s.Add(language, MapItem(new[] { noun }, new[] { adjective }, new[] { verbIntransitive }, new[] { verbTransitive }, new[] { adverb }, new[] { interjection }));
            return s;
        }

        public static Dictionary<string, string[]> MapItem(string[] noun = null, string[] adjective = null, string[] verbIntransitive = null, string[] verbTransitive = null, string[] adverb = null, string[] interjection = null)
        {
            Dictionary<string, string[]> map = new Dictionary<string, string[]>();
            if (noun != null)
                map.Add(PartOfSpeech.Noun.DisplayName, noun);
            if (adjective != null)
                map.Add(PartOfSpeech.Adjective.DisplayName, adjective);
            if (verbIntransitive != null)
                map.Add(PartOfSpeech.VerbIntransitive.DisplayName, verbIntransitive);
            if (verbTransitive != null)
                map.Add(PartOfSpeech.VerbTransitive.DisplayName, verbTransitive);
            if (adverb != null)
                map.Add(PartOfSpeech.Adverb.DisplayName, adverb);
            if (interjection != null)
                map.Add(PartOfSpeech.Interjection.DisplayName, interjection);
            return map;
        }


    }

    public class WordMap
    {
        public PartOfSpeech PartOfSpeech { get; set; }
        public Gloss Gloss { get; set; }
    }

    public class Gloss
    {
        public string Culture { get; set; }
        public string[] Meanings { get; set; }
    }
}
