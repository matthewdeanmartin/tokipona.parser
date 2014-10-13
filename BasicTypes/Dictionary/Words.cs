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
            Dictionary = new Word[]
        {
            Words.a,
            Words.akesi,
            Words.ala,
            Words.alasa,
            Words.ale,
            Words.ali,
            Words.anpa,
            Words.ante,
            Words.awen,
            
            Words.jan
            
        };
        }

        //Need name, equivalent versions, gloss.
        public static readonly Word[] Dictionary;

        public static Word a = new Word("a",
            Map(interjection:"ah"));
        public static Word akesi = new Word("akesi",
            Map(noun:"beast",adjective:"beastlike",adverb:"beastly"));
        public static Word ala = new Word("ala",
            Map(noun:"no",adjective:"not",adverb:"not"));
        public static Word alasa = new Word("alasa",
            Map(noun: "gathering", adjective: "gathered", verbIntransitive: "gather"));

        public static Word ale = new Word("alasa",
            Map(noun: "everything", adjective: "every"));
        public static Word ali = new Word("ali",
            Map(noun: "everything", adjective: "every"));

        public static Word anpa = new Word("anpa",
            Map(noun: "bottom", adjective: "lower", adverb:"lowely", verbIntransitive:"defeat"));

        //conj	otherwise, or else
        public static Word ante = new Word("ante",
            Map(noun: "difference", adjective: "different", verbIntransitive: "change"));

        //anu - conjunction

        public static Word awen = new Word("awen",
            Map(noun: "permanance", adjective: "stationary", 
                verbIntransitive: "stay",verbTransitive: "keep"));

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
            Map(noun: "possession", adjective: "owned", verbTransitive:"have"));

    //vt	have, contain
    //n	having
    //kama	receive, get, take, obtain

        public static Word kala = new Word("kala",
            Map(noun: "fish", adjective: "fishy", adverb:"fishyly"));
    //    kala 魚, 鱼 (zh) yu2
    //n	fish, sea creature

        public static Word kalama = new Word("kalama",
            Map(noun: "noise", adjective: "noisy", adverb:"noisyly", verbIntransitive:"make a noise", verbTransitive:"sound"));

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

        public static Word mi = new Word("mi",
            Map(noun: "I", adjective: "my"));
        public static Word ni = new Word("ni",
            Map(noun: "this", adjective: "that's"));

        public static Word nanpa = new Word("nanpa");

        public static Word ona = new Word("ona",
            Map(noun: "they", adjective: "their")); //he/she/it/they

        public static Word seme = new Word("seme");
        public static Word sina = new Word("sina",
            Map(noun: "you", adjective: "your"));

        public static SerializableDictionary<PartOfSpeech, string> Map(string noun = "", string adjective = "", string verbIntransitive = "", string verbTransitive = "", string adverb = "", string interjection = "")
        {
            SerializableDictionary<PartOfSpeech, string> map = new SerializableDictionary<PartOfSpeech, string>();
            if (noun != "")
                map.Add(PartOfSpeech.Noun, noun);
            if(adjective!="")
                map.Add(PartOfSpeech.Adjective, adjective);
            if (verbIntransitive != "")
                map.Add(PartOfSpeech.VerbIntransitive, verbIntransitive);
            if(verbTransitive!="")
                map.Add(PartOfSpeech.VerbTransitive, verbTransitive);
            if (adverb != "")
                map.Add(PartOfSpeech.Adverb, adverb);
            if (interjection != "")
                map.Add(PartOfSpeech.Interjection, interjection);
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
