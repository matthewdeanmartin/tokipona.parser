using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.MoreTypes;
using BasicTypes.Parts;

namespace BasicTypes
{
    //Can configure additional knowledge here (is animate, etc)
    public static class Words
    {
        public static Word a;
        public static Word akesi;
        public static Word ala;
        public static Word alasa;
        public static Word ale;
        public static Word ali;
        public static Word ante;
        public static Word anu;
        public static Word anpa;
        public static Word awen;
        public static Word e;
        public static Word en;
        public static Word esun;
        public static Word ijo;
        public static Word ike;
        public static Word ilo;
        public static Word insa;
        public static Word jaki;
        public static Word jan;
        public static Word jelo;
        public static Word jo;
        public static Word kala;
        public static Word kalama;
        public static Word kama;
        public static Word kasi;
        public static Word ken;
        public static Word kepeken;
        public static Word kili;
        public static Word kin;
        public static Word kipisi;
        public static Word kiwen;
        public static Word ko;
        public static Word kon;
        public static Word kule;
        public static Word kute;
        public static Word kulupu;
        public static Word la;
        public static Word lape;
        public static Word laso;
        public static Word lawa;
        public static Word len;
        public static Word lete;
        public static Word li;
        public static Word lili;
        public static Word linja;
        public static Word lipu;
        public static Word loje;
        public static Word lon;
        public static Word luka;
        public static Word lukin;
        public static Word lupa;
        public static Word ma;
        public static Word mama;
        public static Word mani;
        public static Word meli;
        public static Word mi;
        public static Word mije;
        public static Word moku;
        public static Word moli;
        public static Word monsi;
        public static Word mu;
        public static Word mun;
        public static Word musi;
        public static Word mute;
        public static Word namako;
        public static Word nanpa;
        public static Word nasa;
        public static Word nasin;
        public static Word nena;
        public static Word ni;
        public static Word nimi;
        public static Word noka;
        public static Word o;
        public static Word oko;
        public static Word olin;
        public static Word ona;
        public static Word open;
        public static Word pakala;
        public static Word pali;
        public static Word palisa;
        public static Word pan;
        public static Word pana;
        
        public static Word pi;
        public static Word pilin;
        public static Word pimeja;
        public static Word pini;
        public static Word pipi;
        public static Word poka;
        public static Word poki;
        public static Word pona;
        public static Word sama;
        public static Word seli;
        public static Word selo;
        public static Word seme;
        public static Word sewi;
        public static Word sijelo;
        public static Word sike;
        public static Word sin;
        public static Word sina;
        public static Word sinpin;
        public static Word sitelen;
        public static Word sona;
        public static Word soweli;
        public static Word suli;
        public static Word suno;
        public static Word supa;
        public static Word suwi;
        public static Word tan;
        public static Word taso;
        public static Word tawa;
        public static Word telo;
        public static Word tenpo;
        public static Word toki;
        public static Word tomo;
        public static Word tu;
        public static Word unpa;
        public static Word uta;
        public static Word utala;
        public static Word walo;
        public static Word wan;
        public static Word waso;
        public static Word wawa;
        public static Word weka;
        public static Word wile;

        //obs
        public static Word pata;
        public static Word kapa;
        public static Word iki;
        public static Word kan;
        public static Word pasila;
        public static Word kapesi;
        public static Word leko;
        public static Word majuno;
        public static Word tuli;
        public static Word po;
        public static Word kijetesantakalu;
        public static Word ipi;
        public static Word jalan;
        public static Word pu;
        public static Word apeja;
        public static Word pake;
        public static Word monsuta;

        public static Dictionary<string, Word> Dictionary;

        public static Dictionary<string, Dictionary<string, Dictionary<string, string[]>>> Glosses;

        static Words()
        {
            Dictionary = new Dictionary<string, Word>(141);
            Glosses = new Dictionary<string, Dictionary<string, Dictionary<string, string[]>>>(141);

            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "laugh" });
                    en.Add("adj", new[] { "indeed" });
                    en.Add("vi", new[] { "say ah" });
                    en.Add("interj", new[] { "ah", "ha", "uh", "oh", "ooh", "aw", "well" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("interj", new[] { "ho", "ha", "uf", "nu", "oj", "aŭ" });

                    glossMap.Add("eo", eo);
                }
                a = new Word("a");

                Dictionary.Add("a", a);
                Glosses.Add("a", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "non-cute animal", "reptile", "amphibian" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "malkaresinda besto", "rampulo", "amfibio" });

                    glossMap.Add("eo", eo);
                }
                akesi = new Word("akesi");

                Dictionary.Add("akesi", akesi);
                Glosses.Add("akesi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "nothing", "negation", "zero" });
                    en.Add("adj", new[] { "no", "not", "none", "un-" });
                    en.Add("adv", new[] { "not" });
                    en.Add("interj", new[] { "no!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "nenio", "neado", "nul" });
                    eo.Add("adj", new[] { "ne" });
                    eo.Add("adv", new[] { "ne" });
                    eo.Add("interj", new[] { "ne!" });

                    glossMap.Add("eo", eo);
                }
                ala = new Word("ala");

                Dictionary.Add("ala", ala);
                Glosses.Add("ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("vt", new[] { "to gather", "to collect", "to gather", "to harvest", "to hunt", "to pursue" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("vt", new[] { "???" });

                    glossMap.Add("eo", eo);
                }
                alasa = new Word("alasa");

                Dictionary.Add("alasa", alasa);
                Glosses.Add("alasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "everything", "anything", "life", "the universe" });
                    en.Add("adj", new[] { "all", "every", "complete", "whole" });
                    en.Add("adv", new[] { "completely", "wholely" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ĉio", "la vivo", "la universo" });
                    eo.Add("adj", new[] { "ĉiu(j)", "tuta", "kompleta" });
                    eo.Add("adv", new[] { "tute", "komplete" });

                    glossMap.Add("eo", eo);
                }
                ale = new Word("ale");

                Dictionary.Add("ale", ale);
                Glosses.Add("ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "everything", "anything", "life", "the universe" });
                    en.Add("adj", new[] { "all", "every", "complete", "whole" });
                    en.Add("adv", new[] { "completely", "wholely" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ĉio", "la vivo", "la universo" });
                    eo.Add("adj", new[] { "ĉiu(j)", "tuta", "kompleta" });
                    eo.Add("adv", new[] { "tute", "komplete" });

                    glossMap.Add("eo", eo);
                }
                ali = new Word("ali");

                Dictionary.Add("ali", ali);
                Glosses.Add("ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "difference" });
                    en.Add("adj", new[] { "different" });
                    en.Add("vt", new[] { "change", "alter", "modify" });
                    en.Add("adv", new[] { "differently" });
                    en.Add("conj", new[] { "otherwise", "or else" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "diferenco", "malsameco" });
                    eo.Add("adj", new[] { "alia", "malsama" });
                    eo.Add("vt", new[] { "ŝanĝi", "aliigi" });
                    eo.Add("adv", new[] { "alie", "malsame" });
                    eo.Add("conj", new[] { "alie", "aliokaze" });

                    glossMap.Add("eo", eo);
                }
                ante = new Word("ante");

                Dictionary.Add("ante", ante);
                Glosses.Add("ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("conj", new[] { "or" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("conj", new[] { "aŭ" });

                    glossMap.Add("eo", eo);
                }
                anu = new Word("anu");

                Dictionary.Add("anu", anu);
                Glosses.Add("anu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "bottom", "lower part", "under", "below", "floor", "beneath" });
                    en.Add("adj", new[] { "low", "lower", "bottom", "down" });
                    en.Add("adv", new[] { "lowly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "malsupro", "subo", "suba parto", "planko" });
                    eo.Add("adj", new[] { "malsupra", "suba" });
                    eo.Add("adv", new[] { "malsupre", "sube" });

                    glossMap.Add("eo", eo);
                }
                anpa = new Word("anpa");

                Dictionary.Add("anpa", anpa);
                Glosses.Add("anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "remaining", "stationary", "permanent", "sedentary" });
                    en.Add("vt", new[] { "keep" });
                    en.Add("vi", new[] { "stay", "wait", "remain" });
                    en.Add("adv", new[] { "permanently" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "restanta", "cetera", "daŭra" });
                    eo.Add("vt", new[] { "gardi" });
                    eo.Add("vi", new[] { "resti", "atendi", "daŭri" });
                    eo.Add("adv", new[] { "daŭre" });

                    glossMap.Add("eo", eo);
                }
                awen = new Word("awen");

                Dictionary.Add("awen", awen);
                Glosses.Add("awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                e = new Word("e");

                Dictionary.Add("e", e);
                Glosses.Add("e", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var eng = new Dictionary<string, string[]>();
                    eng.Add("conj", new[] { "and" });

                    glossMap.Add("en", eng);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("conj", new[] { "kaj" });

                    glossMap.Add("eo", eo);
                }
                en = new Word("en");

                Dictionary.Add("en", en);
                Glosses.Add("en", glossMap);
            }



            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "market", "shop" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "????" });

                    glossMap.Add("eo", eo);
                }
                esun = new Word("esun");

                Dictionary.Add("esun", esun);
                Glosses.Add("esun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "something" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                ijo = new Word("ijo");

                Dictionary.Add("ijo", ijo);
                Glosses.Add("ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "negativity", "badness", "evil" });
                    en.Add("adj", new[] { "bad", "negative", "wrong", "evil", "overly complex", "unhealthy" });
                    en.Add("vt", new[] { "to make bad", "to worsen", "to have a negative effect upon" });
                    en.Add("vi", new[] { "to be bad", "to suck" });
                    en.Add("adv", new[] { "badly", "negatively", "wrongly", "evilly", "overly complex", "unhealthyly" });
                    en.Add("interj", new[] { "oh dear! woe! alas!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "negativeco", "malbono", "malico" });
                    eo.Add("adj", new[] { "malbona", "aĉa", "malĝusta", "malica", "tro kompleksa", "malsana" });
                    eo.Add("vt", new[] { "malbonigi", "noci" });
                    eo.Add("vi", new[] { "aĉi" });
                    eo.Add("adv", new[] { "malbone", "aĉe", "malĝuste", "malice", "tro komplekse", "malsane" });
                    eo.Add("interj", new[] { "ho ve!" });

                    glossMap.Add("eo", eo);
                }
                ike = new Word("ike");

                Dictionary.Add("ike", ike);
                Glosses.Add("ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "tool", "device", "machine" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ilo", "maŝino" });

                    glossMap.Add("eo", eo);
                }
                ilo = new Word("ilo");

                Dictionary.Add("ilo", ilo);
                Glosses.Add("ilo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "inside", "inner world", "centre", "stomach" });
                    en.Add("adj", new[] { "inner", "internal" });
                    en.Add("adv", new[] { "internally" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "eno", "interno", "interna mondo", "centro", "ventro" });
                    eo.Add("adj", new[] { "ena", "interna" });
                    eo.Add("adv", new[] { "ene", "interne" });

                    glossMap.Add("eo", eo);
                }
                insa = new Word("insa");

                Dictionary.Add("insa", insa);
                Glosses.Add("insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "dirt", "pollution", "garbage", "filth" });
                    en.Add("adj", new[] { "dirty", "gross", "filthy" });
                    en.Add("vt", new[] { "pollute", "dirty" });
                    en.Add("adv", new[] { "dirtily", "grossly", "filthily" });
                    en.Add("interj", new[] { "ew! yuck!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "malpuro", "poluo", "rubo" });
                    eo.Add("adj", new[] { "malpura", "naŭza" });
                    eo.Add("vt", new[] { "malpurigi", "polui" });
                    eo.Add("adv", new[] { "malpure", "naŭze" });
                    eo.Add("interj", new[] { "kiom naŭze!" });

                    glossMap.Add("eo", eo);
                }
                jaki = new Word("jaki");

                Dictionary.Add("jaki", jaki);
                Glosses.Add("jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "person", "people", "human", "being", "somebody", "anybody" });
                    en.Add("adj", new[] { "human", "somebody's", "personal", "of people" });
                    en.Add("vt", new[] { "personify", "humanize", "personalize" });
                    en.Add("adv", new[] { "humanly", "personally" });
                    en.Add("pronoun", new[] { "one", "someone" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "homo", "ulo", "persono", "estaĵo", "iu" });
                    eo.Add("adj", new[] { "homa", "ies", "persona" });
                    eo.Add("vt", new[] { "personigi", "homigi" });
                    eo.Add("adv", new[] { "home", "persone" });

                    glossMap.Add("eo", eo);
                }
                jan = new Word("jan");

                Dictionary.Add("jan", jan);
                Glosses.Add("jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "yellow", "light green" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "flava", "helverda" });

                    glossMap.Add("eo", eo);
                }
                jelo = new Word("jelo");

                Dictionary.Add("jelo", jelo);
                Glosses.Add("jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "having" });
                    en.Add("vt", new[] { "have", "contain" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "havado" });
                    eo.Add("vt", new[] { "ricevi", "preni" });

                    glossMap.Add("eo", eo);
                }
                jo = new Word("jo");

                Dictionary.Add("jo", jo);
                Glosses.Add("jo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "fish", "sea creature" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "fiŝo", "marbesto" });

                    glossMap.Add("eo", eo);
                }
                kala = new Word("kala");

                Dictionary.Add("kala", kala);
                Glosses.Add("kala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "sound", "noise", "voice" });
                    en.Add("vt", new[] { "make noise" });
                    en.Add("vi", new[] { "sound", "ring", "play" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "sono", "bruo", "voĉo" });
                    eo.Add("vt", new[] { "sonigi", "ludi" });
                    eo.Add("vi", new[] { "soni", "brui", "sonori" });

                    glossMap.Add("eo", eo);
                }
                kalama = new Word("kalama");

                Dictionary.Add("kalama", kalama);
                Glosses.Add("kalama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "event", "happening", "chance", "arrival", "beginning" });
                    en.Add("adj", new[] { "coming", "future" });
                    en.Add("vt", new[] { "come", "become", "arrive", "happen", "pursue actions to arrive to (a certain state)", "manage to", "start to" });
                    en.Add("vi", new[] { "bring about", "summon", "come up" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "evento", "okazo", "hazardo", "veno", "komenco" });
                    eo.Add("adj", new[] { "venanta", "estonta" });
                    eo.Add("vt", new[] { "veni", "iĝi", "aperi", "alveni", "okazi", "agi por veni al (iu stato)", "sukcesi", "ek" });
                    eo.Add("vi", new[] { "venigi" });

                    glossMap.Add("eo", eo);
                }
                kama = new Word("kama");

                Dictionary.Add("kama", kama);
                Glosses.Add("kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "plant", "leaf", "herb", "tree", "wood" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "planto", "folio", "herbo", "arbo", "ligno" });

                    glossMap.Add("eo", eo);
                }
                kasi = new Word("kasi");

                Dictionary.Add("kasi", kasi);
                Glosses.Add("kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "possibility", "ability", "power to do things", "permission" });
                    en.Add("vt", new[] { "can", "is able to", "is allowed to", "may", "is possible" });
                    en.Add("vi", new[] { "make possible", "enable", "allow", "permit" });
                    en.Add("conditional", new[] { "it is possible that", "maybe" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "povo", "kapablo", "rajto" });
                    eo.Add("vt", new[] { "povi", "kapabli", "rajti" });
                    eo.Add("vi", new[] { "ebligi", "rajtigi", "permesi" });
                    eo.Add("conditional", new[] { "eblas", "ke" });

                    glossMap.Add("eo", eo);
                }
                ken = new Word("ken");

                Dictionary.Add("ken", ken);
                Glosses.Add("ken", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("vt", new[] { "use" });
                    en.Add("prep", new[] { "with" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("vt", new[] { "uzi" });
                    eo.Add("prep", new[] { "per" });

                    glossMap.Add("eo", eo);
                }
                kepeken = new Word("kepeken");

                Dictionary.Add("kepeken", kepeken);
                Glosses.Add("kepeken", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "fruit", "pulpy vegetable", "mushroom" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "frukto", "pulpa legomo", "fungo" });

                    glossMap.Add("eo", eo);
                }
                kili = new Word("kili");

                Dictionary.Add("kili", kili);
                Glosses.Add("kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "also", "too", "even", "indeed" });
                    en.Add("adv", new[] { "also", "too", "even", "indeed" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "ankaŭ", "eĉ", "ja" });
                    eo.Add("adv", new[] { "ankaŭ", "eĉ", "ja" });
                    eo.Add("conditional", new[] { "indeed" });

                    glossMap.Add("eo", eo);
                }
                kin = new Word("kin");

                Dictionary.Add("kin", kin);
                Glosses.Add("kin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "to cut" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "???" });

                    glossMap.Add("eo", eo);
                }
                kipisi = new Word("kipisi");

                Dictionary.Add("kipisi", kipisi);
                Glosses.Add("kipisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "hard thing", "rock", "stone", "metal", "mineral", "clay" });
                    en.Add("adj", new[] { "hard", "solid", "stone-like", "made of stone", "made of metal" });
                    en.Add("adv", new[] { "solidly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "malmolaĵo", "ŝtono", "metalo", "mineralo", "argilo" });
                    eo.Add("adj", new[] { "malmola", "dura", "solida", "ŝton(ec)a", "metala" });
                    eo.Add("adv", new[] { "malmole", "solide" });

                    glossMap.Add("eo", eo);
                }
                kiwen = new Word("kiwen");

                Dictionary.Add("kiwen", kiwen);
                Glosses.Add("kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "semi-solid or squishy substance", "e.g. paste", "powder", "gum" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "duonsolida aŭ premebla substanco", "ekz. pasto", "pulvoro", "gumo" });

                    glossMap.Add("eo", eo);
                }
                ko = new Word("ko");

                Dictionary.Add("ko", ko);
                Glosses.Add("ko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "air", "wind", "smell", "soul" });
                    en.Add("adj", new[] { "air-like", "ethereal", "gaseous" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "aero", "vento", "odoro", "animo" });
                    eo.Add("adj", new[] { "aera", "gasa" });

                    glossMap.Add("eo", eo);
                }
                kon = new Word("kon");

                Dictionary.Add("kon", kon);
                Glosses.Add("kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "colour", "paint" });
                    en.Add("adj", new[] { "colourful" });
                    en.Add("vt", new[] { "colour", "paint" });
                    en.Add("adv", new[] { "colourfully" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "koloro", "farbo" });
                    eo.Add("adj", new[] { "kolora", "bunta" });
                    eo.Add("vt", new[] { "kolori", "farbi" });
                    eo.Add("adv", new[] { "kolore", "bunte" });

                    glossMap.Add("eo", eo);
                }
                kule = new Word("kule");

                Dictionary.Add("kule", kule);
                Glosses.Add("kule", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "auditory", "hearing" });
                    en.Add("vt", new[] { "listen", "hear" });
                    en.Add("adv", new[] { "audibly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "aŭda", "aŭskulta" });
                    eo.Add("vt", new[] { "aŭskulti", "aŭdi" });
                    eo.Add("adv", new[] { "aŭde", "aŭskulte" });

                    glossMap.Add("eo", eo);
                }
                kute = new Word("kute");

                Dictionary.Add("kute", kute);
                Glosses.Add("kute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "group", "community", "society", "company", "people" });
                    en.Add("adj", new[] { "communal", "shared", "public", "of the society" });
                    en.Add("adv", new[] { "communally", "publicly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "grupo", "komunumo", "socio", "firmao", "popolo" });
                    eo.Add("adj", new[] { "komuna", "publika", "socia" });
                    eo.Add("adv", new[] { "komune", "publike", "socie" });

                    glossMap.Add("eo", eo);
                }
                kulupu = new Word("kulupu");

                Dictionary.Add("kulupu", kulupu);
                Glosses.Add("kulupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                la = new Word("la");

                Dictionary.Add("la", la);
                Glosses.Add("la", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "sleep", "rest" });
                    en.Add("adj", new[] { "sleeping", "of sleep" });
                    en.Add("vi", new[] { "sleep", "rest" });
                    en.Add("adv", new[] { "sleepily" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "dormo", "ripozo" });
                    eo.Add("adj", new[] { "dorma", "ripoza" });
                    eo.Add("vi", new[] { "dormi", "ripozi a dormanta", "dorma", "ripoza" });
                    eo.Add("adv", new[] { "dorme", "ripoze" });

                    glossMap.Add("eo", eo);
                }
                lape = new Word("lape");

                Dictionary.Add("lape", lape);
                Glosses.Add("lape", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "blue", "blue-green" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "blua", "bluverda" });

                    glossMap.Add("eo", eo);
                }
                laso = new Word("laso");

                Dictionary.Add("laso", laso);
                Glosses.Add("laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "head", "mind" });
                    en.Add("adj", new[] { "main", "leading", "in charge" });
                    en.Add("vt", new[] { "lead", "control", "rule", "steer" });
                    en.Add("adv", new[] { "mainly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "kapo", "menso" });
                    eo.Add("adj", new[] { "ĉefa", "estra" });
                    eo.Add("vt", new[] { "estri", "regi" });
                    eo.Add("adv", new[] { "ĉefe", "estre" });

                    glossMap.Add("eo", eo);
                }
                lawa = new Word("lawa");

                Dictionary.Add("lawa", lawa);
                Glosses.Add("lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "clothing", "cloth", "fabric" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "vesto(j)", "vestaĵo", "ŝtofo" });

                    glossMap.Add("eo", eo);
                }
                len = new Word("len");

                Dictionary.Add("len", len);
                Glosses.Add("len", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "cold" });
                    en.Add("adj", new[] { "cold", "uncooked" });
                    en.Add("vt", new[] { "cool down", "chill" });
                    en.Add("adv", new[] { "coldly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "malvarmo" });
                    eo.Add("adj", new[] { "malvarma", "frida", "nekuirita" });
                    eo.Add("vt", new[] { "malvarmigi" });
                    eo.Add("adv", new[] { "malvarme", "fride" });

                    glossMap.Add("eo", eo);
                }
                lete = new Word("lete");

                Dictionary.Add("lete", lete);
                Glosses.Add("lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                li = new Word("li");

                Dictionary.Add("li", li);
                Glosses.Add("li", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "small", "little", "young", "a bit", "short", "few", "less" });
                    en.Add("vt", new[] { "reduce", "shorten", "shrink", "lessen" });
                    en.Add("adv", new[] { "little", "a bit", "less" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "malgranda", "eta", "juna", "iomete", "mallonga", "malalta", "malmulte", "malpli" });
                    eo.Add("vt", new[] { "malpliigi", "mallongigi", "malgrandigi" });
                    eo.Add("adv", new[] { "iomete", "malmulte", "malpli" });

                    glossMap.Add("eo", eo);
                }
                lili = new Word("lili");

                Dictionary.Add("lili", lili);
                Glosses.Add("lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "long", "very thin", "floppy thing", "string", "rope", "hair", "thread", "cord", "chain" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "longa", "tre maldika", "malfirma objekto", "ŝnuro", "haro(j)", "ĉeno" });

                    glossMap.Add("eo", eo);
                }
                linja = new Word("linja");

                Dictionary.Add("linja", linja);
                Glosses.Add("linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "flat and bendable thing", "paper", "card", "ticket" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "plata kaj faldebla objekto", "papero", "karto", "bileto" });

                    glossMap.Add("eo", eo);
                }
                lipu = new Word("lipu");

                Dictionary.Add("lipu", lipu);
                Glosses.Add("lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "red" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "ruĝa" });

                    glossMap.Add("eo", eo);
                }
                loje = new Word("loje");

                Dictionary.Add("loje", loje);
                Glosses.Add("loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("vi", new[] { "be there", "be present", "be real/true", "exist", "be awake" });
                    en.Add("prep", new[] { "be (located) in/at/on" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("vi", new[] { "ĉeesti", "esti tie", "veri", "ekzisti", "esti veka" });
                    eo.Add("prep", new[] { "esti en", "ĉe", "sur", "je" });

                    glossMap.Add("eo", eo);
                }
                lon = new Word("lon");

                Dictionary.Add("lon", lon);
                Glosses.Add("lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "hand", "arm" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "mano", "brako" });

                    glossMap.Add("eo", eo);
                }
                luka = new Word("luka");

                Dictionary.Add("luka", luka);
                Glosses.Add("luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "visual", "visually" });
                    en.Add("vt", new[] { "see", "look at", "watch", "read" });
                    en.Add("vi", new[] { "look", "watch out", "pay attention" });
                    en.Add("adv", new[] { "visually" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "vida", "vide" });
                    eo.Add("vt", new[] { "vidi", "rigardi", "spekti", "observi", "legi" });
                    eo.Add("vi", new[] { "rigardi", "atenti" });
                    eo.Add("adv", new[] { "vide" });

                    glossMap.Add("eo", eo);
                }
                lukin = new Word("lukin");

                Dictionary.Add("lukin", lukin);
                Glosses.Add("lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "hole", "orifice", "window", "door" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "truo", "aperturo", "orifico", "fenestro", "pordo" });

                    glossMap.Add("eo", eo);
                }
                lupa = new Word("lupa");

                Dictionary.Add("lupa", lupa);
                Glosses.Add("lupa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "land", "earth", "country", "outdoor area", "area" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "tero", "lando", "ekstera tereno", "tereno" });

                    glossMap.Add("eo", eo);
                }
                ma = new Word("ma");

                Dictionary.Add("ma", ma);
                Glosses.Add("ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "parent", "mother", "father" });
                    en.Add("adj", new[] { "of the parent", "parental", "maternal", "fatherly" });
                    en.Add("adv", new[] { "maternally", "fatherly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "patrino", "patro" });
                    eo.Add("adj", new[] { "gepatra", "patra", "patrina" });
                    eo.Add("adv", new[] { "gepatre", "patre", "patrine" });

                    glossMap.Add("eo", eo);
                }
                mama = new Word("mama");

                Dictionary.Add("mama", mama);
                Glosses.Add("mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "money", "material wealth", "currency", "dollar", "capital" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "mono", "materia havaĵo", "valuto", "dolaro", "kapitalo" });

                    glossMap.Add("eo", eo);
                }
                mani = new Word("mani");

                Dictionary.Add("mani", mani);
                Glosses.Add("mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "woman", "female", "girl", "wife", "girlfriend" });
                    en.Add("adj", new[] { "female", "feminine", "womanly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ino", "virino", "edzino", "koramikino", "femalo" });
                    eo.Add("adj", new[] { "ina", "ineca" });

                    glossMap.Add("eo", eo);
                }
                meli = new Word("meli");

                Dictionary.Add("meli", meli);
                Glosses.Add("meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "I", "we" });
                    en.Add("adj", new[] { "my", "our" });
                    en.Add("pronoun", new[] { "I", "we" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "mi", "ni" });
                    eo.Add("adj", new[] { "mia", "nia" });

                    glossMap.Add("eo", eo);
                }
                mi = new Word("mi");

                Dictionary.Add("mi", mi);
                Glosses.Add("mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "man", "male", "boy", "husband", "boyfriend" });
                    en.Add("adj", new[] { "male", "masculine", "manly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "viro", "edzo", "masklo" });
                    eo.Add("adj", new[] { "vira", "vireca" });

                    glossMap.Add("eo", eo);
                }
                mije = new Word("mije");

                Dictionary.Add("mije", mije);
                Glosses.Add("mije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "food", "meal" });
                    en.Add("vt", new[] { "eat", "drink", "swallow", "ingest", "consume" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "manĝo", "manĝaĵo" });
                    eo.Add("vt", new[] { "manĝi", "trinki", "gluti", "enstomakigi", "konsumi" });

                    glossMap.Add("eo", eo);
                }
                moku = new Word("moku");

                Dictionary.Add("moku", moku);
                Glosses.Add("moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "death" });
                    en.Add("adj", new[] { "dead", "deadly", "fatal" });
                    en.Add("vt", new[] { "kill" });
                    en.Add("vi", new[] { "die", "be dead" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "morto" });
                    eo.Add("adj", new[] { "morta", "mortiga" });
                    eo.Add("vt", new[] { "mortigi" });
                    eo.Add("vi", new[] { "morti", "esti morta" });

                    glossMap.Add("eo", eo);
                }
                moli = new Word("moli");

                Dictionary.Add("moli", moli);
                Glosses.Add("moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "back", "rear end", "butt", "behind" });
                    en.Add("adj", new[] { "back", "rear" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "dorso", "malantaŭo", "pugo" });
                    eo.Add("adj", new[] { "dorsa", "malantaŭa" });

                    glossMap.Add("eo", eo);
                }
                monsi = new Word("monsi");

                Dictionary.Add("monsi", monsi);
                Glosses.Add("monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "sound", "noise" });
                    en.Add("vt", new[] { "make a noise like" });
                    en.Add("vi", new[] { "to bellow" });
                    en.Add("interj", new[] { "woof! meow! moo!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("interj", new[] { "blek! ŭa! miaŭ! ra!" });

                    glossMap.Add("eo", eo);
                }
                mu = new Word("mu");

                Dictionary.Add("mu", mu);
                Glosses.Add("mu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "moon" });
                    en.Add("adj", new[] { "lunar" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "luno" });
                    eo.Add("adj", new[] { "luna" });

                    glossMap.Add("eo", eo);
                }
                mun = new Word("mun");

                Dictionary.Add("mun", mun);
                Glosses.Add("mun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "fun", "playing", "game", "recreation", "art", "entertainment" });
                    en.Add("adj", new[] { "artful", "fun", "recreational" });
                    en.Add("vt", new[] { "amuse", "entertain" });
                    en.Add("vi", new[] { "play", "have fun" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "amuzo", "ludo", "distaĵo", "arto" });
                    eo.Add("adj", new[] { "arta", "amuza", "distra", "luda" });
                    eo.Add("vt", new[] { "amuzi", "distri" });
                    eo.Add("vi", new[] { "ludi", "amuziĝi" });

                    glossMap.Add("eo", eo);
                }
                musi = new Word("musi");

                Dictionary.Add("musi", musi);
                Glosses.Add("musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "amount", "quantity" });
                    en.Add("adj", new[] { "many", "very", "much", "several", "a lot", "abundant", "numerous", "more" });
                    en.Add("vt", new[] { "make many", "make much" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "kvanto", "multo", "kiomo" });
                    eo.Add("adj", new[] { "multaj", "tre", "pluraj", "multe", "pli da" });
                    eo.Add("vt", new[] { "multigi" });

                    glossMap.Add("eo", eo);
                }
                mute = new Word("mute");

                Dictionary.Add("mute", mute);
                Glosses.Add("mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "extra", "addtional", "spice" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                namako = new Word("namako");

                Dictionary.Add("namako", namako);
                Glosses.Add("namako", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "number" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "numero" });

                    glossMap.Add("eo", eo);
                }
                nanpa = new Word("nanpa");

                Dictionary.Add("nanpa", nanpa);
                Glosses.Add("nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "silly", "crazy", "foolish", "drunk", "strange", "stupid", "weird" });
                    en.Add("vt", new[] { "drive crazy", "make weird" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "freneza", "stulta", "ebria", "stranga" });
                    eo.Add("vt", new[] { "frenezigi", "strangigi" });

                    glossMap.Add("eo", eo);
                }
                nasa = new Word("nasa");

                Dictionary.Add("nasa", nasa);
                Glosses.Add("nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "way", "manner", "custom", "road", "path", "doctrine", "system", "method" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "maniero", "vojo", "strato", "kutimo", "-ismo", "sistemo", "metodo" });

                    glossMap.Add("eo", eo);
                }
                nasin = new Word("nasin");

                Dictionary.Add("nasin", nasin);
                Glosses.Add("nasin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "bump", "nose", "hill", "mountain", "button" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "elstaraĵo", "nazo", "monto", "monteto", "butono" });

                    glossMap.Add("eo", eo);
                }
                nena = new Word("nena");

                Dictionary.Add("nena", nena);
                Glosses.Add("nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "this", "that" });
                    en.Add("noun", new[] { "this", "that" });
                    en.Add("pronoun", new[] { "this", "that" });
                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "tiu", "ĉi tiu", "ĉi-", "jena" });

                    glossMap.Add("eo", eo);
                }
                ni = new Word("ni");

                Dictionary.Add("ni", ni);
                Glosses.Add("ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "word", "name" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "vorto", "nomo" });

                    glossMap.Add("eo", eo);
                }
                nimi = new Word("nimi");

                Dictionary.Add("nimi", nimi);
                Glosses.Add("nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "leg", "foot" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "kruro", "gambo", "piedo" });

                    glossMap.Add("eo", eo);
                }
                noka = new Word("noka");

                Dictionary.Add("noka", noka);
                Glosses.Add("noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("interj", new[] { "hey!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("interj", new[] { "he!" });

                    glossMap.Add("eo", eo);
                }
                o = new Word("o");

                Dictionary.Add("o", o);
                Glosses.Add("o", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "eye" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "okulo" });

                    glossMap.Add("eo", eo);
                }
                oko = new Word("oko");

                Dictionary.Add("oko", oko);
                Glosses.Add("oko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "love" });
                    en.Add("adj", new[] { "love" });
                    en.Add("vt", new[] { "to love" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "amount", "quantity" });
                    eo.Add("adj", new[] { "ama" });
                    eo.Add("vt", new[] { "ami" });

                    glossMap.Add("eo", eo);
                }
                olin = new Word("olin");

                Dictionary.Add("olin", olin);
                Glosses.Add("olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "she", "he", "it", "they" });
                    en.Add("adj", new[] { "her", "his", "its", "their" });
                    en.Add("pronoun", new[] { "he", "she", "it", "they" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ŝi", "li", "ĝi", "ili" });
                    eo.Add("adj", new[] { "ŝia", "lia", "ĝia", "ilia" });
                    eo.Add("pronoun", new[] { "ŝi", "li", "ĝi", "ili" });

                    glossMap.Add("eo", eo);
                }
                ona = new Word("ona");

                Dictionary.Add("ona", ona);
                Glosses.Add("ona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("vt", new[] { "open", "turn on" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("vt", new[] { "malfermi", "ŝalti" });

                    glossMap.Add("eo", eo);
                }
                open = new Word("open");

                Dictionary.Add("open", open);
                Glosses.Add("open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "blunder", "accident", "mistake", "destruction", "damage", "breaking" });
                    en.Add("vt", new[] { "screw up", "fuck up", "botch", "ruin", "break", "hurt", "injure", "damage", "spoil", "ruin" });
                    en.Add("vi", new[] { "screw up", "fall apart", "break" });
                    en.Add("interj", new[] { "damn! fuck!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "fuŝo", "akcidento", "katastrofo", "detruo", "eraro", "damaĝo", "rompo" });
                    eo.Add("vt", new[] { "fuŝiĝi", "disfali", "rompiĝi" });
                    eo.Add("vi", new[] { "fuŝi", "rompi", "vundi", "damaĝi" });
                    eo.Add("interj", new[] { "fek!" });

                    glossMap.Add("eo", eo);
                }
                pakala = new Word("pakala");

                Dictionary.Add("pakala", pakala);
                Glosses.Add("pakala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "activity", "work", "deed", "project" });
                    en.Add("adj", new[] { "active", "work-related", "operating", "working" });
                    en.Add("vt", new[] { "do", "make", "build", "create" });
                    en.Add("vi", new[] { "act", "work", "function" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "agado", "ag(ad)o", "laboro", "faro", "projekto" });
                    eo.Add("adj", new[] { "aga", "labora", "aktiva", "funkcia" });
                    eo.Add("vt", new[] { "fari", "konstrui", "krei" });
                    eo.Add("vi", new[] { "agi", "labori", "funkcii" });

                    glossMap.Add("eo", eo);
                }
                pali = new Word("pali");

                Dictionary.Add("pali", pali);
                Glosses.Add("pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "long and hard object", "rod", "stick", "branch" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "longa kaj  malmola objekto", "stango", "bastono", "branĉo", "vergo" });

                    glossMap.Add("eo", eo);
                }
                palisa = new Word("palisa");

                Dictionary.Add("palisa", palisa);
                Glosses.Add("palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "grain", "cereal", "bread" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "???" });

                    glossMap.Add("eo", eo);
                }
                pan = new Word("pan");

                Dictionary.Add("pan", pan);
                Glosses.Add("pan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "giving", "transfer", "exchange" });
                    en.Add("vt", new[] { "give", "put", "send", "place", "release", "emit", "cause" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "dono", "sendado", "interŝanĝo" });
                    eo.Add("vt", new[] { "doni", "meti", "sendi", "eligi", "kaŭzi" });

                    glossMap.Add("eo", eo);
                }
                pana = new Word("pana");

                Dictionary.Add("pana", pana);
                Glosses.Add("pana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "brother" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "???" });

                    glossMap.Add("eo", eo);
                }
                pata = new Word("pata");

                Dictionary.Add("pata", pata);
                Glosses.Add("pata", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                pi = new Word("pi");

                Dictionary.Add("pi", pi);
                Glosses.Add("pi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "feelings", "emotion", "heart" });
                    en.Add("vt", new[] { "feel", "think", "sense", "touch" });
                    en.Add("vi", new[] { "feel" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "sentoj", "emocio", "koro" });
                    eo.Add("vt", new[] { "senti", "opinii", "pensi", "sensi", "tuŝi", "palpi" });
                    eo.Add("vi", new[] { "senti sin" });

                    glossMap.Add("eo", eo);
                }
                pilin = new Word("pilin");

                Dictionary.Add("pilin", pilin);
                Glosses.Add("pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "darkness", "shadows" });
                    en.Add("adj", new[] { "black", "dark" });
                    en.Add("vt", new[] { "darken" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "mallumo", "nigro" });
                    eo.Add("adj", new[] { "nigra", "malluma", "malhela" });
                    eo.Add("vt", new[] { "mallumigi" });

                    glossMap.Add("eo", eo);
                }
                pimeja = new Word("pimeja");

                Dictionary.Add("pimeja", pimeja);
                Glosses.Add("pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "end", "tip" });
                    en.Add("adj", new[] { "completed", "finished", "past", "done", "ago" });
                    en.Add("vt", new[] { "finish", "close", "end", "turn off" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "fino", "ekstremo", "pinto" });
                    eo.Add("adj", new[] { "fina", "finita", "pasinta", "farita", "antaŭ" });
                    eo.Add("vt", new[] { "fini", "fermi", "malŝalti" });

                    glossMap.Add("eo", eo);
                }
                pini = new Word("pini");

                Dictionary.Add("pini", pini);
                Glosses.Add("pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "bug", "insect", "spider" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "insekto", "araneo" });

                    glossMap.Add("eo", eo);
                }
                pipi = new Word("pipi");

                Dictionary.Add("pipi", pipi);
                Glosses.Add("pipi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "side", "hip", "area next to" });
                    en.Add("adj", new[] { "neighbouring" });
                    en.Add("prep", new[] { "in the accompaniment of", "with" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "flanko", "kokso", "apudo" });
                    eo.Add("adj", new[] { "apuda", "najbara" });
                    eo.Add("prep", new[] { "en la akompano de", "kun" });

                    glossMap.Add("eo", eo);
                }
                poka = new Word("poka");

                Dictionary.Add("poka", poka);
                Glosses.Add("poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "container", "box", "bowl", "cup", "glass" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ujo", "skatolo", "bovlo", "taso", "glaso" });

                    glossMap.Add("eo", eo);
                }
                poki = new Word("poki");

                Dictionary.Add("poki", poki);
                Glosses.Add("poki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "good", "simplicity", "positivity" });
                    en.Add("adj", new[] { "good", "simple", "positive", "nice", "correct", "right" });
                    en.Add("vt", new[] { "improve", "fix", "repair", "make good" });
                    en.Add("interj", new[] { "great! good! thanks! OK! cool! yay!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "bona", "simplo", "pozitivo" });
                    eo.Add("adj", new[] { "bona", "simpla", "pozitiva", "afabla", "ĝusta" });
                    eo.Add("vt", new[] { "bonigi", "plibonigi", "ripari" });
                    eo.Add("interj", new[] { "bone! bonege! dankon! en ordo!" });

                    glossMap.Add("eo", eo);
                }
                pona = new Word("pona");

                Dictionary.Add("pona", pona);
                Glosses.Add("pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "same", "similar", "equal", "of equal status or position" });
                    en.Add("prep", new[] { "like", "as", "seem" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "sama", "simila", "egala", "samgrava", "samsituacia" });
                    eo.Add("prep", new[] { "kiel", "ŝajni" });

                    glossMap.Add("eo", eo);
                }
                sama = new Word("sama");

                Dictionary.Add("sama", sama);
                Glosses.Add("sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "fire", "warmth", "heat" });
                    en.Add("adj", new[] { "hot", "warm", "cooked" });
                    en.Add("vt", new[] { "heat", "warm up", "cook" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "fajro", "varmo" });
                    eo.Add("adj", new[] { "varma", "kuirita" });
                    eo.Add("vt", new[] { "varmigi", "kuiri" });

                    glossMap.Add("eo", eo);
                }
                seli = new Word("seli");

                Dictionary.Add("seli", seli);
                Glosses.Add("seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "outside", "surface", "skin", "shell", "bark", "shape", "peel" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ekstero", "supraĵo", "haŭto", "ŝelo", "formo" });

                    glossMap.Add("eo", eo);
                }
                selo = new Word("selo");

                Dictionary.Add("selo", selo);
                Glosses.Add("selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pronoun", new[] { "what", "which" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("pronoun", new[] { "ki-x" });

                    glossMap.Add("eo", eo);
                }
                seme = new Word("seme");

                Dictionary.Add("seme", seme);
                Glosses.Add("seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "high", "up", "above", "top", "over", "on" });
                    en.Add("adj", new[] { "superior", "elevated", "religious", "formal" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "alto", "supro", "supero", "suro" });
                    eo.Add("adj", new[] { "supera", "alta", "nobla", "religia", "formala" });

                    glossMap.Add("eo", eo);
                }
                sewi = new Word("sewi");

                Dictionary.Add("sewi", sewi);
                Glosses.Add("sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "body", "physical state" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "korpo", "fizika stato" });

                    glossMap.Add("eo", eo);
                }
                sijelo = new Word("sijelo");

                Dictionary.Add("sijelo", sijelo);
                Glosses.Add("sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "circle", "wheel", "sphere", "ball", "cycle" });
                    en.Add("adj", new[] { "round", "cyclical" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "rondo", "cirklo", "rado", "sfero", "bulo", "pilko", "cikloronda", "cikla" });
                    eo.Add("adj", new[] { "ronda", "cikla" });

                    glossMap.Add("eo", eo);
                }
                sike = new Word("sike");

                Dictionary.Add("sike", sike);
                Glosses.Add("sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "new", "fresh", "another", "more" });
                    en.Add("vt", new[] { "renew", "renovate", "freshen" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "nova", "freŝa", "alia", "ankorŭ (da)" });
                    eo.Add("vt", new[] { "novigi", "renovigi" });

                    glossMap.Add("eo", eo);
                }
                sin = new Word("sin");

                Dictionary.Add("sin", sin);
                Glosses.Add("sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "you" });
                    en.Add("adj", new[] { "your" });
                    en.Add("pronoun", new[] { "you" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "vi" });
                    eo.Add("adj", new[] { "via" });
                    eo.Add("pronoun", new[] { "vi" });

                    glossMap.Add("eo", eo);
                }
                sina = new Word("sina");

                Dictionary.Add("sina", sina);
                Glosses.Add("sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "front", "chest", "torso", "face", "wall" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "antaŭo", "brusto", "torso", "vizaĝo", "muro" });

                    glossMap.Add("eo", eo);
                }
                sinpin = new Word("sinpin");

                Dictionary.Add("sinpin", sinpin);
                Glosses.Add("sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "picture", "image" });
                    en.Add("vt", new[] { "draw", "write" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "bildo", "foto", "imago", "desegno" });
                    eo.Add("vt", new[] { "desegni", "skribi" });

                    glossMap.Add("eo", eo);
                }
                sitelen = new Word("sitelen");

                Dictionary.Add("sitelen", sitelen);
                Glosses.Add("sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "knowledge", "wisdom", "intelligence", "understanding" });
                    en.Add("vt", new[] { "know", "understand", "know how to" });
                    en.Add("vi", new[] { "know", "understand" });
                    en.Add("kama", new[] { "learn", "study" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "scioj", "saĝeco", "inteligenteco", "kompreno" });
                    eo.Add("vt", new[] { "scii", "kompreni", "koni" });
                    eo.Add("vi", new[] { "scii", "kompreni" });
                    eo.Add("kama", new[] { "lerni", "studi" });

                    glossMap.Add("eo", eo);
                }
                sona = new Word("sona");

                Dictionary.Add("sona", sona);
                Glosses.Add("sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "animal", "land mammal", "lovable animal" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "besto", "tera mambesto", "aminda besto" });

                    glossMap.Add("eo", eo);
                }
                soweli = new Word("soweli");

                Dictionary.Add("soweli", soweli);
                Glosses.Add("soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "size" });
                    en.Add("adj", new[] { "big", "tall", "long", "adult", "important" });
                    en.Add("vt", new[] { "enlarge", "lengthen" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "grandeco" });
                    eo.Add("adj", new[] { "granda", "alta", "longa", "plenaĝa", "grava" });
                    eo.Add("vt", new[] { "grandigi", "longigi" });

                    glossMap.Add("eo", eo);
                }
                suli = new Word("suli");

                Dictionary.Add("suli", suli);
                Glosses.Add("suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "sun", "light" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "suno", "lumo" });

                    glossMap.Add("eo", eo);
                }
                suno = new Word("suno");

                Dictionary.Add("suno", suno);
                Glosses.Add("suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "horizontal surface", "furniture", "table", "chair", "pillow", "floor" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "horizontala supraĵo", "meblo", "tablo", "seĝo", "kuseno", "planko" });

                    glossMap.Add("eo", eo);
                }
                supa = new Word("supa");

                Dictionary.Add("supa", supa);
                Glosses.Add("supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "candy", "sweet food" });
                    en.Add("adj", new[] { "sweet", "cute" });
                    en.Add("vt", new[] { "sweeten" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "dolĉaĵo" });
                    eo.Add("adj", new[] { "dolĉa", "aminda" });
                    eo.Add("vt", new[] { "dolĉigi" });

                    glossMap.Add("eo", eo);
                }
                suwi = new Word("suwi");

                Dictionary.Add("suwi", suwi);
                Glosses.Add("suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "origin", "cause" });
                    en.Add("prep", new[] { "from", "by", "because of", "since" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "deveno", "kialo", "origino" });
                    eo.Add("prep", new[] { "de", "pro", "el" });

                    glossMap.Add("eo", eo);
                }
                tan = new Word("tan");

                Dictionary.Add("tan", tan);
                Glosses.Add("tan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "only", "sole" });
                    en.Add("conj", new[] { "but" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("adj", new[] { "nur", "nura", "sola" });
                    eo.Add("conj", new[] { "sed" });

                    glossMap.Add("eo", eo);
                }
                taso = new Word("taso");

                Dictionary.Add("taso", taso);
                Glosses.Add("taso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "movement", "transportation" });
                    en.Add("adj", new[] { "moving", "mobile" });
                    en.Add("vt", new[] { "move", "displace" });
                    en.Add("vi", new[] { "go to", "walk", "travel", "move", "leave" });
                    en.Add("prep", new[] { "to", "in order to", "towards", "for", "until" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "movo", "transportado" });
                    eo.Add("adj", new[] { "mova" });
                    eo.Add("vt", new[] { "movi" });
                    eo.Add("vi", new[] { "iri al", "vojaĝi", "moviĝi", "foriri" });
                    eo.Add("prep", new[] { "al", "por", "ĝis" });

                    glossMap.Add("eo", eo);
                }
                tawa = new Word("tawa");

                Dictionary.Add("tawa", tawa);
                Glosses.Add("tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "water", "liquid", "juice", "sauce" });
                    en.Add("vt", new[] { "water", "wash with water" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "akvo", "likvaĵo", "suko", "saŭco" });
                    eo.Add("vt", new[] { "akvumi", "lavi per akvo" });

                    glossMap.Add("eo", eo);
                }
                telo = new Word("telo");

                Dictionary.Add("telo", telo);
                Glosses.Add("telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "time", "period of time", "moment", "duration", "situation" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "tempo", "tempoperiodo", "momento", "daŭro", "situacio" });

                    glossMap.Add("eo", eo);
                }
                tenpo = new Word("tenpo");

                Dictionary.Add("tenpo", tenpo);
                Glosses.Add("tenpo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "language", "talking", "speech", "communication" });
                    en.Add("adj", new[] { "talking", "verbal" });
                    en.Add("vt", new[] { "say" });
                    en.Add("vi", new[] { "talk", "chat", "communicate" });
                    en.Add("interj", new[] { "hello! hi!" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "lingvo", "parolado", "komunikado" });
                    eo.Add("adj", new[] { "parola", "lingva", "komunika" });
                    eo.Add("vt", new[] { "diri" });
                    eo.Add("vi", new[] { "paroli", "babili", "komuniki" });
                    eo.Add("interj", new[] { "saluton!" });

                    glossMap.Add("eo", eo);
                }
                toki = new Word("toki");

                Dictionary.Add("toki", toki);
                Glosses.Add("toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "indoor constructed space", "house", "home", "room", "building" });
                    en.Add("adj", new[] { "urban", "domestic", "household" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "interna konstruita spaco", "ekz. domo", "hejmo", "ĉambro", "konstruaĵ" });
                    eo.Add("adj", new[] { "urba", "doma", "hejma" });

                    glossMap.Add("eo", eo);
                }
                tomo = new Word("tomo");

                Dictionary.Add("tomo", tomo);
                Glosses.Add("tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "duo", "pair" });
                    en.Add("adj", new[] { "two" });
                    en.Add("vt", new[] { "double", "separate", "cut", "divide in two" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "duo", "paro" });
                    eo.Add("adj", new[] { "du" });
                    eo.Add("vt", new[] { "duobligi", "duigi", "dividi", "tranĉi en du" });

                    glossMap.Add("eo", eo);
                }
                tu = new Word("tu");

                Dictionary.Add("tu", tu);
                Glosses.Add("tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "sex", "sexuality" });
                    en.Add("adj", new[] { "erotic", "sexual" });
                    en.Add("vt", new[] { "have sex with", "sleep with", "fuck" });
                    en.Add("vi", new[] { "have sex" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "seksumo", "amoro", "fikado", "volupto" });
                    eo.Add("adj", new[] { "erotika", "seksuma", "amora" });
                    eo.Add("vt", new[] { "seksumi kun", "amori kun", "fiki" });
                    eo.Add("vi", new[] { "amori", "seksumi" });

                    glossMap.Add("eo", eo);
                }
                unpa = new Word("unpa");

                Dictionary.Add("unpa", unpa);
                Glosses.Add("unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "mouth" });
                    en.Add("adj", new[] { "oral" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "buŝo" });
                    eo.Add("adj", new[] { "buŝa" });

                    glossMap.Add("eo", eo);
                }
                uta = new Word("uta");

                Dictionary.Add("uta", uta);
                Glosses.Add("uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "conflict", "disharmony", "competition", "fight", "war", "battle", "attack", "blow", "argument", "physical or verbal violence" });
                    en.Add("vt", new[] { "hit", "strike", "attack", "compete against" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "konflikto", "malharmonio", "konkuro", "batalo", "milito", "atako", "disputo", "fizika aŭ verba perforto" });
                    eo.Add("vt", new[] { "bati", "frapi", "ataki", "konkuri kun", "atenci" });

                    glossMap.Add("eo", eo);
                }
                utala = new Word("utala");

                Dictionary.Add("utala", utala);
                Glosses.Add("utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "white thing or part", "whiteness", "lightness" });
                    en.Add("adj", new[] { "white", "light colored" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "blanko", "blankaĵo", "blankeco", "heleco" });
                    eo.Add("adj", new[] { "blanka", "hela" });

                    glossMap.Add("eo", eo);
                }
                walo = new Word("walo");

                Dictionary.Add("walo", walo);
                Glosses.Add("walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "unit", "element", "particle", "part", "piece" });
                    en.Add("adj", new[] { "one", "a" });
                    en.Add("vt", new[] { "unite", "make one" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "unuo", "elemento", "ero", "parto", "peco" });
                    eo.Add("adj", new[] { "unu", "iu" });
                    eo.Add("vt", new[] { "unuigi" });

                    glossMap.Add("eo", eo);
                }
                wan = new Word("wan");

                Dictionary.Add("wan", wan);
                Glosses.Add("wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "bird", "winged animal" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "birdo", "flugilhava besto" });

                    glossMap.Add("eo", eo);
                }
                waso = new Word("waso");

                Dictionary.Add("waso", waso);
                Glosses.Add("waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "energy", "strength", "power" });
                    en.Add("adj", new[] { "energetic", "strong", "fierce", "intense", "sure", "confident" });
                    en.Add("vt", new[] { "strengthen", "energize", "empower" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "energio", "potenco", "forto", "vigleco" });
                    eo.Add("adj", new[] { "energia", "forta", "intensa", "potenca", "certa", "memfida" });
                    eo.Add("vt", new[] { "fortigi", "vigligi" });

                    glossMap.Add("eo", eo);
                }
                wawa = new Word("wawa");

                Dictionary.Add("wawa", wawa);
                Glosses.Add("wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "absence" });
                    en.Add("adj", new[] { "away", "absent", "missing" });
                    en.Add("vt", new[] { "throw away", "remove", "get rid of" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "foresto", "manko" });
                    eo.Add("adj", new[] { "fora", "forestanta", "mankanta" });
                    eo.Add("vt", new[] { "forigi" });

                    glossMap.Add("eo", eo);
                }
                weka = new Word("weka");

                Dictionary.Add("weka", weka);
                Glosses.Add("weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "desire", "need", "will" });
                    en.Add("adj", new[] { "necessary" });
                    en.Add("vt", new[] { "to want", "need", "wish", "have to", "must", "will", "should" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "deziro", "bezono", "devo", "volo" });
                    eo.Add("adj", new[] { "necesa", "deviga", "bezonata" });
                    eo.Add("vt", new[] { "voli", "bezoni", "deziri", "devi" });

                    glossMap.Add("eo", eo);
                }
                wile = new Word("wile");

                Dictionary.Add("wile", wile);
                Glosses.Add("wile", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "bump", "nose", "hill", "mountain", "button" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "elstaraĵo", "nazo", "monto", "monteto", "butono" });

                    glossMap.Add("eo", eo);
                }
                kapa = new Word("kapa");

                Dictionary.Add("kapa", kapa);
                Glosses.Add("kapa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "she", "he", "it", "they" });
                    en.Add("adj", new[] { "her", "his", "its", "their" });
                    en.Add("pronoun", new[] { "he", "she", "it", "they" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ŝi", "li", "ĝi", "ili" });
                    eo.Add("adj", new[] { "ŝia", "lia", "ĝia", "ilia" });
                    eo.Add("pronoun", new[] { "ŝi", "li", "ĝi", "ili" });

                    glossMap.Add("eo", eo);
                }
                iki = new Word("iki");

                Dictionary.Add("iki", iki);
                Glosses.Add("iki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "side", "hip", "area next to" });
                    en.Add("adj", new[] { "neighbouring" });
                    en.Add("prep", new[] { "in the accompaniment of", "with" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "flanko", "kokso", "apudo" });
                    eo.Add("adj", new[] { "apuda", "najbara" });
                    eo.Add("prep", new[] { "en la akompano de", "kun" });

                    glossMap.Add("eo", eo);
                }
                kan = new Word("kan");

                Dictionary.Add("kan", kan);
                Glosses.Add("kan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "good", "simplicity", "positivity" });
                    en.Add("adj", new[] { "good", "simple", "positive", "nice", "correct", "right" });
                    en.Add("vt", new[] { "improve", "fix", "repair", "make good" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "bona", "simplo", "pozitivo" });
                    eo.Add("adj", new[] { "bona", "simpla", "pozitiva", "afabla", "ĝusta" });
                    eo.Add("vt", new[] { "bonigi", "plibonigi", "ripari" });

                    glossMap.Add("eo", eo);
                }
                pasila = new Word("pasila");

                Dictionary.Add("pasila", pasila);
                Glosses.Add("pasila", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "darkness", "shadows" });
                    en.Add("adj", new[] { "black", "dark" });
                    en.Add("vt", new[] { "darken" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "mallumo", "nigro" });
                    eo.Add("adj", new[] { "nigra", "malluma", "malhela" });
                    eo.Add("vt", new[] { "mallumigi" });

                    glossMap.Add("eo", eo);
                }
                kapesi = new Word("kapesi");

                Dictionary.Add("kapesi", kapesi);
                Glosses.Add("kapesi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "stairs" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                leko = new Word("leko");

                Dictionary.Add("leko", leko);
                Glosses.Add("leko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "old" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                majuno = new Word("majuno");

                Dictionary.Add("majuno", majuno);
                Glosses.Add("majuno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "three" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                tuli = new Word("tuli");

                Dictionary.Add("tuli", tuli);
                Glosses.Add("tuli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("adj", new[] { "four" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                po = new Word("po");

                Dictionary.Add("po", po);
                Glosses.Add("po", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "armadillo", "pangolin" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                kijetesantakalu = new Word("kijetesantakalu");

                Dictionary.Add("kijetesantakalu", kijetesantakalu);
                Glosses.Add("kijetesantakalu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "she", "he", "it", "they" });
                    en.Add("adj", new[] { "her", "his", "its", "their" });
                    en.Add("pronoun", new[] { "he", "she", "it", "they" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "ŝi", "li", "ĝi", "ili" });
                    eo.Add("adj", new[] { "ŝia", "lia", "ĝia", "ilia" });
                    eo.Add("pronoun", new[] { "ŝi", "li", "ĝi", "ili" });

                    glossMap.Add("eo", eo);
                }
                ipi = new Word("ipi");

                Dictionary.Add("ipi", ipi);
                Glosses.Add("ipi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "leg", "foot" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();
                    eo.Add("noun", new[] { "kruro", "gambo", "piedo" });

                    glossMap.Add("eo", eo);
                }
                jalan = new Word("jalan");

                Dictionary.Add("jalan", jalan);
                Glosses.Add("jalan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "toki pona text book" });
                    en.Add("vi", new[] { "study toki pona" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                pu = new Word("pu");

                Dictionary.Add("pu", pu);
                Glosses.Add("pu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "disparagement" });
                    en.Add("adj", new[] { "disparaging" });
                    en.Add("vt", new[] { "disparage" });
                    en.Add("adv", new[] { "disparagingly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                apeja = new Word("apeja");

                Dictionary.Add("apeja", apeja);
                Glosses.Add("apeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("vt", new[] { "block" });
                    en.Add("vi", new[] { "block" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                pake = new Word("pake");

                Dictionary.Add("pake", pake);
                Glosses.Add("pake", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();

                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("noun", new[] { "fear", "monster" });
                    en.Add("adj", new[] { "scary" });
                    en.Add("vt", new[] { "scare" });
                    en.Add("vi", new[] { "be scared" });
                    en.Add("adv", new[] { "frighteningly" });

                    glossMap.Add("en", en);
                }
                {
                    var eo = new Dictionary<string, string[]>();

                    glossMap.Add("eo", eo);
                }
                monsuta = new Word("monsuta");

                Dictionary.Add("monsuta", monsuta);
                Glosses.Add("monsuta", glossMap);
            }





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
