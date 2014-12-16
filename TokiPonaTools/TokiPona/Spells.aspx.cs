using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public class NordicGod
    {
        public string Name { get; set; }
        public List<string> Epithets { get; set; }
        public List<string> Parents { get; set; }
        public List<string> Spouses { get; set; }
        public List<string> Halls { get; set; }
        public List<string> Deeds { get; set; }
        public List<string> Tools { get; set; }
    }

    public partial class Spells : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ouptut.Text = GeneratePoem(" need to get some milk for breakfast.")
                .Replace("\n","</br>");
        }



        public string GeneratePoem(string problem)
        {
//            string poem =
//@"Hail (best-known name), (descriptive epithet),
//Child of (parent), lover of (spouse)
//You who dwell in (name of hall),
//You who (summarize several relevant deeds)
//With your (characteristic tool or weapon)
//Come swiftly to aid me
//As I (summarize problem being addressed)";

            Dictionary<string,NordicGod> gods= Gods();

            NordicGod god= Pick(gods.Values.ToList());
            string poem =
                string.Format(
@"Hail {0}, {1},
Child of {2}, lover of {3}
You who dwell in {4},
You who {5}
With your {6}
Come swiftly to aid me
As I {7}", god.Name,Pick(god.Epithets),Pick(god.Parents), Pick(god.Spouses), Pick(god.Halls), Pick(god.Deeds), Pick(god.Tools),
         problem);
            return poem;
        }

        

        public T Pick<T>(List<T> values) 
        {
            Random r;
            if (Session["Random"] == null)
            {
                r = new Random(DateTime.Now.Millisecond);
                Session["Random"] = new Random(DateTime.Now.Millisecond);
            }
            else 
            {
                r = (Random)Session["Random"];
            }

            //TODO: pick at random
            return values[r.Next(0, values.Count)];
        }
    
        public Dictionary<string,NordicGod> Gods()
        {
            Dictionary<string, NordicGod> godList = new Dictionary<string, NordicGod>();
            NordicGod odin = new NordicGod();
            odin.Name = "Odin";
            odin.Epithets = new List<string> { "One Eye", "Vegtam","Gangleri"} ;
            odin.Spouses = new List<string> { "Frig" };
            //Thrudvangar with 540 apartments. Thor has a hall which he resided, called Bilskirnir
            odin.Halls = new List<string> { "Valhalla" };
            odin.Parents = new List<string> { "Bor", "Bestlan" };
            //List<string> { "Jörd", "Odin" };
            odin.Tools = new List<string> { "Gungnir", "Draupner" };//spear, ring
            odin.Deeds = new List<string> { "put the sword Balmung into the oak tree Branstock." };

            godList.Add(odin.Name,odin);

            NordicGod thor = new NordicGod();
            thor.Name = "Thor";
            thor.Epithets = new List<string> { "Öku-Þor"};
            thor.Spouses = new List<string> { "Sif", "Jarnsaxa" };
            //Thrudvangar with 540 apartments. Thor has a hall which he resided, called Bilskirnir
            thor.Halls = new List<string> { "Thrudvangar", "Bilskirnir" };
            thor.Parents = new List<string> { "Jörd", "Odin" };
            //List<string> { "Jörd", "Odin" };
            thor.Tools = new List<string> { "Mjollnir", "Járngreipr", "Grídarvöl", "Megingjarpar" };//hammer and gloves
            thor.Deeds = new List<string> { "fished out the serpent of the world" };

            godList.Add(thor.Name, thor);
            return godList;
        }        
    }

    

    
}