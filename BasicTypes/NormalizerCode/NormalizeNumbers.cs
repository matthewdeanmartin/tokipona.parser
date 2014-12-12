using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicTypes.Extensions;
using BasicTypes.Parser;
using BasicTypes.Parts;

namespace BasicTypes.NormalizerCode
{
    public class NormalizeNumbers
    {
        public class NumberAddress
        {
            public NumberAddress()
            {
                NumberStartsAt = -1;
                NumberEndsAt = -1;
            }
            public int NumberStartsAt { get; set; }

            public int NumberEndsAt { get; set; }
        }

        public static string FindNumbers(string sentence, Dialect dialect)
        {
            if (sentence.Length < 2)
            {
                return sentence;
            }
            if (sentence.ContainsCheck("#"))
            {
                //HACK: Could be a stray #
                return sentence;
            }
            
            string lastBit = "";
            if ("!.?:".ContainsCheck(sentence[sentence.Length - 1]))
            {
                lastBit = sentence[sentence.Length - 1].ToString();
                sentence = sentence.Substring(0, sentence.Length - 1);
            }
            
            Token[] tokens =  sentence.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(x=>new Token(x)).ToArray();

            List<NumberAddress> numbers =new List<NumberAddress>();
            NumberAddress number  = new NumberAddress();

            string[] validNumberTokens = Token.StupidNumbers;
            if (dialect.NumberType == "Stupid")
            {
                validNumberTokens = Token.StupidNumbers;//ala, wan, tu, mute
            }
            else if (dialect.NumberType == "Half Stupid" || dialect.NumberType == "Poman")
            {
                validNumberTokens = Token.HalfStupidNumbers; //mute, ale etc.
            }
            else if (dialect.NumberType == "Body")
            {
                validNumberTokens = Token.BodyNumbers; //0-10 using various body parts.
            }

            
            bool inNumber = false;
            for (int i = 0; i <= tokens.Length-1; i++)
            {
                if (Number.IsPomanNumber(tokens[i]))
                {
                    number.NumberEndsAt = i;
                    number.NumberEndsAt = i;
                    numbers.Add(number);
                    inNumber = false;
                    number = new NumberAddress();
                    continue;
                }
                if (inNumber)
                {
                    if (validNumberTokens.Contains(tokens[i].Text))
                    {
                        if (inNumber && i == tokens.Length - 1)
                        {
                            number.NumberEndsAt = i;
                            numbers.Add(number);
                            inNumber = false;
                            number = new NumberAddress();
                        }
                        continue;
                    }
                    else
                    {
                        number.NumberEndsAt = i - 1;
                        numbers.Add(number);
                        inNumber = false;
                        number = new NumberAddress();
                    }
                }
                else if (validNumberTokens.Contains(tokens[i].Text))
                {
                    if (tokens[i].Text == "ala")
                    {
                        //Can't start with 0. (ala wan?)
                        //Also causes too many false positives
                        continue;
                    }
                    if (i > 0 && "mi|sina|ona".ContainsCheck(tokens[i - 1]))
                    {
                        //mi tu isn't really a number. It's a dual pronoun.
                        continue;
                    }

                    number.NumberStartsAt = i;
                    inNumber = true;
                }


                if (inNumber && i == tokens.Length - 1)
                {
                    number.NumberEndsAt = i;
                    numbers.Add(number);
                    inNumber = false;
                    number = new NumberAddress();
                }
            }

            StringBuilder sb = new StringBuilder(sentence.Length);
            inNumber = false;
            for (int i = 0; i <= tokens.Length - 1; i++)
            {
                NumberAddress address = numbers.FirstOrDefault(x => x.NumberStartsAt == i);
                if (address != null)
                {
                    sb.Append("#");
                    
                    inNumber = true;
                }
                address = numbers.FirstOrDefault(x => x.NumberEndsAt == i);

                sb.Append(tokens[i]);

                if (address == null)
                {
                    inNumber = false;
                }
                if (inNumber && address.NumberEndsAt!=address.NumberStartsAt)
                {
                    sb.Append("-");
                }
                else
                {
                    sb.Append(" ");
                }
                
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(lastBit);
            return sb.ToString();
        }
    }
}
