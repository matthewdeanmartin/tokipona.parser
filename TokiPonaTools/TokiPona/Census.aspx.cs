using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public class TokiPonist
    {
        public string Name;
        public string Handle;
        public string AlternateHandle;
        public string Gender;
        public FileInfo[] FileInfos;
        public long? YearStarted;
        public string Country;
        public string L1;
        public string L2;
        public string L3;
    }

    public partial class Census : System.Web.UI.Page
    {
     
        public Dictionary<string, TokiPonist> TakeCensus()
        {
            Dictionary<string, TokiPonist> census =new Dictionary<string, TokiPonist>();
            TokiPonist janSonja = new TokiPonist();
            janSonja.Name = "Sonya Elen Kisa";
            janSonja.Handle = "jan Sonja";
            janSonja.AlternateHandle = null;
            janSonja.Country = "Canada";
            janSonja.L1 = "en";
            janSonja.L2 = "fr";
            janSonja.L3 = "eo";
            
            TokiPonist janPije = new TokiPonist();
            janPije.Name = "Brian Knight";
            janPije.Handle = "jan Pije";
            janPije.AlternateHandle = null;
            janPije.Country = "USA";
            janPije.L1 = "en";
            janPije.L2 = null;
            janPije.L3 = null;

            TokiPonist janOte = 
                new TokiPonist() {
                    Name = null,
                    Handle = "jan Ote",
                    AlternateHandle = null,
                    Country = "Poland",
                    L1 = "en",
                    L2 = null   
                };
            
            janPije.L3 = null;
//jan Pije - Brian Knight, USA, L1 English
//jan Ote - ... , Poland, L1 Polish, L2 English, etc.
//jan Pusa - sowelika/?, Philipines, L1 Taglog, L2 English
//jan Josa - Shinan, L1 Russian (?), L2 English
//jan Wiko - Rick Miller, USA, L1 English, L2 Esperanto
//jan Wasolitawa - ?, ?, ?
//jan Niko - ?, Russia, L1 Russian, L2 ?
//jan Kipo, John Clifford, USA, L1 English, L2 German, etc.
//jan Ape, ?, USA, L1 English
//jan Eleni, ?, ?, ?
//jan ? - Michael Freedman, USA (?), L1 English
//jan Male, Marek Blahus, Czechoslovakia, L1 Czech, L2
//jan Sami Lipita, Samir Ribic, ?, ? 
//jan ?, Corey, ?,?
//jan ?, Damon Lord, England, L1 English
//jan Loliko, ?
//jan Mato, Matthew Martin, USA, L1 English, L2 igpay atinlay.
//jan Jokopo, Jim Henry, USA
//jan ..., Toki Pona Dave, USA, L1 English
//jan Kanso, François SCHWICKER, L1 French

//jan ? - Kei's Portal/?, ???, ???
//jan ? - Stephen Todd Pop, ???, ???
//jan ? - Yves Prudhome, ???, L1 French (?)
//jan ? - Barzel, ?, ?
//jan ? - jackson, ?,?
//jan ?- Ren Sora,?,?
//jan ? - Priest of Memory,?,?
//jan ?, Scott Redd, L1 English (?)
//??, Peter Jackson, L1 English
//jan Matejo, ?, ?
//jan Ante, ?, Russia, L1 Russian, L2 ?
//jan ?, Mishaya/Amelia Imperatrix, ?,?
//jan ?, Philip Newton
//jan ?, Masukomi.org, ?, ?
//jan Nasakan, ?
//jan .., Loewe, ?, ?
//jan Lapinwino, LaPingvino, L2 Esperanto
//jan Ke, Kevyn Scott Kateri Calanza Bell, Canada, 

//jan Pile, Pierre Morin, L1 French(?)
//jan janluka, jean-luc DESTREE, L1 French(?)

//jan Moku, Marcos Cramer
//jan Maku, Marcos CRUZ
//jan Setepo / stevo, MorphemeAddict,
//jan Sosuwa, galactonerd, L1 English
//jan Elumutu, Helmut Voigt
//jan Loliko, Rodrigo PORTELA SÁNCHEZ
            return census;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}