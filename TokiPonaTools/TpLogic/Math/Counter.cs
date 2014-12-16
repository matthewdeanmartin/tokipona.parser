﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic.Math
{
    public class Counter
    {
        //http://forums.tokipona.org/viewtopic.php?f=33&t=856&p=3818&p3815
        //Lakis Lalakis <avalon@otenet.gr
        public void Ternary(long countFrom, long countTo,
            out IList<string> number,
            out IList<string> romanList,
            out IList<string> equationList)
        {
            number = new List<string>();
            romanList = new List<string>();
            equationList = new List<string>();
            //ala
            //wan
            //tu
            //wan ala
            //wan wan
            //wan tu
            //tu ala
            //tu wan
            //tu tu
            //wan ala ala
            //wan ala wan
            //wan ala tu
        }

        //jan Mato
        public void BaseEleven(long countFrom, long countTo,
            out IList<string> number,
            out IList<string> romanList,
            out IList<string> equationList)
        {
            number = new List<string>();
            romanList = new List<string>();
            equationList = new List<string>();
//walo
//loje walo
//loje laso
//loje
//loje jelo
//jelo
//laso jelo
//laso
//laso loje
//laso pimeja
//pimeja


        }


        public void 
            CountOffical(long countFrom, long countTo, 
            out IList<string> number,
            out IList<string> romanList,
            out IList<string> equationList)
        {
            number = new List<string>();
            romanList = new List<string>();
            equationList = new List<string>();

            for (long i = countFrom; i < countTo; i++)
            {
                
                long remainder = i;
                string nanpa = "";
                string equation = "";

                string roman = "";

                while (remainder > 0)
                {
                    if (remainder - 100 > 0)
                    {
                        nanpa = nanpa + " ala";
                        equation += "+ 100";
                        roman += "A";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 100;
                }

                while (remainder > 0)
                {
                    if (remainder - 20 > 0)
                    {
                        nanpa = nanpa + " mute";
                        equation += "+ 20 ";
                        roman += "M";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 20;
                }

                while (remainder > 0)
                {
                    if (remainder - 5 > 0)
                    {
                        nanpa = nanpa + " luka";
                        equation += "+ 5 ";
                        roman += "L";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 5;
                }

                while (remainder > 0)
                {
                    if (remainder - 2 > 0)
                    {
                        nanpa = nanpa + " tu";
                        equation += "+ 2 ";
                        roman += "T";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 2;
                }

                while (remainder > 0)
                {
                    if (remainder - 1 > 0)
                    {
                        nanpa = nanpa + " wan";
                        equation += "+ 1 ";
                        roman += "W";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 1;
                }

                if (i == 1)
                {
                    nanpa = "ali";
                    equation = "+ 0";
                    roman += "";
                }

                number.Add(nanpa);
                romanList.Add(roman);
                equationList.Add(equation.Substring(1));

                //this.OutText.Text += i - 1 + ": " + nanpa + "  = " + equation.Substring(1) + ", " + roman + "<br/>";
            }

            //return number;
        }
    }
}
