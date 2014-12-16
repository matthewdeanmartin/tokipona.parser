using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Esperanto.Tokens;
using NUnit.Framework;

namespace BasicTypes.Esperanto.Dictionary
{
    [TestFixture]
    public class RootDictionaryTests
    {
        [Test]
        public void Test()
        {
            foreach (string line in RootDictionary.Data.Split('\n'))
            {
                if(string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('/');
                string stem =parts[0].Trim();
                string english = parts[1].Trim();
                Console.WriteLine("//" + english );
                Console.WriteLine("public static EoRoot " + stem + " = new EoRoot(\"" + stem +"\");" );
            }
        }
    }
    public class RootDictionary
    {
        //absolute
    public static EoRoot absolut = new EoRoot("absolut");
    //suffix indicating dirtyness or contemptuousness
    public static EoRoot aĉ = new EoRoot("aĉ");
    //purchase, buy
    public static EoRoot aĉet = new EoRoot("aĉet");
    //suffix indicating continuousness
    public static EoRoot ad = new EoRoot("ad");
    //address (location)
    public static EoRoot adres = new EoRoot("adres");
    //affair, matter
    public static EoRoot afer = new EoRoot("afer");
    //Africa
    public static EoRoot afrik = new EoRoot("afrik");
    //action, act
    public static EoRoot ag = new EoRoot("ag");
    //age
    public static EoRoot aĝ = new EoRoot("aĝ");
    //suffix indicating thing, manifestation
    public static EoRoot aĵ = new EoRoot("aĵ");
    //particle used with i- and ki- correlatives to create constructions such as 'whenever' and 'anytime'
    public static EoRoot ajn = new EoRoot("ajn");
    //accept
    public static EoRoot akcept = new EoRoot("akcept");
    //water
    public static EoRoot akv = new EoRoot("akv");
    //preposition to
    public static EoRoot al = new EoRoot("al");
    //other
    public static EoRoot ali = new EoRoot("ali");
    //at least
    public static EoRoot almenaŭ = new EoRoot("almenaŭ");
    //height, tall
    public static EoRoot alt = new EoRoot("alt");
    //love
    public static EoRoot am = new EoRoot("am");
    //mass, throng, en masse
    public static EoRoot amas = new EoRoot("amas");
    //the Americas
    public static EoRoot amerik = new EoRoot("amerik");
    //friend
    public static EoRoot amik = new EoRoot("amik");
    //extensive
    public static EoRoot ampleks = new EoRoot("ampleks");
    //fun, amusement
    public static EoRoot amuz = new EoRoot("amuz");
    //suffix indicating membership
    public static EoRoot an = new EoRoot("an");
    //England
    public static EoRoot angl = new EoRoot("angl");
    //also
    public static EoRoot ankaŭ = new EoRoot("ankaŭ");
    //still
    public static EoRoot ankoraŭ = new EoRoot("ankoraŭ");
    //announcement
    public static EoRoot anonc = new EoRoot("anonc");
    //in stead of
    public static EoRoot anstataŭ = new EoRoot("anstataŭ");
    //suffix indicating present action or actor
    public static EoRoot ant = new EoRoot("ant");
    //before
    public static EoRoot antaŭ = new EoRoot("antaŭ");
    //apparatus, machine
    public static EoRoot aparat = new EoRoot("aparat");
    //separate
    public static EoRoot apart = new EoRoot("apart");
    //appear
    public static EoRoot aper = new EoRoot("aper");
    //suffix indicating collection
    public static EoRoot ar = new EoRoot("ar");
    //arrange
    public static EoRoot aranĝ = new EoRoot("aranĝ");
    //association (group)
    public static EoRoot asoci = new EoRoot("asoci");
    //have an appearance
    public static EoRoot aspekt = new EoRoot("aspekt");
    //suffix indicating present passive
    public static EoRoot at = new EoRoot("at");
    //wait
    public static EoRoot atend = new EoRoot("atend");
    //attention
    public static EoRoot atent = new EoRoot("atent");
    //attain
    public static EoRoot ating = new EoRoot("ating");
    //conjunction or
    public static EoRoot aŭ = new EoRoot("aŭ");
    //hear
    public static EoRoot aŭd = new EoRoot("aŭd");
    //listen
    public static EoRoot aŭskult = new EoRoot("aŭskult");
    //bus
    public static EoRoot aŭtobus = new EoRoot("aŭtobus");
    //car
    public static EoRoot aŭt = new EoRoot("aŭt");
    public static EoRoot aŭtomobil = new EoRoot("aŭtomobil");
    //grandparent
    public static EoRoot av = new EoRoot("av");
    //banana
    public static EoRoot banan = new EoRoot("banan");
    //battle
    public static EoRoot batal = new EoRoot("batal");
    //base, basis
    public static EoRoot baz = new EoRoot("baz");
    //regret
    public static EoRoot bedaŭr = new EoRoot("bedaŭr");
    //beautiful
    public static EoRoot bel = new EoRoot("bel");
    //tape
    public static EoRoot bend = new EoRoot("bend");
    //need
    public static EoRoot bezon = new EoRoot("bezon");
    //library (edifice)
    public static EoRoot bibliotek = new EoRoot("bibliotek");
    //picture
    public static EoRoot bild = new EoRoot("bild");
    //ticket
    public static EoRoot bilet = new EoRoot("bilet");
    //bird
    public static EoRoot bird = new EoRoot("bird");
    //good
    public static EoRoot bon = new EoRoot("bon");
    //bottle
    public static EoRoot botel = new EoRoot("botel");
    //Bulgaria
    public static EoRoot bulgar = new EoRoot("bulgar");
    //aim, goal
    public static EoRoot cel = new EoRoot("cel");
    //100
    public static EoRoot cent = new EoRoot("cent");
    //center
    public static EoRoot centr = new EoRoot("centr");
    //certain
    public static EoRoot cert = new EoRoot("cert");
    //remaining
    public static EoRoot ceter = new EoRoot("ceter");
    //cigarette
    public static EoRoot cigared = new EoRoot("cigared");
    //room
    public static EoRoot ĉambr = new EoRoot("ĉambr");
    //conjunction because
    public static EoRoot ĉar = new EoRoot("ĉar");
    //charming, quaint
    public static EoRoot ĉarm = new EoRoot("ĉarm");
    //preposition at
    public static EoRoot ĉe = new EoRoot("ĉe");
    //boss, main
    public static EoRoot ĉef = new EoRoot("ĉef");
    //horse
    public static EoRoot ĉeval = new EoRoot("ĉeval");
    //particle used with ti- correlatives to indicate nearness, like in here or this.
    public static EoRoot ĉi = new EoRoot("ĉi");
    //correlative always
    public static EoRoot ĉiam = new EoRoot("ĉiam");
    //China
    public static EoRoot ĉin = new EoRoot("ĉin");
    //correlative everything
    public static EoRoot ĉio = new EoRoot("ĉio");
    //preposition around
    public static EoRoot ĉirkaŭ = new EoRoot("ĉirkaŭ");
    //each
    public static EoRoot ĉiu = new EoRoot("ĉiu");
    //particle indicating yes or no question
    public static EoRoot ĉu = new EoRoot("ĉu");
    //preposition quantity of
    public static EoRoot da = new EoRoot("da");
    //Denmark
    public static EoRoot dan = new EoRoot("dan");
    //thank
    public static EoRoot dank = new EoRoot("dank");
    //last (duration)
    public static EoRoot daŭr = new EoRoot("daŭr");
    //preposition of
    public static EoRoot de = new EoRoot("de");
    //debate
    public static EoRoot debat = new EoRoot("debat");
    //decide
    public static EoRoot decid = new EoRoot("decid");
    //be on duty
    public static EoRoot deĵor = new EoRoot("deĵor");
    //10
    public static EoRoot dek = new EoRoot("dek");
    //right
    public static EoRoot dekstr = new EoRoot("dekstr");
    //delegation
    public static EoRoot delegaci = new EoRoot("delegaci");
    //ask
    public static EoRoot demand = new EoRoot("demand");
    //be obligated
    public static EoRoot dev = new EoRoot("dev");
    //desire
    public static EoRoot dezir = new EoRoot("dezir");
    //devil
    public static EoRoot diabl = new EoRoot("diabl");
    //define
    public static EoRoot difin = new EoRoot("difin");
    //say, tell
    public static EoRoot dir = new EoRoot("dir");
    //prefix indicating dispersion
    public static EoRoot dis = new EoRoot("dis");
    //discriminate
    public static EoRoot diskriminaci = new EoRoot("diskriminaci");
    //discuss
    public static EoRoot diskut = new EoRoot("diskut");
    //diverse
    public static EoRoot divers = new EoRoot("divers");
    //divide, share
    public static EoRoot divid = new EoRoot("divid");
    //particle for so
    public static EoRoot @do = new EoRoot("do");
    //house
    public static EoRoot dom = new EoRoot("dom");
    //give
    public static EoRoot don = new EoRoot("don");
    //gift
    public static EoRoot donac = new EoRoot("donac");
    //sleep
    public static EoRoot dorm = new EoRoot("dorm");
    //2
    public static EoRoot du = new EoRoot("du");
    //preposition during
    public static EoRoot dum = new EoRoot("dum");
    //suffix indicating possibility
    public static EoRoot ebl = new EoRoot("ebl");
    //suffix indicating abstract quality
    public static EoRoot ec = new EoRoot("ec");
    //particle even
    public static EoRoot eĉ = new EoRoot("eĉ");
    //spouse
    public static EoRoot edz = new EoRoot("edz");
    //suffix indicating largeness
    public static EoRoot eg = new EoRoot("eg");
    //suffix indicating location
    public static EoRoot ej = new EoRoot("ej");
    //prefix indicating either beginning or suddenness
    public static EoRoot ek = new EoRoot("ek");
    //prefix indicating former
    public static EoRoot eks = new EoRoot("eks");
    //excursion
    public static EoRoot ekskurs = new EoRoot("ekskurs");
    //preposition outside
    public static EoRoot ekster = new EoRoot("ekster");
    //example
    public static EoRoot ekzempl = new EoRoot("ekzempl");
    //individual copy
    public static EoRoot ekzempler = new EoRoot("ekzempler");
    //exist
    public static EoRoot ekzist = new EoRoot("ekzist");
    //prounoun from out of
    public static EoRoot el = new EoRoot("el");
    //select
    public static EoRoot elekt = new EoRoot("elekt");
    //preposition in
    public static EoRoot en = new EoRoot("en");
    //enterprise
    public static EoRoot entrepren = new EoRoot("entrepren");
    //suffix indicating piece
    public static EoRoot er = new EoRoot("er");
    //porcupine
    public static EoRoot erinac = new EoRoot("erinac");
    //essence
    public static EoRoot esenc = new EoRoot("esenc");
    //hope
    public static EoRoot esper = new EoRoot("esper");
    //be
    public static EoRoot est = new EoRoot("est");
    //suffix indicating leader
    public static EoRoot estr = new EoRoot("estr");
    //suffix indicating smallness
    public static EoRoot et = new EoRoot("et");
    //Europe
    public static EoRoot eŭrop = new EoRoot("eŭrop");
    //eventual
    public static EoRoot eventual = new EoRoot("eventual");
    //become evolved
    public static EoRoot evolu = new EoRoot("evolu");
    //easy
    public static EoRoot facil = new EoRoot("facil");
    //specialty
    public static EoRoot fak = new EoRoot("fak");
    //fact
    public static EoRoot fakt = new EoRoot("fakt");
    //fall
    public static EoRoot fal = new EoRoot("fal");
    //family
    public static EoRoot famili = new EoRoot("famili");
    //do, make
    public static EoRoot far = new EoRoot("far");
    //fare
    public static EoRoot fart = new EoRoot("fart");
    //happy
    public static EoRoot feliĉ = new EoRoot("feliĉ");
    //close
    public static EoRoot ferm = new EoRoot("ferm");
    //festival
    public static EoRoot festival = new EoRoot("festival");
    //film
    public static EoRoot film = new EoRoot("film");
    //finish
    public static EoRoot fin = new EoRoot("fin");
    //Finnland
    public static EoRoot finn = new EoRoot("finn");
    //firm
    public static EoRoot firm = new EoRoot("firm");
    //fish
    public static EoRoot fiŝ = new EoRoot("fiŝ");
    //side
    public static EoRoot flank = new EoRoot("flank");
    //yellow
    public static EoRoot flav = new EoRoot("flav");
    //flower
    public static EoRoot flor = new EoRoot("flor");
    //fly
    public static EoRoot flug = new EoRoot("flug");
    //time, occurrence
    public static EoRoot foj = new EoRoot("foj");
    //particle for away
    public static EoRoot @for = new EoRoot("for");
    //forget
    public static EoRoot forges = new EoRoot("forges");
    //form
    public static EoRoot form = new EoRoot("form");
    //strong
    public static EoRoot fort = new EoRoot("fort");
    //photograph
    public static EoRoot fot = new EoRoot("fot");
    //France
    public static EoRoot franc = new EoRoot("franc");
    //franc
    public static EoRoot frank = new EoRoot("frank");
    //sibling
    public static EoRoot frat = new EoRoot("frat");
    //unmarried adult
    public static EoRoot fraŭl = new EoRoot("fraŭl");
    //sentence
    public static EoRoot fraz = new EoRoot("fraz");
    //crazy
    public static EoRoot frenez = new EoRoot("frenez");
    //early
    public static EoRoot fru = new EoRoot("fru");
    //function
    public static EoRoot funkci = new EoRoot("funkci");
    //prefix indicating blunder
    public static EoRoot fuŝ = new EoRoot("fuŝ");
    //prefix indicating mixed company
    public static EoRoot ge = new EoRoot("ge");
    //Germany
    public static EoRoot german = new EoRoot("german");
    //cashier station
    public static EoRoot giĉet = new EoRoot("giĉet");
    //grade
    public static EoRoot grad = new EoRoot("grad");
    //big
    public static EoRoot grand = new EoRoot("grand");
    //congratulate
    public static EoRoot gratul = new EoRoot("gratul");
    //important
    public static EoRoot grav = new EoRoot("grav");
    //group
    public static EoRoot grup = new EoRoot("grup");
    //guide
    public static EoRoot gvid = new EoRoot("gvid");
    //bother
    public static EoRoot ĝen = new EoRoot("ĝen");
    //in a general sense
    public static EoRoot ĝeneral = new EoRoot("ĝeneral");
    //pronoun it
    public static EoRoot ĝi = new EoRoot("ĝi");
    //preposition until
    public static EoRoot ĝis = new EoRoot("ĝis");
    //joy
    public static EoRoot ĝoj = new EoRoot("ĝoj");
    //correct
    public static EoRoot ĝust = new EoRoot("ĝust");
    //interjection
    public static EoRoot ha = new EoRoot("ha");
    //have
    public static EoRoot hav = new EoRoot("hav");
    //Hebrew
    public static EoRoot hebre = new EoRoot("hebre");
    //home
    public static EoRoot hejm = new EoRoot("hejm");
    //help
    public static EoRoot help = new EoRoot("help");
    //yesterday
    public static EoRoot hieraŭ = new EoRoot("hieraŭ");
    //interjection
    public static EoRoot ho = new EoRoot("ho");
    //today
    public static EoRoot hodiaŭ = new EoRoot("hodiaŭ");
    //person
    public static EoRoot hom = new EoRoot("hom");
    //hour, time of day
    public static EoRoot hor = new EoRoot("hor");
    //hotel
    public static EoRoot hotel = new EoRoot("hotel");
    //correlative some kind of
    public static EoRoot ia = new EoRoot("ia");
    //correlative sometime
    public static EoRoot iam = new EoRoot("iam");
    //idea
    public static EoRoot ide = new EoRoot("ide");
    //correlative somewhere
    public static EoRoot ie = new EoRoot("ie");
    //correlative in some way
    public static EoRoot iel = new EoRoot("iel");
    //suffix indicating transitivity, causation
    public static EoRoot ig = new EoRoot("ig");
    //suffix indicating becoming
    public static EoRoot iĝ = new EoRoot("iĝ");
    //suffix indicating tool
    public static EoRoot il = new EoRoot("il");
    //pronoun them
    public static EoRoot ili = new EoRoot("ili");
    //image, imagine
    public static EoRoot imag = new EoRoot("imag");
    //suffix indicating female
    public static EoRoot @in = new EoRoot("in");
    //suffix indicating worthiness
    public static EoRoot ind = new EoRoot("ind");
    //child
    public static EoRoot infan = new EoRoot("infan");
    //inform, information
    public static EoRoot inform = new EoRoot("inform");
    //teach
    public static EoRoot instru = new EoRoot("instru");
    //suffix indicating past action or actor
    public static EoRoot @int = new EoRoot("int");
    //intelligent
    public static EoRoot inteligent = new EoRoot("inteligent");
    //preposition between, among
    public static EoRoot inter = new EoRoot("inter");
    //interest
    public static EoRoot interes = new EoRoot("interes");
    //interpret
    public static EoRoot interpret = new EoRoot("interpret");
    //invite
    public static EoRoot invit = new EoRoot("invit");
    //correlative something
    public static EoRoot io = new EoRoot("io");
    //correlative some amount of
    public static EoRoot iom = new EoRoot("iom");
    //go
    public static EoRoot ir = new EoRoot("ir");
    //Iran
    public static EoRoot iran = new EoRoot("iran");
    //suffix indicating professional or adherent
    public static EoRoot ist = new EoRoot("ist");
    //suffix indicating past passive
    public static EoRoot it = new EoRoot("it");
    //Italy
    public static EoRoot ital = new EoRoot("ital");
    //correlative someone
    public static EoRoot iu = new EoRoot("iu");
    //indeed
    public static EoRoot ja = new EoRoot("ja");
    //already
    public static EoRoot jam = new EoRoot("jam");
    //Japan
    public static EoRoot japan = new EoRoot("japan");
    //year
    public static EoRoot jar = new EoRoot("jar");
    //preposition (no fixed meaning)
    public static EoRoot je = new EoRoot("je");
    //behold
    public static EoRoot jen = new EoRoot("jen");
    //yes
    public static EoRoot jes = new EoRoot("jes");
    //young
    public static EoRoot jun = new EoRoot("jun");
    //throw
    public static EoRoot ĵet = new EoRoot("ĵet");
    //conjunction and
    public static EoRoot kaj = new EoRoot("kaj");
    //field
    public static EoRoot kamp = new EoRoot("kamp");
    //sing
    public static EoRoot kant = new EoRoot("kant");
    //capable
    public static EoRoot kapabl = new EoRoot("kapabl");
    //catch, capture
    public static EoRoot kapt = new EoRoot("kapt");
    //dear
    public static EoRoot kar = new EoRoot("kar");
    //carrot
    public static EoRoot karot = new EoRoot("karot");
    //card
    public static EoRoot kart = new EoRoot("kart");
    //hide
    public static EoRoot kaŝ = new EoRoot("kaŝ");
    //case
    public static EoRoot kaz = new EoRoot("kaz");
    //conjunction that
    public static EoRoot ke = new EoRoot("ke");
    //several
    public static EoRoot kelk = new EoRoot("kelk");
    //correlative what kind of
    public static EoRoot kia = new EoRoot("kia");
    //correlative why
    public static EoRoot kial = new EoRoot("kial");
    //correlative when
    public static EoRoot kiam = new EoRoot("kiam");
    //correlative where
    public static EoRoot kie = new EoRoot("kie");
    //correlative how
    public static EoRoot kiel = new EoRoot("kiel");
    //kilo-
    public static EoRoot kilo = new EoRoot("kilo");
    //correlative what thing
    public static EoRoot kio = new EoRoot("kio");
    //correlative how much
    public static EoRoot kiom = new EoRoot("kiom");
    //correlative who or which
    public static EoRoot kiu = new EoRoot("kiu");
    //clear
    public static EoRoot klar = new EoRoot("klar");
    //take steps to achieve
    public static EoRoot klopod = new EoRoot("klopod");
    //young person
    public static EoRoot knab = new EoRoot("knab");
    //color
    public static EoRoot kolor = new EoRoot("kolor");
    //begin
    public static EoRoot komenc = new EoRoot("komenc");
    //commission
    public static EoRoot komision = new EoRoot("komision");
    //committee
    public static EoRoot komitat = new EoRoot("komitat");
    //competent
    public static EoRoot kompetent = new EoRoot("kompetent");
    //complete
    public static EoRoot komplet = new EoRoot("komplet");
    //complicated
    public static EoRoot komplik = new EoRoot("komplik");
    //understand
    public static EoRoot kompren = new EoRoot("kompren");
    //be familiar with
    public static EoRoot kon = new EoRoot("kon");
    //concept
    public static EoRoot koncept = new EoRoot("koncept");
    //in question
    public static EoRoot koncern = new EoRoot("koncern");
    //congress, conference
    public static EoRoot kongres = new EoRoot("kongres");
    //concrete
    public static EoRoot konkret = new EoRoot("konkret");
    //contest
    public static EoRoot konkurs = new EoRoot("konkurs");
    //be conscious
    public static EoRoot konsci = new EoRoot("konsci");
    //agree
    public static EoRoot konsent = new EoRoot("konsent");
    //conserve
    public static EoRoot konserv = new EoRoot("konserv");
    //advise
    public static EoRoot konsil = new EoRoot("konsil");
    //council
    public static EoRoot konsili = new EoRoot("konsili");
    //consist
    public static EoRoot konsist = new EoRoot("konsist");
    //permanent
    public static EoRoot konstant = new EoRoot("konstant");
    //contact
    public static EoRoot kontakt = new EoRoot("kontakt");
    //preposition against
    public static EoRoot kontraŭ = new EoRoot("kontraŭ");
    //check, look into
    public static EoRoot kontrol = new EoRoot("kontrol");
    //basket
    public static EoRoot korb = new EoRoot("korb");
    //correspondence
    public static EoRoot korespond = new EoRoot("korespond");
    //cost
    public static EoRoot kost = new EoRoot("kost");
    //cover
    public static EoRoot kovr = new EoRoot("kovr");
    //believe
    public static EoRoot kred = new EoRoot("kred");
    //grow up
    public static EoRoot kresk = new EoRoot("kresk");
    //shout
    public static EoRoot kri = new EoRoot("kri");
    //crocodile
    public static EoRoot krokodil1 = new EoRoot("krokodil1");
    //use a national language where Esperanto would be appropriate
    public static EoRoot krokodil2 = new EoRoot("krokodil2");
    //preposition besides
    public static EoRoot krom = new EoRoot("krom");
    //cruel
    public static EoRoot kruel = new EoRoot("kruel");
    //cook
    public static EoRoot kuir = new EoRoot("kuir");
    //spoon
    public static EoRoot kuler = new EoRoot("kuler");
    //culture
    public static EoRoot kultur = new EoRoot("kultur");
    //preposition with
    public static EoRoot kun = new EoRoot("kun");
    //rabbit
    public static EoRoot kunikl = new EoRoot("kunikl");
    //run
    public static EoRoot kur = new EoRoot("kur");
    //usual, custom
    public static EoRoot kutim = new EoRoot("kutim");
    //conjunction although
    public static EoRoot kvankam = new EoRoot("kvankam");
    //4
    public static EoRoot kvar = new EoRoot("kvar");
    //conjunction as if, quasi-
    public static EoRoot kvazaŭ = new EoRoot("kvazaŭ");
    //5
    public static EoRoot kvin = new EoRoot("kvin");
    //article the
    public static EoRoot la = new EoRoot("la");
    //work
    public static EoRoot labor = new EoRoot("labor");
    //lake
    public static EoRoot lag = new EoRoot("lag");
    //launch
    public static EoRoot lanĉ = new EoRoot("lanĉ");
    //country
    public static EoRoot land = new EoRoot("land");
    //let go
    public static EoRoot las = new EoRoot("las");
    //last, most recent
    public static EoRoot last = new EoRoot("last");
    //preposition according to
    public static EoRoot laŭ = new EoRoot("laŭ");
    //wash
    public static EoRoot lav = new EoRoot("lav");
    //read
    public static EoRoot leg = new EoRoot("leg");
    //learn
    public static EoRoot lern = new EoRoot("lern");
    //skilled
    public static EoRoot lert = new EoRoot("lert");
    //letter of correspondence
    public static EoRoot leter = new EoRoot("leter");
    //raise something up
    public static EoRoot lev = new EoRoot("lev");
    //pronoun he
    public static EoRoot li = new EoRoot("li");
    //free
    public static EoRoot liber = new EoRoot("liber");
    //book
    public static EoRoot libr = new EoRoot("libr");
    //link, bind
    public static EoRoot lig = new EoRoot("lig");
    //language
    public static EoRoot lingv = new EoRoot("lingv");
    //list
    public static EoRoot list = new EoRoot("list");
    //bed
    public static EoRoot lit = new EoRoot("lit");
    //alphabetic glyph
    public static EoRoot liter = new EoRoot("liter");
    //literature
    public static EoRoot literatur = new EoRoot("literatur");
    //reside
    public static EoRoot loĝ = new EoRoot("loĝ");
    //location
    public static EoRoot lok = new EoRoot("lok");
    //long
    public static EoRoot @long = new EoRoot("long");
    //rent from
    public static EoRoot lu = new EoRoot("lu");
    //play a game
    public static EoRoot lud = new EoRoot("lud");
    //prefix indicating opposite
    public static EoRoot mal = new EoRoot("mal");
    //hand
    public static EoRoot man = new EoRoot("man");
    //eat
    public static EoRoot manĝ = new EoRoot("manĝ");
    //manner
    public static EoRoot manier = new EoRoot("manier");
    //be lacking
    public static EoRoot mank = new EoRoot("mank");
    //map
    public static EoRoot map = new EoRoot("map");
    //large body of salt water
    public static EoRoot mar = new EoRoot("mar");
    //mark
    public static EoRoot mark1 = new EoRoot("mark1");
    //obsolete German currency
    public static EoRoot mark2 = new EoRoot("mark2");
    //walk
    public static EoRoot marŝ = new EoRoot("marŝ");
    //machine
    public static EoRoot maŝin = new EoRoot("maŝin");
    //morning
    public static EoRoot maten = new EoRoot("maten");
    //material
    public static EoRoot material = new EoRoot("material");
    //self
    public static EoRoot mem = new EoRoot("mem");
    //member
    public static EoRoot membr = new EoRoot("membr");
    //remember, memory
    public static EoRoot memor = new EoRoot("memor");
    //put
    public static EoRoot met = new EoRoot("met");
    //middle, average
    public static EoRoot mez = new EoRoot("mez");
    //pronoun I, me
    public static EoRoot mi = new EoRoot("mi");
    //mix
    public static EoRoot miks = new EoRoot("miks");
    //1000
    public static EoRoot mil = new EoRoot("mil");
    //minimum
    public static EoRoot minimum = new EoRoot("minimum");
    //minute = 60 seconds
    public static EoRoot minut = new EoRoot("minut");
    //marvel
    public static EoRoot mir = new EoRoot("mir");
    //moment
    public static EoRoot moment = new EoRoot("moment");
    //money
    public static EoRoot mon = new EoRoot("mon");
    //month
    public static EoRoot monat = new EoRoot("monat");
    //world
    public static EoRoot mond = new EoRoot("mond");
    //mountain
    public static EoRoot mont = new EoRoot("mont");
    //show
    public static EoRoot montr = new EoRoot("montr");
    //tomorrow
    public static EoRoot morgaŭ = new EoRoot("morgaŭ");
    //move something
    public static EoRoot mov = new EoRoot("mov");
    //multiple, many
    public static EoRoot mult = new EoRoot("mult");
    //nation
    public static EoRoot naci = new EoRoot("naci");
    //swim
    public static EoRoot naĝ = new EoRoot("naĝ");
    //bear fruit
    public static EoRoot nask = new EoRoot("nask");
    //9
    public static EoRoot naŭ = new EoRoot("naŭ");
    //no
    public static EoRoot ne = new EoRoot("ne");
    //necessary
    public static EoRoot neces = new EoRoot("neces");
    //Netherlands
    public static EoRoot nederland = new EoRoot("nederland");
    //correlative never
    public static EoRoot neniam = new EoRoot("neniam");
    //correlative nothing
    public static EoRoot nenio = new EoRoot("nenio");
    //correlative no one
    public static EoRoot neniu = new EoRoot("neniu");
    //mandatory
    public static EoRoot nepr = new EoRoot("nepr");
    //neutral
    public static EoRoot neŭtral = new EoRoot("neŭtral");
    //pronoun us, we
    public static EoRoot ni = new EoRoot("ni");
    //level
    public static EoRoot nivel = new EoRoot("nivel");
    //night
    public static EoRoot nokt = new EoRoot("nokt");
    //name
    public static EoRoot nom = new EoRoot("nom");
    //normal
    public static EoRoot normal = new EoRoot("normal");
    //new
    public static EoRoot nov = new EoRoot("nov");
    //interjection
    public static EoRoot nu = new EoRoot("nu");
    //naked
    public static EoRoot nud = new EoRoot("nud");
    //number
    public static EoRoot numer = new EoRoot("numer");
    //now
    public static EoRoot nun = new EoRoot("nun");
    //merely, only
    public static EoRoot nur = new EoRoot("nur");
    //offer
    public static EoRoot ofert = new EoRoot("ofert");
    //official
    public static EoRoot oficial = new EoRoot("oficial");
    //frequent
    public static EoRoot oft = new EoRoot("oft");
    //8
    public static EoRoot ok = new EoRoot("ok");
    //happen
    public static EoRoot okaz = new EoRoot("okaz");
    //west
    public static EoRoot okcident = new EoRoot("okcident");
    //occupy
    public static EoRoot okup = new EoRoot("okup");
    //preposition than
    public static EoRoot ol = new EoRoot("ol");
    //suffix indicating number as denominator
    public static EoRoot on = new EoRoot("on");
    //pronoun one
    public static EoRoot oni = new EoRoot("oni");
    //suffix indicating future action or actor
    public static EoRoot ont = new EoRoot("ont");
    //opine
    public static EoRoot opini = new EoRoot("opini");
    //order (arrangement)
    public static EoRoot ord = new EoRoot("ord");
    //ordinary
    public static EoRoot ordinar = new EoRoot("ordinar");
    //organize
    public static EoRoot organiz = new EoRoot("organiz");
    //east
    public static EoRoot orient = new EoRoot("orient");
    //egg
    public static EoRoot ov = new EoRoot("ov");
    //pay
    public static EoRoot pag = new EoRoot("pag");
    //page
    public static EoRoot paĝ = new EoRoot("paĝ");
    //paper
    public static EoRoot paper = new EoRoot("paper");
    //pardon
    public static EoRoot pardon = new EoRoot("pardon");
    //speak
    public static EoRoot parol = new EoRoot("parol");
    //part
    public static EoRoot part = new EoRoot("part");
    //pass
    public static EoRoot pas = new EoRoot("pas");
    //step
    public static EoRoot paŝ = new EoRoot("paŝ");
    //parent
    public static EoRoot patr = new EoRoot("patr");
    //hang
    public static EoRoot pend = new EoRoot("pend");
    //think
    public static EoRoot pens = new EoRoot("pens");
    //preposition by means of
    public static EoRoot per = new EoRoot("per");
    //lose
    public static EoRoot perd = new EoRoot("perd");
    //perfect
    public static EoRoot perfekt = new EoRoot("perfekt");
    //period of time
    public static EoRoot period = new EoRoot("period");
    //peach
    public static EoRoot persik = new EoRoot("persik");
    //person
    public static EoRoot person = new EoRoot("person");
    //request
    public static EoRoot pet = new EoRoot("pet");
    //foot
    public static EoRoot pied = new EoRoot("pied");
    //be pleasing
    public static EoRoot plaĉ = new EoRoot("plaĉ");
    //plan
    public static EoRoot plan = new EoRoot("plan");
    //floor
    public static EoRoot plank = new EoRoot("plank");
    //particle indicating superlative
    public static EoRoot plej = new EoRoot("plej");
    //full
    public static EoRoot plen = new EoRoot("plen");
    //particle indicating comparative
    public static EoRoot pli = new EoRoot("pli");
    //weep
    public static EoRoot plor = new EoRoot("plor");
    //further
    public static EoRoot plu = new EoRoot("plu");
    //plural
    public static EoRoot plur = new EoRoot("plur");
    //trophy cup
    public static EoRoot pokal = new EoRoot("pokal");
    //apple
    public static EoRoot pom = new EoRoot("pom");
    //bridge
    public static EoRoot pont = new EoRoot("pont");
    //popular
    public static EoRoot popular = new EoRoot("popular");
    //preposition in order to
    public static EoRoot por = new EoRoot("por");
    //door
    public static EoRoot port = new EoRoot("port");
    //preposition after
    public static EoRoot post = new EoRoot("post");
    //require
    public static EoRoot postul = new EoRoot("postul");
    //be able to
    public static EoRoot pov = new EoRoot("pov");
    //be morally right
    public static EoRoot prav = new EoRoot("prav");
    //principal
    public static EoRoot precip = new EoRoot("precip");
    //precise
    public static EoRoot preciz = new EoRoot("preciz");
    //prefer
    public static EoRoot prefer = new EoRoot("prefer");
    //lecture
    public static EoRoot preleg = new EoRoot("preleg");
    //prize
    public static EoRoot premi = new EoRoot("premi");
    //take
    public static EoRoot pren = new EoRoot("pren");
    //prepare
    public static EoRoot prepar = new EoRoot("prepar");
    //nearly
    public static EoRoot preskaŭ = new EoRoot("preskaŭ");
    //ready
    public static EoRoot pret = new EoRoot("pret");
    //price
    public static EoRoot prez = new EoRoot("prez");
    //present
    public static EoRoot prezent = new EoRoot("prezent");
    //preside
    public static EoRoot prezid = new EoRoot("prezid");
    //preposition about, concerning
    public static EoRoot pri = new EoRoot("pri");
    //principle
    public static EoRoot princip = new EoRoot("princip");
    //preposition on account of
    public static EoRoot pro = new EoRoot("pro");
    //problem
    public static EoRoot problem = new EoRoot("problem");
    //product, produce
    public static EoRoot produkt = new EoRoot("produkt");
    //professional
    public static EoRoot profesi = new EoRoot("profesi");
    //professor
    public static EoRoot profesor = new EoRoot("profesor");
    //program
    public static EoRoot program = new EoRoot("program");
    //close
    public static EoRoot proksim = new EoRoot("proksim");
    //propose
    public static EoRoot propon = new EoRoot("propon");
    //protest
    public static EoRoot protest = new EoRoot("protest");
    //minutes of a meeting
    public static EoRoot protokol = new EoRoot("protokol");
    //try
    public static EoRoot prov = new EoRoot("prov");
    //public
    public static EoRoot publik = new EoRoot("publik");
    //dot
    public static EoRoot punkt = new EoRoot("punkt");
    //doll
    public static EoRoot pup = new EoRoot("pup");
    //clean
    public static EoRoot pur = new EoRoot("pur");
    //right, entitlement
    public static EoRoot rajt = new EoRoot("rajt");
    //story, tell a story
    public static EoRoot rakont = new EoRoot("rakont");
    //fast, quick
    public static EoRoot rapid = new EoRoot("rapid");
    //report
    public static EoRoot raport = new EoRoot("raport");
    //prefix indicating repetition
    public static EoRoot re = new EoRoot("re");
    //region
    public static EoRoot region = new EoRoot("region");
    //rule, regulation
    public static EoRoot regul = new EoRoot("regul");
    //advertisement
    public static EoRoot reklam = new EoRoot("reklam");
    //recommend
    public static EoRoot rekomend = new EoRoot("rekomend");
    //direct
    public static EoRoot rekt = new EoRoot("rekt");
    //relative
    public static EoRoot relativ = new EoRoot("relativ");
    //meet
    public static EoRoot renkont = new EoRoot("renkont");
    //answer
    public static EoRoot respond = new EoRoot("respond");
    //remain
    public static EoRoot rest = new EoRoot("rest");
    //rich
    public static EoRoot riĉ = new EoRoot("riĉ");
    //receive
    public static EoRoot ricev = new EoRoot("ricev");
    //laugh
    public static EoRoot rid = new EoRoot("rid");
    //look at
    public static EoRoot rigard = new EoRoot("rigard");
    //relation
    public static EoRoot rilat = new EoRoot("rilat");
    //notice
    public static EoRoot rimark = new EoRoot("rimark");
    //river
    public static EoRoot river = new EoRoot("river");
    //break
    public static EoRoot romp = new EoRoot("romp");
    //Russia
    public static EoRoot rus = new EoRoot("rus");
    //wise
    public static EoRoot saĝ = new EoRoot("saĝ");
    //salt
    public static EoRoot sal = new EoRoot("sal");
    //sitting room
    public static EoRoot salon = new EoRoot("salon");
    //jump
    public static EoRoot salt = new EoRoot("salt");
    //greet
    public static EoRoot salut = new EoRoot("salut");
    //same
    public static EoRoot sam = new EoRoot("sam");
    //satiated
    public static EoRoot sat = new EoRoot("sat");
    //suana
    public static EoRoot saŭn = new EoRoot("saŭn");
    //know
    public static EoRoot sci = new EoRoot("sci");
    //science
    public static EoRoot scienc = new EoRoot("scienc");
    //conjunction if
    public static EoRoot se = new EoRoot("se");
    //conjunction but
    public static EoRoot sed = new EoRoot("sed");
    //saw
    public static EoRoot seg = new EoRoot("seg");
    //sex
    public static EoRoot seks = new EoRoot("seks");
    //follow
    public static EoRoot sekv = new EoRoot("sekv");
    //week
    public static EoRoot semajn = new EoRoot("semajn");
    //preposition without
    public static EoRoot sen = new EoRoot("sen");
    //sensible
    public static EoRoot senc = new EoRoot("senc");
    //send
    public static EoRoot send = new EoRoot("send");
    //feel
    public static EoRoot sent = new EoRoot("sent");
    //7
    public static EoRoot sep = new EoRoot("sep");
    //seek
    public static EoRoot serĉ = new EoRoot("serĉ");
    //series
    public static EoRoot seri = new EoRoot("seri");
    //6
    public static EoRoot ses = new EoRoot("ses");
    //pronoun reflexive to actor
    public static EoRoot si = new EoRoot("si");
    //sit
    public static EoRoot sid = new EoRoot("sid");
    //mean, signify
    public static EoRoot signif = new EoRoot("signif");
    //similar
    public static EoRoot simil = new EoRoot("simil");
    //simple
    public static EoRoot simpl = new EoRoot("simpl");
    //feign, simulate
    public static EoRoot simul = new EoRoot("simul");
    //Mister
    public static EoRoot sinjor = new EoRoot("sinjor");
    //siren
    public static EoRoot siren = new EoRoot("siren");
    //system
    public static EoRoot sistem = new EoRoot("sistem");
    //situation
    public static EoRoot situaci = new EoRoot("situaci");
    //Scandinavia
    public static EoRoot skandinavi = new EoRoot("skandinavi");
    //box
    public static EoRoot skatol = new EoRoot("skatol");
    //ski
    public static EoRoot ski = new EoRoot("ski");
    //write
    public static EoRoot skrib = new EoRoot("skrib");
    //society
    public static EoRoot soci = new EoRoot("soci");
    //alone
    public static EoRoot sol = new EoRoot("sol");
    //solution
    public static EoRoot solv = new EoRoot("solv");
    //perform wizardry or witchcraft
    public static EoRoot sorĉ = new EoRoot("sorĉ");
    //type, species
    public static EoRoot spec = new EoRoot("spec");
    //special
    public static EoRoot special = new EoRoot("special");
    //specific
    public static EoRoot specif = new EoRoot("specif");
    //experience
    public static EoRoot spert = new EoRoot("spert");
    //spinach
    public static EoRoot spinac = new EoRoot("spinac");
    //standing
    public static EoRoot star = new EoRoot("star");
    //state of being
    public static EoRoot stat = new EoRoot("stat");
    //code of law
    public static EoRoot statut = new EoRoot("statut");
    //street
    public static EoRoot strat = new EoRoot("strat");
    //structure
    public static EoRoot struktur = new EoRoot("struktur");
    //stupid
    public static EoRoot stult = new EoRoot("stult");
    //preposition under
    public static EoRoot sub = new EoRoot("sub");
    //south
    public static EoRoot sud = new EoRoot("sud");
    //suffice
    public static EoRoot sufiĉ = new EoRoot("sufiĉ");
    //juice
    public static EoRoot suk = new EoRoot("suk");
    //succeed, success, successful
    public static EoRoot sukces = new EoRoot("sukces");
    //preposition above
    public static EoRoot super = new EoRoot("super");
    //suppose
    public static EoRoot supoz = new EoRoot("supoz");
    //top
    public static EoRoot supr = new EoRoot("supr");
    //preposition on
    public static EoRoot sur = new EoRoot("sur");
    //Sweden
    public static EoRoot sved = new EoRoot("sved");
    //Switzerland
    public static EoRoot svis = new EoRoot("svis");
    //sheep
    public static EoRoot ŝaf = new EoRoot("ŝaf");
    //seem
    public static EoRoot ŝajn = new EoRoot("ŝajn");
    //chance, luck
    public static EoRoot ŝanc = new EoRoot("ŝanc");
    //change
    public static EoRoot ŝanĝ = new EoRoot("ŝanĝ");
    //like, appreciate
    public static EoRoot ŝat = new EoRoot("ŝat");
    //pronoun she
    public static EoRoot ŝi = new EoRoot("ŝi");
    //sea-going vessel
    public static EoRoot ŝip = new EoRoot("ŝip");
    //tear, rip
    public static EoRoot ŝir = new EoRoot("ŝir");
    //lock
    public static EoRoot ŝlos = new EoRoot("ŝlos");
    //steal
    public static EoRoot ŝtel = new EoRoot("ŝtel");
    //table
    public static EoRoot tabl = new EoRoot("tabl");
    //board
    public static EoRoot tabul = new EoRoot("tabul");
    //day
    public static EoRoot tag = new EoRoot("tag");
    //typewrite
    public static EoRoot tajp = new EoRoot("tajp");
    //nevertheless
    public static EoRoot tamen = new EoRoot("tamen");
    //task
    public static EoRoot task = new EoRoot("task");
    //tea
    public static EoRoot te = new EoRoot("te");
    //the theatrical art form
    public static EoRoot teatr = new EoRoot("teatr");
    //text
    public static EoRoot tekst = new EoRoot("tekst");
    //plate
    public static EoRoot teler = new EoRoot("teler");
    //theme, subject
    public static EoRoot tem = new EoRoot("tem");
    //time
    public static EoRoot temp = new EoRoot("temp");
    //temperature
    public static EoRoot temperatur = new EoRoot("temperatur");
    //hold
    public static EoRoot ten = new EoRoot("ten");
    //terrain, campus
    public static EoRoot teren = new EoRoot("teren");
    //terrible
    public static EoRoot terur = new EoRoot("terur");
    //correlative that kind of
    public static EoRoot tia = new EoRoot("tia");
    //correlative for that reason
    public static EoRoot tial = new EoRoot("tial");
    //correlative then
    public static EoRoot tiam = new EoRoot("tiam");
    //correlative there
    public static EoRoot tie = new EoRoot("tie");
    //correlative in that way
    public static EoRoot tiel = new EoRoot("tiel");
    //fear
    public static EoRoot tim = new EoRoot("tim");
    //correlative that
    public static EoRoot tio = new EoRoot("tio");
    //correlative so much
    public static EoRoot tiom = new EoRoot("tiom");
    //correlative that person
    public static EoRoot tiu = new EoRoot("tiu");
    //preposition through
    public static EoRoot tra = new EoRoot("tra");
    //translate
    public static EoRoot traduk = new EoRoot("traduk");
    //train
    public static EoRoot trajn = new EoRoot("trajn");
    //handle, deal with
    public static EoRoot trakt = new EoRoot("trakt");
    //cut
    public static EoRoot tranĉ = new EoRoot("tranĉ");
    //preposition across
    public static EoRoot trans = new EoRoot("trans");
    //very much
    public static EoRoot tre = new EoRoot("tre");
    //3
    public static EoRoot tri = new EoRoot("tri");
    //drink
    public static EoRoot trink = new EoRoot("trink");
    //too much
    public static EoRoot tro = new EoRoot("tro");
    //find
    public static EoRoot trov = new EoRoot("trov");
    //immediately
    public static EoRoot tuj = new EoRoot("tuj");
    //napkin
    public static EoRoot tuk = new EoRoot("tuk");
    //touch
    public static EoRoot tuŝ = new EoRoot("tuŝ");
    //entire, total
    public static EoRoot tut = new EoRoot("tut");
    //suffix indicating container
    public static EoRoot uj = new EoRoot("uj");
    //suffix indicating type of person
    public static EoRoot ul = new EoRoot("ul");
    //suffix (no fixed meaning)
    public static EoRoot um = new EoRoot("um");
    //universal
    public static EoRoot universal = new EoRoot("universal");
    //university
    public static EoRoot universitat = new EoRoot("universitat");
    //1
    public static EoRoot unu = new EoRoot("unu");
    //municipality
    public static EoRoot urb = new EoRoot("urb");
    //United States of America
    public static EoRoot uson = new EoRoot("uson");
    //useful
    public static EoRoot util = new EoRoot("util");
    //use
    public static EoRoot uz = new EoRoot("uz");
    //value
    public static EoRoot valor = new EoRoot("valor");
    //warm
    public static EoRoot varm = new EoRoot("varm");
    //vast
    public static EoRoot vast = new EoRoot("vast");
    //come
    public static EoRoot ven = new EoRoot("ven");
    //sell
    public static EoRoot vend = new EoRoot("vend");
    //win
    public static EoRoot venk = new EoRoot("venk");
    //true
    public static EoRoot ver = new EoRoot("ver");
    //compose
    public static EoRoot verk = new EoRoot("verk");
    //evening
    public static EoRoot vesper = new EoRoot("vesper");
    //clothing
    public static EoRoot vest = new EoRoot("vest");
    //weather
    public static EoRoot veter = new EoRoot("veter");
    //take a trip
    public static EoRoot vetur = new EoRoot("vetur");
    //pronoun you
    public static EoRoot vi = new EoRoot("vi");
    //see
    public static EoRoot vid = new EoRoot("vid");
    //wine
    public static EoRoot vin = new EoRoot("vin");
    //man
    public static EoRoot vir = new EoRoot("vir");
    //be alive
    public static EoRoot viv = new EoRoot("viv");
    //visit
    public static EoRoot vizit = new EoRoot("vizit");
    //voice, vote
    public static EoRoot voĉ = new EoRoot("voĉ");
    //way, path
    public static EoRoot voj = new EoRoot("voj");
    //travel
    public static EoRoot vojaĝ = new EoRoot("vojaĝ");
    //want
    public static EoRoot vol = new EoRoot("vol");
    //wind up
    public static EoRoot volv = new EoRoot("volv");
    //word
    public static EoRoot vort = new EoRoot("vort");
    //fox
    public static EoRoot vulp = new EoRoot("vulp");
    //care for
    public static EoRoot zorg = new EoRoot("zorg");



        //Ref: http://www.esperanto-chicago.org/rootsglossary.htm
        public const string Data = @"
absolut/ absolute
aĉ/ suffix indicating dirtyness or contemptuousness
aĉet/ purchase, buy
ad/ suffix indicating continuousness
adres/ address (location)
afer/ affair, matter
afrik/ Africa
ag/ action, act
aĝ/ age
aĵ/ suffix indicating thing, manifestation
ajn/ particle used with i- and ki- correlatives to create constructions such as 'whenever' and 'anytime'
akcept/ accept
akv/ water
al/ preposition to
ali/ other
almenaŭ/ at least
alt/ height, tall
am/ love
amas/ mass, throng, en masse
amerik/ the Americas
amik/ friend
ampleks/ extensive
amuz/ fun, amusement
an/ suffix indicating membership
angl/ England
ankaŭ/ also
ankoraŭ/ still
anonc/ announcement
anstataŭ/ in stead of
ant/ suffix indicating present action or actor
antaŭ/ before
aparat/ apparatus, machine
apart/ separate
aper/ appear
ar/ suffix indicating collection
aranĝ/ arrange
asoci/ association (group)
aspekt/ have an appearance
at/ suffix indicating present passive
atend/ wait
atent/ attention
ating/ attain
aŭ/ conjunction or
aŭd/ hear
aŭskult/ listen
aŭtobus/ bus
aŭt(omobil)/ car
av/ grandparent
 
banan/ banana
batal/ battle
baz/ base, basis
bedaŭr/ regret
bel/ beautiful
bend/ tape
bezon/ need
bibliotek/ library (edifice)
bild/ picture
bilet/ ticket
bird/ bird
bon/ good
botel/ bottle
bulgar/ Bulgaria
 
cel/ aim, goal
cent/ 100
centr/ center
cert/ certain
ceter/ remaining
cigared/ cigarette
 
ĉambr/ room
ĉar/ conjunction because
ĉarm/ charming, quaint
ĉe/ preposition at
ĉef/ boss, main
ĉeval/ horse
ĉi/ particle used with ti- correlatives to indicate nearness, like in here or this.
ĉiam/ correlative always
ĉin/ China
ĉio/ correlative everything
ĉirkaŭ/ preposition around
ĉiu/ each
ĉu/ particle indicating yes or no question
 
da/ preposition quantity of
dan/ Denmark
dank/ thank
daŭr/ last (duration)
de/ preposition of
debat/ debate
decid/ decide
deĵor/ be on duty
dek/ 10
dekstr/ right
delegaci/ delegation
demand/ ask
dev/ be obligated
dezir/ desire
diabl/ devil
difin/ define
dir/ say, tell
dis/ prefix indicating dispersion
diskriminaci/ discriminate
diskut/ discuss
divers/ diverse
divid/ divide, share
do/ particle for so
dom/ house
don/ give
donac/ gift
dorm/ sleep
du/ 2
dum/ preposition during
 
ebl/ suffix indicating possibility
ec/ suffix indicating abstract quality
eĉ/ particle even
edz/ spouse
eg/ suffix indicating largeness
ej/ suffix indicating location
ek/ prefix indicating either beginning or suddenness
eks/ prefix indicating former
ekskurs/ excursion
ekster/ preposition outside
ekzempl/ example
ekzempler/ individual copy
ekzist/ exist
el/ prounoun from out of
elekt/ select
en/ preposition in
entrepren/ enterprise
er/ suffix indicating piece
erinac/ porcupine
esenc/ essence
esper/ hope
est/ be
estr/ suffix indicating leader
et/ suffix indicating smallness
eŭrop/ Europe
eventual/ eventual
evolu/ become evolved
 
facil/ easy
fak/ specialty
fakt/ fact
fal/ fall
famili/ family
far/ do, make
fart/ fare
feliĉ/ happy
ferm/ close
festival/ festival
film/ film
fin/ finish
finn/ Finnland
firm/ firm
fiŝ/ fish
flank/ side
flav/ yellow
flor/ flower
flug/ fly
foj/ time, occurrence
for/ particle for away
forges/ forget
form/ form
fort/ strong
fot/ photograph
franc/ France
frank/ franc
frat/ sibling
fraŭl/ unmarried adult
fraz/ sentence
frenez/ crazy
fru/ early
funkci/ function
fuŝ/ prefix indicating blunder
 
ge/ prefix indicating mixed company
german/ Germany
giĉet/ cashier station
grad/ grade
grand/ big
gratul/ congratulate
grav/ important
grup/ group
gvid/ guide
 
ĝen/ bother
ĝeneral/ in a general sense
ĝi/ pronoun it
ĝis/ preposition until
ĝoj/ joy
ĝust/ correct
 
ha/ interjection
hav/ have
hebre/ Hebrew
hejm/ home
help/ help
hieraŭ/ yesterday
ho/ interjection
hodiaŭ/ today
hom/ person
hor/ hour, time of day
hotel/ hotel
 
ia/ correlative some kind of
iam/ correlative sometime
ide/ idea
ie/ correlative somewhere
iel/ correlative in some way
ig/ suffix indicating transitivity, causation
iĝ/ suffix indicating becoming
il/ suffix indicating tool
ili/ pronoun them
imag/ image, imagine
in/ suffix indicating female
ind/ suffix indicating worthiness
infan/ child
inform/ inform, information
instru/ teach
int/ suffix indicating past action or actor
inteligent/ intelligent
inter/ preposition between, among
interes/ interest
interpret/ interpret
invit/ invite
io/ correlative something
iom/ correlative some amount of
ir/ go
iran/ Iran
ist/ suffix indicating professional or adherent
it/ suffix indicating past passive
ital/ Italy
iu/ correlative someone
 
ja/ indeed
jam/ already
japan/ Japan
jar/ year
je/ preposition (no fixed meaning)
jen/ behold
jes/ yes
jun/ young
 
ĵet/ throw
 
kaj/ conjunction and
kamp/ field
kant/ sing
kapabl/ capable
kapt/ catch, capture
kar/ dear
karot/ carrot
kart/ card
kaŝ/ hide
kaz/ case
ke/ conjunction that
kelk/ several
kia/ correlative what kind of
kial/ correlative why
kiam/ correlative when
kie/ correlative where
kiel/ correlative how
kilo/ kilo-
kio/ correlative what thing
kiom/ correlative how much
kiu/ correlative who or which
klar/ clear
klopod/ take steps to achieve
knab/ young person
kolor/ color
komenc/ begin
komision/ commission
komitat/ committee
kompetent/ competent
komplet/ complete
komplik/ complicated
kompren/ understand
kon/ be familiar with
koncept/ concept
koncern/ in question
kongres/ congress, conference
konkret/ concrete
konkurs/ contest
konsci/ be conscious
konsent/ agree
konserv/ conserve
konsil/ advise
konsili/ council
konsist/ consist
konstant/ permanent
kontakt/ contact
kontraŭ/ preposition against
kontrol/ check, look into
korb/ basket
korespond/ correspondence
kost/ cost
kovr/ cover
kred/ believe
kresk/ grow up
kri/ shout
krokodil1/ crocodile
krokodil2/ use a national language where Esperanto would be appropriate
krom/ preposition besides
kruel/ cruel
kuir/ cook
kuler/ spoon
kultur/ culture
kun/ preposition with
kunikl/ rabbit
kur/ run
kutim/ usual, custom
kvankam/ conjunction although
kvar/ 4
kvazaŭ/ conjunction as if, quasi-
kvin/ 5
 
la/ article the
labor/ work
lag/ lake
lanĉ/ launch
land/ country
las/ let go
last/ last, most recent
laŭ/ preposition according to
lav/ wash
leg/ read
lern/ learn
lert/ skilled
leter/ letter of correspondence
lev/ raise something up
li/ pronoun he
liber/ free
libr/ book
lig/ link, bind
lingv/ language
list/ list
lit/ bed
liter/ alphabetic glyph
literatur/ literature
loĝ/ reside
lok/ location
long/ long
lu/ rent from
lud/ play a game
 
mal/ prefix indicating opposite
man/ hand
manĝ/ eat
manier/ manner
mank/ be lacking
map/ map
mar/ large body of salt water
mark1/ mark
mark2/ obsolete German currency
marŝ/ walk
maŝin/ machine
maten/ morning
material/ material
mem/ self
membr/ member
memor/ remember, memory
met/ put
mez/ middle, average
mi/ pronoun I, me
miks/ mix
mil/ 1000
minimum/ minimum
minut/ minute = 60 seconds
mir/ marvel
moment/ moment
mon/ money
monat/ month
mond/ world
mont/ mountain
montr/ show
morgaŭ/ tomorrow
mov/ move something
mult/ multiple, many

naci/ nation
naĝ/ swim
nask/ bear fruit
naŭ/ 9
ne/ no
neces/ necessary
nederland/ Netherlands
neniam/ correlative never
nenio/ correlative nothing
neniu/ correlative no one
nepr/ mandatory
neŭtral/ neutral
ni/ pronoun us, we
nivel/ level
nokt/ night
nom/ name
normal/ normal
nov/ new
nu/ interjection
nud/ naked
numer/ number
nun/ now
nur/ merely, only
 
ofert/ offer
oficial/ official
oft/ frequent
ok/ 8
okaz/ happen
okcident/ west
okup/ occupy
ol/ preposition than
on/ suffix indicating number as denominator
oni/ pronoun one
ont/ suffix indicating future action or actor
opini/ opine
ord/ order (arrangement)
ordinar/ ordinary
organiz/ organize
orient/ east
ov/ egg
 
pag/ pay
paĝ/ page
paper/ paper
pardon/ pardon
parol/ speak
part/ part
pas/ pass
paŝ/ step
patr/ parent
pend/ hang
pens/ think
per/ preposition by means of
perd/ lose
perfekt/ perfect
period/ period of time
persik/ peach
person/ person
pet/ request
pied/ foot
plaĉ/ be pleasing
plan/ plan
plank/ floor
plej/ particle indicating superlative
plen/ full
pli/ particle indicating comparative
plor/ weep
plu/ further
plur/ plural
pokal/ trophy cup
pom/ apple
pont/ bridge
popular/ popular
por/ preposition in order to
port/ door
post/ preposition after
postul/ require
pov/ be able to
prav/ be morally right
precip/ principal
preciz/ precise
prefer/ prefer
preleg/ lecture
premi/ prize
pren/ take
prepar/ prepare
preskaŭ/ nearly
pret/ ready
prez/ price
prezent/ present
prezid/ preside
pri/ preposition about, concerning
princip/ principle
pro/ preposition on account of
problem/ problem
produkt/ product, produce
profesi/ professional
profesor/ professor
program/ program
proksim/ close
propon/ propose
protest/ protest
protokol/ minutes of a meeting
prov/ try
publik/ public
punkt/ dot
pup/ doll
pur/ clean
 
rajt/ right, entitlement
rakont/ story, tell a story
rapid/ fast, quick
raport/ report
re/ prefix indicating repetition
region/ region
regul/ rule, regulation
reklam/ advertisement
rekomend/ recommend
rekt/ direct
relativ/ relative
renkont/ meet
respond/ answer
rest/ remain
riĉ/ rich
ricev/ receive
rid/ laugh
rigard/ look at
rilat/ relation
rimark/ notice
river/ river
romp/ break
rus/ Russia
 
saĝ/ wise
sal/ salt
salon/ sitting room
salt/ jump
salut/ greet
sam/ same
sat/ satiated
saŭn/ suana
sci/ know
scienc/ science
se/ conjunction if
sed/ conjunction but
seg/ saw
seks/ sex
sekv/ follow
semajn/ week
sen/ preposition without
senc/ sensible
send/ send
sent/ feel
sep/ 7
serĉ/ seek
seri/ series
ses/ 6
si/ pronoun reflexive to actor
sid/ sit
signif/ mean, signify
simil/ similar
simpl/ simple
simul/ feign, simulate
sinjor/ Mister
siren/ siren
sistem/ system
situaci/ situation
skandinavi/ Scandinavia
skatol/ box
ski/ ski
skrib/ write
soci/ society
sol/ alone
solv/ solution
sorĉ/ perform wizardry or witchcraft
spec/ type, species
special/ special
specif/ specific
spert/ experience
spinac/ spinach
star/ standing
stat/ state of being
statut/ code of law
strat/ street
struktur/ structure
stult/ stupid
sub/ preposition under
sud/ south
sufiĉ/ suffice
suk/ juice
sukces/ succeed, success, successful
super/ preposition above
supoz/ suppose
supr/ top
sur/ preposition on
sved/ Sweden
svis/ Switzerland
 
ŝaf/ sheep
ŝajn/ seem
ŝanc/ chance, luck
ŝanĝ/ change
ŝat/ like, appreciate
ŝi/ pronoun she
ŝip/ sea-going vessel
ŝir/ tear, rip
ŝlos/ lock
ŝtel/ steal
 
tabl/ table
tabul/ board
tag/ day
tajp/ typewrite
tamen/ nevertheless
task/ task
te/ tea
teatr/ the theatrical art form
tekst/ text
teler/ plate
tem/ theme, subject
temp/ time
temperatur/ temperature
ten/ hold
teren/ terrain, campus
terur/ terrible
tia/ correlative that kind of
tial/ correlative for that reason
tiam/ correlative then
tie/ correlative there
tiel/ correlative in that way
tim/ fear
tio/ correlative that
tiom/ correlative so much
tiu/ correlative that person
tra/ preposition through
traduk/ translate
trajn/ train
trakt/ handle, deal with
tranĉ/ cut
trans/ preposition across
tre/ very much
tri/ 3
trink/ drink
tro/ too much
trov/ find
tuj/ immediately
tuk/ napkin
tuŝ/ touch
tut/ entire, total
 
uj/ suffix indicating container
ul/ suffix indicating type of person
um/ suffix (no fixed meaning)
universal/ universal
universitat/ university
unu/ 1
urb/ municipality
uson/ United States of America
util/ useful
uz/ use
 
valor/ value
varm/ warm
vast/ vast
ven/ come
vend/ sell
venk/ win
ver/ true
verk/ compose
vesper/ evening
vest/ clothing
veter/ weather
vetur/ take a trip
vi/ pronoun you
vid/ see
vin/ wine
vir/ man
viv/ be alive
vizit/ visit
voĉ/ voice, vote
voj/ way, path
vojaĝ/ travel
vol/ want
volv/ wind up
vort/ word
vulp/ fox
 
zorg/ care for";

    }
}
