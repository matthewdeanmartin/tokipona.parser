using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using BasicTypes.Collections;
using BasicTypes.CollectionsDegenerate;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Html;
using BasicTypes.Parts;

namespace BasicTypes
{
    [DataContract]
    [Serializable]
    public partial class Sentence : IContainsWord, IFormattable, IToString
    {
        [DataMember]
        private readonly Sentence conclusion;
        [DataMember]
        private readonly Sentence[] preconditions;

        //Constituent parts of a basic sentence.
        [DataMember]
        private Vocative[] headVocatives;

        //Breaks immutability :-(
        [DataMember]
        public List<Fragment> LaFragment { get; set; }
        [DataMember]
        private readonly Particle tagConjunction;
        [DataMember]
        private readonly ComplexChain subjects;
        [DataMember]
        private readonly PredicateList predicates;
        [DataMember]
        private readonly TagQuestion tagQuestion;
        [DataMember]
        private readonly Punctuation punctuation;

        //Degenerate sentences
        [DataMember]
        private readonly Vocative degenerateVocative; //Degenerate sentence, maybe should be a subclass?
        [DataMember]
        private readonly Exclamation degenerateExclamation;//Degenerate sentence, maybe should be a subclass?
        [DataMember]
        private readonly Comment degenerateComment; //Also degenerate sentence.
        [DataMember]
        private readonly Fragment degenerateFragment; //This is something like a title "utala pi mu lili" or a signature "jan Mato"
        [DataMember]
        private readonly NullOrSymbols nullOrSymbols; //Blanks, stray punctuation, other garbage


        //Flag to indicate we have no subject.
        [DataMember]
        private readonly bool isHortative; //o mi mute li moku e kili.

        //Diagnostic info.
        private readonly SentenceDiagnostics diagnostics;

        public Sentence(NullOrSymbols nullOrSymbols, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();

            this.nullOrSymbols = nullOrSymbols;
            this.diagnostics = diagnostics;
        }
        public Sentence(Comment comment, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();

            this.degenerateComment = comment;
            this.diagnostics = diagnostics;
        }
        //Suggest that vocatives don't chain.  o jan o meli o soweli o => o! jan o! meli o! soweli o!
        public Sentence(Vocative vocative, Punctuation punctuation, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();

            this.degenerateVocative = vocative;
            this.punctuation = punctuation;

            this.diagnostics = diagnostics;
        }

        public Sentence(Fragment fragment, Punctuation punctuation, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();

            this.degenerateFragment = fragment;
            this.punctuation = punctuation;

            this.diagnostics = diagnostics;
        }

        public Sentence(Sentence[] preconditions = null, Sentence conclusion = null, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();
            if (preconditions != null && preconditions.Length > 0 && conclusion == null)
            {
                throw new TpSyntaxException("There must be a head sentence (conclusions) if there are preconditions.");
            }
            this.conclusion = conclusion;

            this.preconditions = preconditions;//Entire sentences.       


            if (conclusion != null && conclusion.punctuation == null)
            {
                throw new InvalidOperationException("Conclusions require punctuation, if only through normalization");
            }
            if (preconditions != null)
            {
                foreach (Sentence precondition in preconditions)
                {
                    precondition.HeadSentence = conclusion;

                    if (precondition.punctuation != null)
                    {
                        throw new InvalidOperationException("Preconditions should have no punctuation.");
                    }
                }
            }
            this.diagnostics = diagnostics;
        }

        public Sentence(Exclamation exclamation, Punctuation punctuation, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();

            this.degenerateExclamation = exclamation;
            this.punctuation = punctuation;

            this.diagnostics = diagnostics;
        }




        //Simple Sentences
        public Sentence(ComplexChain subjects, PredicateList predicates, SentenceOptionalParts parts = null, SentenceDiagnostics diagnostics = null)
        {
            LaFragment = new List<Fragment>();
            this.subjects = subjects; //only (*), o, en
            this.predicates = predicates; //only li, pi, en
            if (parts != null)
            {
                punctuation = parts.Punctuation;
                tagConjunction = parts.Conjunction;
                tagQuestion = parts.TagQuestion;
                headVocatives = parts.HeadVocatives;
            }

            this.diagnostics = diagnostics;
        }

        public Sentence BindSeme(Sentence question)
        {
            //Strong bind, all words match except seme
            //Weak bind, all head words match except seme.
            if (SentenceByValue.Instance.Equals(this, question))
            {
                //unless this is a question too!
                return this; //Echo! Better to return yes!
            }

            if (question.Contains(Words.seme))
            {
                //if (SentenceSemeEqual.Instance.Equals(this, question))
                //{
                //    //We have a match!
                //    //Compress & return.
                //}
            }

            //Null bind, replace seme phrase with jan ala
            //Or don't know.
            return null;
        }

        public bool Contains(Word word)
        {
            if (subjects != null)
            {
                if (subjects.Contains(word)) return true;
            }
            if (predicates != null)
            {
                if (predicates.Contains(word)) return true;
            }
            return false;
        }

        public bool IsTrue()
        {
            return false;
        }


        //If we have the following 2, we don't have the others (except punct).
        public Sentence[] Preconditions { get { return preconditions; } }
        public Sentence Conclusion { get { return conclusion; } } //Only preconditions have these.
        public Sentence HeadSentence { get; private set; } //Only preconditions have these.

        //Degenerate sentences
        public Vocative Vocative { get { return degenerateVocative; } }
        public Fragment Fragment { get { return degenerateFragment; } }
        public Exclamation Exclamation { get { return degenerateExclamation; } }


        public Vocative[] HeadVocatives { get { return headVocatives; } }
        public Particle Conjunction { get { return tagConjunction; } } //anu, taso (but not en)
        public ComplexChain Subjects { get { return subjects; } } //jan en meli en waso
        public PredicateList Predicates { get { return predicates; } }//li verb phrase li (noun phrase) li prep phrase
        public TagQuestion TagQuestion { get { return tagQuestion; } }// anu seme
        public Punctuation Punctuation { get { return punctuation; } } //.?!

        public Sentence EquivallencyGenerator()
        {
            return (Sentence)MemberwiseClone();
        }

        public IContainsWord[] Segments()
        {
            List<IContainsWord> w = new List<IContainsWord>();
            w.AddRange(Predicates);
            w.Add(Subjects);
            return w.ToArray();
        }

        public string[] SupportedsStringFormats
        {
            get
            {
                return new[]
                {
                    "g", 
                    "b", 
                    "bs",
                    "html"
                };
            }
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "g";
            }
            return ToString(format, Config.CurrentDialect);
        }

        public override string ToString()
        {
            return ToString("g", Config.CurrentDialect);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "g";
            }

            if (degenerateComment != null)
            {
                //We don't do anything fancy.
                //(Maybe suppress?)
                return degenerateComment.ToString(format, formatProvider);
            }

            List<string> sb = new List<string>();
            string spaceJoined;
            if (preconditions != null)
            {
                foreach (Sentence precondition in preconditions)
                {
                    sb.AddRange(precondition.ToTokenList(format, formatProvider));
                }
                sb.Add(Particles.la.ToString(format, formatProvider));
                sb.AddRange(conclusion.ToTokenList(format, formatProvider));

                if (sb[sb.Count() - 1] == "li")
                {
                    throw new InvalidOperationException("Something went wrong, sentence ends in li");
                }
                spaceJoined = sb.SpaceJoin(format);

                //Correct punctuation
                BasicTypes.Punctuation normalizedPunctuation = null;
                if (Contains(Words.seme))
                {
                    normalizedPunctuation = new Punctuation("?");
                }

                if (conclusion.punctuation != null)
                {
                    normalizedPunctuation = conclusion.punctuation;
                }

                //Default
                if (normalizedPunctuation == null)
                {
                    normalizedPunctuation = new Punctuation(".");
                }
                spaceJoined = spaceJoined + normalizedPunctuation.ToString();

            }
            else
            {
                //Simple sentence
                sb = ToTokenList(format, formatProvider);

                if (sb[sb.Count() - 1] == "li")
                {
                    throw new InvalidOperationException("Something went wrong, sentence ends in li");
                }
                spaceJoined = sb.SpaceJoin(format);


                //Correct punctuation
                BasicTypes.Punctuation normalizedPunctuation = null;
                if (Contains(Words.seme))
                {
                    normalizedPunctuation = new Punctuation("?");
                }

                if (punctuation != null)
                {
                    normalizedPunctuation = punctuation;
                }

                //Default (depends on if we have a parent?)
                //if (normalizedPunctuation == null)
                //{
                //    normalizedPunctuation = new Punctuation(".");
                //}

                if (normalizedPunctuation != null)
                {
                    spaceJoined = spaceJoined + normalizedPunctuation.ToString();
                }

                if (punctuation != null)
                {
                    spaceJoined = spaceJoined + punctuation;//format, formatProvider
                }
            }



            if (format != "bs")
            {
                string result = Denormalize(spaceJoined, format);
                while (result.ContainsCheck(" , "))
                {
                    result = result.Replace(" , ", ", ");
                }
                spaceJoined = result;
            }

            if (spaceJoined.EndCheck("..") || spaceJoined.EndCheck("??") || spaceJoined.EndCheck("::") || spaceJoined.EndCheck("!!"))
            {
                //HACK: WHY?!
                spaceJoined = spaceJoined.Substring(0, spaceJoined.Length - 1);
            }
            if (format == "html")
            {
                if (spaceJoined.ContainsCheck(" <span class=\"prep\">,"))
                {
                    spaceJoined = spaceJoined.Replace(" <span class=\"prep\">,", "<span class=\"prep\">,");
                }
            }
            return spaceJoined;
        }

        public List<string> ToTokenList(string format, IFormatProvider formatProvider)
        {
            List<string> sb = new List<string>();

            //Degenerate case
            if (nullOrSymbols!=null)
            {
                sb.Add(nullOrSymbols.Text);
                return sb;
            }

            if (tagConjunction != null)
            {
                sb.AddIfNeeded("|", format);
                if (format == "html")
                {
                    sb.Add(HtmlTagHelper.SpanWrap("conjunction", tagConjunction.Text));
                }
                else
                {
                    sb.Add(tagConjunction.Text);
                }

                sb.AddIfNeeded("|", format);
            }

            //TODO Vocative sentences
            //[chain]o[!.?]
            if (degenerateVocative != null)
            {
                sb.AddRange(degenerateVocative.ToTokenList(format, formatProvider));
                sb.Add(Particles.o.ToString(format, formatProvider)); //Seems dodgy. Why not a property of the chain or sentence?
            }
            else if (degenerateFragment != null)
            {
                sb.AddRange(degenerateFragment.ToTokenList(format, formatProvider));
            }
            else if (degenerateExclamation != null)
            {
                sb.AddRange(degenerateExclamation.ToTokenList(format, formatProvider));
            }
            else
            {
                if (LaFragment != null)
                {
                    foreach (Fragment chain in LaFragment)
                    {
                        sb.AddIfNeeded("{", format);
                        sb.AddRange(chain.ToTokenList(format, formatProvider));
                        sb.Add(Particles.la.ToString(format, formatProvider));
                        sb.AddIfNeeded("}", format);
                    }
                }

                //Unless it is an array, delegate to member ToString();
                if (subjects != null)
                {
                    //Should only happen for imperatives
                    sb.AddIfNeeded("[", format);
                    sb.Add(subjects == null ? "[NULL]" : subjects.ToString(format, formatProvider));
                    //subjects.Select(x => x == null ? "[NULL]" : x.ToString(format, formatProvider)), format, formatProvider, false);
                    sb.AddIfNeeded("]", format);
                }
                else
                {
                    //Not surprising if it is an imperative.
                    if (Predicates.All(x => x.Particle.Text != Particles.o.Text))
                    {
                        Console.WriteLine("This was surprising.. no subjects and AFAIK, this is not an imperative of any sort.");
                    }
                }

                sb.AddIfNeeded("<", format);
                bool supressLi = false;
                if (subjects != null)
                {
                    string test = subjects.ToString("g", formatProvider);
                    if (test == "mi" || test == "sina")
                    {
                        supressLi = true;
                    }
                }

                sb.AddRange(Predicates.ToTokenList(format, formatProvider, supressLi));
                sb.AddIfNeeded(">", format);
            }


            if (tagQuestion != null)
            {
                if (format == "html")
                {
                    sb.Add(HtmlTagHelper.SpanWrap("conjunction", tagQuestion.Text));
                }
                else
                {
                    sb.AddIfNeeded("|", format);
                    sb.Add(tagQuestion.Text);
                    sb.AddIfNeeded("|", format);
                }
            }
            return sb;
        }

        private bool NeedToReplace(string value, string pronoun)
        {
            bool startsWith = value.ContainsCheck(pronoun + " li") && value.StartCheck(pronoun + " ");
            if (startsWith) return true;

            bool followsConditional = value.ContainsCheck(pronoun + " li") && value.ContainsCheck(" la " + pronoun + " li ");
            if (followsConditional) return true;

            bool followsPunctuation = value.ContainsCheck(pronoun + " li") && value.ContainsCheck(". " + pronoun + " li ");
            if (followsPunctuation) return true;

            bool followsColon = value.ContainsCheck(pronoun + " li") && value.ContainsCheck(": " + pronoun + " li ");
            if (followsColon) return true;

            return false;
        }


        private string Denormalize(string value, string format)
        {
            if (format == null)
            {
                format = "g";
            }
            //tenpo kama la jan lili mi li toki e ni
            //if (NeedToReplace(value,"mi"))
            //{
            //    Regex r = new Regex(@"\bmi li\b");
            //    value = r.Replace(value, "mi");
            //}

            //if (NeedToReplace(value, "sina"))
            //{
            //    Regex r = new Regex(@"\bsina li li\b");
            //    value = r.Replace(value, "sina");
            //}

            if (value.ContainsCheck("~"))
            {
                value = value.Replace("~", ", ");
            }
            if (value.ContainsCheck("li ijo Nanunanuwakawakawawa."))
            {
                value = value.Replace("li ijo Nanunanuwakawakawawa.", format.StartCheck("b") ? "[NULL TOKEN]" : "");
            }
            if (value.ContainsCheck("[NULL]") && !format.StartCheck("b"))
            {
                value = value.Replace("[NULL]", "");
            }
            return value;
        }

        public bool HasPunctuation()
        {
            return Punctuation != null;
        }
        public bool HasConjunction()
        {
            return Conjunction != null;
        }
    }



}

