using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class WordGenerator
    {
        private Random random = new Random();

        //All syllables are of the form (C)V(N), that is, optional consonant + vowel + optional final nasal, or V, CV, VN, CVN. As in most languages, CV is the most common syllable type, at 75% (counting each root once). V and CVN syllables are each around 10%, while only 5 words have VN syllables (for 2% of syllables). In both the dictionary and in texts, the ratio of consonants to vowels is almost exactly one-to-one.
//Most roots (70%) are disyllabic; about 20% are monosyllables and 10% trisyllables. This is a common distribution, and similar to Polynesian.
        public string ReturnAWord()
        {
            string word = "";

            //Most roots (70%) are disyllabic; about 20% are monosyllables and 10% trisyllables.
            double random = RandomNumber(1, 100);

            bool IsValid = false;

            while (!IsValid)
            {
                if (random < 20)
                {
                    //20%
                    word = StartOfWord() + NextPartOfWord() + EndOfWord();
                }
                else if (random < 90)
                {
                    //70%
                    word = StartOfWord() + NextPartOfWord() + EndOfWord() + StartOfWord() + NextPartOfWord() +
                           EndOfWord();
                }
                else
                {
                    //10%
                    word = StartOfWord() + NextPartOfWord() + EndOfWord() + StartOfWord() + NextPartOfWord() +
                           EndOfWord()
                           + StartOfWord() + NextPartOfWord() + EndOfWord();
                }

                IsValid = IsThisValid(word);
            }

            return word;
        }

        private bool IsThisValid(string word)
        {
            string[] illegal = {"ji", "wu", "wo", "ti", "nm", "nn"};
            foreach (string s in illegal)
            {
                if (word.Contains(s)) return false;
            }
            return true;
        }

        private int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        private string StartOfWord()
        {
            //j=3
            //k=5
            //l=10.2
            //m=4.4
            //n=11.6
            //p=3.7
            //s=4.1
            //t=4.6  
            //w=2.8

            double total = 3 + 5 + 10.2 + 4.4 + 11.6 + 3.7 + 4.1 + 4.6 + 2.8;
            double result = RandomNumber(1, (int) total);
            if (result < 3) return "j";
            if (result < 3 + 5) return "k";
            if (result < 3 + 5 + 10.2) return "l";
            if (result < 3 + 5 + 10.2 + 4.4) return "m";
            if (result < 3 + 5 + 10.2 + 4.4 + 11.6) return "n";
            if (result < 3 + 5 + 10.2 + 4.4 + 11.6 + 3.7) return "p";
            if (result < 3 + 5 + 10.2 + 4.4 + 11.6 + 3.7 + 4.1) return "s";
            if (result < 3 + 5 + 10.2 + 4.4 + 11.6 + 3.7 + 4.1 + 4.6) return "t";
            return "w";

//a=17.2
//e=7.4
//i=14.8
//o=7.7
//u=3.2       
        }

        private string NextPartOfWord()
        {
//a=17.2
//e=7.4
//i=14.8
//o=7.7
//u=3.2
            double total = 17.2 + 7.4 + 14.8 + 7.7 + 3.2;
            double random = RandomNumber(1, (int) total);
            if (random < 17.2) return "a";
            if (random < 17.2 + 7.4) return "e";
            if (random < 17.2 + 7.4 + 14.8) return "i";
            if (random < 17.2 + 7.4 + 14.8 + 7.7) return "o";
            return "u";
        }

        private string EndOfWord()
        {
            double random = RandomNumber(1, 100);
            if (random < 7)
                return "n";
            return "";
        }
    }
}