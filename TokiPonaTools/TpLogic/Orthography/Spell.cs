using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic.Orthography
{
   public class Spell
   {
       public static Dictionary<char, string> Greek()
       {
           return  new Dictionary<char, string>()
                                                     {
                                                         {'a', "sitelen Alepa"}, //Official, alpha
                                                         {'b', "sitelen Peta"},//Official, beta
                                                         {'c', "sitelen Ki"}, //Chi
                                                         {'d', "sitelen Teta"},//Delta
                                                         {'e', "sitelen Eta"},//eta
                                                         {'f', "sitelen Pe"},//Phi
                                                         {'g', "sitelen Kama"},//Offical, gamma
                                                         {'h', "sitelen Eta"},//
                                                         {'i', "sitelen Jota"},//Official
                                                         {'j', "sitelen Ja"}, //??
                                                         {'k', "sitelen Kapa"},//Official, Kappa
                                                         {'l', "sitelen Lameta"},//Official, Lambda
                                                         {'m', "sitelen Mu"},
                                                         {'n', "sitelen Nu"},
                                                         {'o', "sitelen Omikon"},//omicron
                                                         {'p', "sitelen Pi"},//Official, pi
                                                         {'q', "sitelen Kopa"},
                                                         {'r', "sitelen Lo"},//rho
                                                         {'s', "sitelen Sima"},//Official, sigma
                                                         {'t', "sitelen Ta"},//Official, tau
                                                         {'u', "sitelen Upilon"},//upsilon
                                                         {'v', "sitelen Wa"},//?
                                                         {'w', "sitelen Tikama"},//digamma
                                                         {'x', "sitelen Kusai"},
                                                         {'y', "sitelen Ipilon"}, //epsilon again?
                                                         {'z', "sitelen Seta"},//Official zeta
                                                     };
       }

       public static string SpellMilitary(string input)
       {
           return SpellWord(input, English());
       }

       public static string SpellGreek(string input)
       {
           return SpellWord(input, Greek());
       }

       public static string SpellEnglishOnly(string input)
       {
           return SpellWord(input, EnglishOnly());
       }

       public static Dictionary<char, string> EnglishOnly()
       {
           return new Dictionary<char, string>()
                                                     {
                                                         {'a', "sitelen Eji Inli"},
                                                         {'b', "sitelen Pe Inli"},
                                                         {'c', "sitelen Se Inli"},
                                                         {'d', "sitelen Te Inli"},
                                                         {'e', "sitelen E Inli"},
                                                         {'f', "sitelen Ejipu Inli"},
                                                         {'g', "sitelen Ke Inli"},
                                                         {'h', "sitelen Ajisu Inli"},
                                                         {'i', "sitelen Aji Inli"},
                                                         {'j', "sitelen Jeji Inli"},
                                                         {'k', "sitelen Keji Inli"},
                                                         {'l', "sitelen Le Inli"},
                                                         {'m', "sitelen Me Inli"},
                                                         {'n', "sitelen En Inli"},
                                                         {'o', "sitelen O Inli"},
                                                         {'p', "sitelen Pi Inli"},
                                                         {'q', "sitelen Ku Inli"},
                                                         {'r', "sitelen Li Inli"},
                                                         {'s', "sitelen Ese Inli"},
                                                         {'t', "sitelen Te Inli"},
                                                         {'u', "sitelen U Inli"},
                                                         {'v', "sitelen Po Inli"},
                                                         {'w', "sitelen Topuju Inli"},
                                                         {'x', "sitelen Ekusu Inli"},
                                                         {'y', "sitelen Waju Inli"},
                                                         {'z', "sitelen Si Inli"},
                                                     };
       }

       public static Dictionary<char, string> English()
       {
           return  new Dictionary<char, string>()
                                                     {
                                                         {'a', "akesi"},
                                                         {'b', "sitelen Pa Inli"},
                                                         {'c', "sitelen Se Inli"},
                                                         {'d', "sitelen Te Inli"},
                                                         {'e', "esun"},
                                                         {'f', "sitelen Pi Inli"},
                                                         {'g', "sitelen Ke Inli"},
                                                         {'h', "sitelen Ki Inli"},
                                                         {'i', "insa"},
                                                         {'j', "jaki"},
                                                         {'k', "kala"},
                                                         {'l', "luka"},
                                                         {'m', "moku"},
                                                         {'n', "nasin"},
                                                         {'o', "oko"},
                                                         {'p', "palisa"},
                                                         {'q', "sitelen Ku Inli"},
                                                         {'r', "sitelen Li Inli"},
                                                         {'s', "soweli"},
                                                         {'t', "toki"},
                                                         {'u', "unpa"},
                                                         {'v', "sitelen Po Inli"},
                                                         {'w', "wawa"},
                                                         {'x', "sitelen Ekusu Inli"},
                                                         {'y', "sitelen Waju Inli"},
                                                         {'z', "sitelen Si Inli"},
                                                     };
       }

       public static string SpellWord(string word, Dictionary<char, string> dictionary)
       {
           StringBuilder sb = new StringBuilder(word.Length * 4);
           foreach (char letter in word)
           {
               char c = char.ToLower(letter);
               if (dictionary.ContainsKey(c))
                   sb.Append(dictionary[c]);
               else
                   sb.Append(c);
               sb.Append("-");
           }
           
           return sb.ToString(0, sb.Length - 1).Replace("- ", " ").Replace(" -", " ");
       }
   }

}
