using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Console.WriteLine("EoRoot " + stem + " = new EoRoot(\"" + stem +"\");" );
            }
        }
    }
    public class RootDictionary
    {
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
