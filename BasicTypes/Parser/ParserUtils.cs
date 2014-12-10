using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BasicTypes.Collections;
using BasicTypes.CollectionsDegenerate;
using BasicTypes.CollectionsLeaf;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.NormalizerCode;
using BasicTypes.Parser;
using BasicTypes.Parts;
using Humanizer;
using NUnit.Framework.Constraints;

namespace BasicTypes
{
    /// <summary>
    /// Turns a string into an object tree.
    /// </summary>
    public class ParserUtils
    {
        private readonly Dialect config;
        public ParserUtils(Dialect config)
        {
            this.config = config;
        }
     
        //This should only operate on normalized sentences.
        public Sentence ParsedSentenceFactory(string sentence, string original)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return new Sentence(new NullOrSymbols(original));
                //  throw new InvalidOperationException("Do not give me a null sentence. Can't tell if null sentence is from input or got lost in translation");
            }

            if (sentence.StartCheck(" "))
            {
                throw new InvalidOperationException("Do not give me a sentence that leads with whitespace, I do not want to do defensive Trim() all day.");
            }

            if (sentence.StartCheck("///"))
            {
                Comment c = new Comment(sentence);
                return new Sentence(c);
            }

            string preNormalize = string.Copy(sentence);
            if (sentence.EndCheck(" li") || sentence.EndCheck(" li."))
            {
                throw new InvalidOperationException("Something went wrong, sentence ends with li: " + original);
            }
            //Normalization is really expensive. We must stop calling it twice.
            //sentence = Normalizer.NormalizeText(sentence, config); //Any way to avoid calling this twice?

            bool startsQuotedSpeech;
            bool endsQuotedSpeech;
            if (sentence.StartCheck("«"))
            {
                startsQuotedSpeech = true;
                sentence = sentence.Replace("«", " ").Trim();
            }
            if (sentence.StartCheck("»"))
            {
                endsQuotedSpeech = true;
                sentence = sentence.Replace("»", " ").Trim();
            }
            //TODO: do something with quoted speech. Big problem #1 it spans multiple sentences


            if (sentence.EndCheck(" "))
            {
                throw new InvalidOperationException("Normalizer failed to trim: " + original);
            }

            //Get the final punctuation out or it will mess up parsing later.
            string possiblePunctuation = sentence[sentence.Length - 1].ToString();
            Punctuation punctuation;
            if (Punctuation.TryParse(possiblePunctuation, out punctuation))
            {
                sentence = sentence.Substring(0, sentence.Length - 1);
            }


            //Square bracket sentence contains all others
            //[S]
            //F la [S]
            //S la [S]
            //F la S la [S]
            //Maximal.. maybe later
            //F la S la F la S  => (F la S ) la (F la [S])
            //F la S la S la F la S la S
            //[{F la S} la {S} la {F la S}] la <S> 

            //Just dealing with la fragments

            Sentence headSentence = null;
            List<Sentence> preconditions = new List<Sentence>();

            string[] laParts = Splitters.SplitOnLa(sentence);

            //Degenerate sentences.
            if (laParts[laParts.Length - 1] == "la")
            {
                //We have a vocative sentence...
                Fragment fragment = new Fragment(ProcessEnPiChain(laParts[0]));
                Sentence fragmentSentence = new Sentence(fragment, punctuation);
                return fragmentSentence;
            }

            if (laParts.Length > 1)
            {
                int i = 0;
                List<Fragment> laFragments = new List<Fragment>();
                Sentence currentSentence = null;
                foreach (string subSentence in laParts.Reverse())
                {
                    i++;
                    if (i == 1)
                    {
                        //Head sentence.
                        // subSentence.StartCheck("la ") ? subSentence.Substring(3) : subSentence
                        string laLessString = subSentence.RemoveLeadingWholeWord("la");
                        headSentence = ProcessSimpleSentence(laLessString, punctuation, original);
                        continue; //Not dealing with "kin la!"
                    }

                    //Fragments & preconditions
                    const string liFinder = @"\bli\b";
                    Match m = Regex.Match(subSentence, liFinder);
                    if (m.Success)
                    {
                        //This is a sentence
                        //Maybe should recurse.
                        string laLessString = subSentence.RemoveLeadingWholeWord("la");

                        currentSentence = ProcessSimpleSentence(laLessString, null, original);
                        preconditions.Add(currentSentence);
                    }
                    else
                    {
                        string laLessString = subSentence.RemoveLeadingWholeWord("la");
                        Fragment fragment;
                        if (laLessString.StartCheck("~"))
                        {
                            string[] parts = Splitters.SplitOnPrepositions(laLessString);
                            fragment = new Fragment(ProcessPrepositionalPhrases(parts).ToArray());
                        }
                        else
                        {
                            fragment = new Fragment(ProcessEnPiChain(laLessString));
                        }

                        if (currentSentence == null)
                        {
                            if (headSentence == null)
                            {
                                throw new InvalidOperationException(
                                    "Sentence appears to be headed by a fragment. Shouldn't deal with those here.: " + original);
                            }
                            headSentence.LaFragment.Add(fragment);
                        }
                        else
                        {
                            laFragments.Add(fragment);
                        }
                    }
                }
            }
            else
            {
                //No la at all.
                //Simple Sentence
                return ProcessSimpleSentence(sentence, punctuation, original);
            }
            if (headSentence == null)
            {
                throw new InvalidOperationException("This is not a sentence, should deal with it with it's own parser: " + original);
            }
            if (preconditions.Count == 0)
                return headSentence;
            Sentence s = new Sentence(preconditions.ToArray(), headSentence);
            return s;
        }


        public Sentence ProcessSimpleSentence(string sentence, Punctuation punctuation, string original)
        {
            
            //HACK: Still need a better way to deal with quotes.
            if (sentence.EndCheck("»") || sentence.EndCheck("«"))
            {
                sentence = sentence.Substring(0, sentence.Length - 1);
            }



            //Comment? Get out of here!
            if (sentence.StartCheck("///"))
            {
                Comment c = new Comment(sentence);
                return new Sentence(c);
            }

            //Simple exclamation! Get out of here!
            if (Exclamation.IsExclamation(sentence))
            {
                return new Sentence(new Exclamation(new HeadedPhrase(new Word(sentence))), punctuation, new SentenceDiagnostics(original, sentence));
            }

            List<Vocative> headVocatives = null;
            //jan Mato o, ale li pona. Head vocative!
            //kin la o moku. //not a vocative (hopefully dealt with elsewhere)
            //jan Mato o moku! //Head vocative, & imperative, with 2nd o discarded
            //jan Mato o o moku! //Head vocative, & imperative, with 2nd o discarded

            
            if (sentence.ContainsCheck(" o o "))//Explicit vocative & imperative
            {
                //Okay, we know exactly when the head vocatives end.
                headVocatives = new List<Vocative>();
                string justHeadVocatives= sentence.Substring(0,sentence.IndexOf(" o o "));

                //Process head vocatives.
                ProcessHeadVocatives(Splitters.SplitOnO(justHeadVocatives), headVocatives, allAreVocatives: true);
                //BUG: Add the dummy! (And it still doesn't work!)
                sentence = "jan Sanwan o " + sentence.Substring(sentence.IndexOf(" o o ")+5);
            }


            //Starts with o, then we have imperative & no head vocatives.
            bool endsOrStartsWithO = sentence.StartCheck("o ") && sentence.EndCheck(" o");
            if (!endsOrStartsWithO)
            {
                //jan So o! (We already deal with degenerate vocative sentences elsewhere)
                //jan So o sina li nasa.
                //jan So o nasa!
                //jan So o mi mute o nasa.  <-- This is the problem.

                //These could be vocatives or imperatives.
                if (sentence.ContainsCheck(" o ", " o,", ",o ") && sentence.ContainsCheck(" li "))
                {
                    headVocatives = new List<Vocative>();
                    
                    ProcessHeadVocatives(Splitters.SplitOnO(sentence), headVocatives, allAreVocatives:false);

                    //int firstLi = sentence.IndexOf(" li ");
                    int lastO = sentence.LastIndexOf(" o ");
                    if (lastO < 0)
                    {
                        lastO = sentence.LastIndexOf(" o,");
                    }

                    sentence = sentence.Substring(lastO+2);
                }
            }

            //Process tag conjunctions and tag questions
            Particle conjunction = null;
            TagQuestion tagQuestion = null;
            if (sentence.StartCheck("taso "))
            {
                conjunction = Particles.taso;
                sentence = sentence.Substring(5);
            }
            else if (sentence.StartCheck("anu "))
            {
                conjunction = Particles.anu;
                sentence = sentence.Substring(4);
            }
            //else if (sentence.StartCheck("en ")) //is this legal?
            //{
            //    conjunction = Particles.en;
            //    sentence = sentence.Substring(4);
            //}
            else if (sentence.StartCheck("ante ")) //never seen it.
            {
                conjunction = Particles.ante;
                sentence = sentence.Substring(5);
            }

            //Should already have ? stripped off
            if (sentence.EndsWith(" anu seme"))
            {
                tagQuestion = new TagQuestion();
                sentence = sentence.Substring(0, sentence.LastIndexOf(" anu seme"));
            }


            if (sentence.EndCheck(" li"))
            {
                throw new InvalidOperationException("Something went wrong-- sentenc ends with li. " + sentence);

            }
            if (sentence.StartsOrContainsOrEnds("la"))
            {
                throw new InvalidOperationException("If it contains a la, anywhere, it isn't a simple sentence. " + sentence);
            }

            bool isHortative = false;
            bool isImperative = false;
            if (sentence.StartCheck("o ") && sentence.ContainsCheck(" li "))
            {
                //o mi mute li moku
                isHortative = true;
                sentence = sentence.RemoveLeadingWholeWord("o");
            }
            if (sentence.StartCheck("o ") && !sentence.ContainsCheck(" li "))
            {
                //o pana e pan
                isImperative = true;
                //sentence = sentence.RemoveLeadingWholeWord("o");
            }
            // someting o ==> vocative

            string[] liParts = Splitters.SplitOnLiOrO(sentence);

            if (liParts.Length == 1 && Exclamation.IsExclamation(liParts[0]))
            {
                //HACK: Duplicate code. & it only deals with a single final puncution mark.
                string possiblePunctuation = sentence[sentence.Length - 1].ToString();
                if (Punctuation.TryParse(possiblePunctuation, out punctuation))
                {
                    sentence = sentence.Substring(0, sentence.Length - 1);
                }

                //The whole thing is o! (or pakala! or the like)
                //pona a! a a a! ike a!
                TokenParserUtils tpu = new TokenParserUtils();

                Word[] tokes = tpu.ValidWords(sentence);
                HeadedPhrase parts = new HeadedPhrase(tokes[0], new WordSet(ArrayExtensions.Tail(tokes)));
                bool modifiersAreA = true;

                foreach (Word w in parts.Modifiers)
                {
                    if (w == "a") continue; //peculiar to exclamations & repeats.
                    if (w == "kin") continue; //modifies just about anything
                    modifiersAreA = false;
                }

                if (modifiersAreA)
                {
                    Exclamation exclamation = new Exclamation(parts);
                    Sentence s = new Sentence(exclamation, punctuation);
                    return s;
                }
            }


            //Degenerate sentences.
            if (liParts[liParts.Length - 1].Trim(new char[] { ',', '«', '»', '!', ' ' }) == "o")
            {
                //We have a vocative sentence...
                Vocative vocative = new Vocative(ProcessEnPiChain(liParts[0]));
                Sentence s = new Sentence(vocative, punctuation);
                return s;
            }

            string subjects = liParts[0].Trim();

            ComplexChain subjectChain = null;
            int startAt = 1; //slot 0 is normally a subject

            if (subjects.StartCheck("o "))
            {
                //This is a verb phrase with implicit subjects!
                startAt = 0;
            }
            else
            {
                subjectChain = ProcessEnPiChain(subjects);
            }

            PredicateList verbPhrases = new PredicateList();

            for (int i = startAt; i < liParts.Length; i++)
            {
                string predicate = liParts[i].Trim();

                verbPhrases.Add(ProcessPredicates(predicate));
            }


            //if (punctuation == null)
            //{
            //    //Condition
            //    return new Sentence(subjectChain, verbPhrases);
            //}

            //Head or complete sentence.

            Sentence parsedSentence = new Sentence(subjectChain, verbPhrases, new SentenceOptionalParts
            {
                Conjunction = conjunction,
                //Etc
                Punctuation = punctuation,
                IsHortative = isHortative,
                TagQuestion = tagQuestion,
                HeadVocatives =  headVocatives!=null?headVocatives.ToArray():null
            },
            new SentenceDiagnostics(original, sentence));
            return parsedSentence;
        }

        private void ProcessHeadVocatives(string[] vocativeParts, List<Vocative> headVocatives, bool allAreVocatives)
        {
            bool vocativesDone = false;
            //Process head vocatives.
            for (int i = 0; i < vocativeParts.Length; i++)
            {
                if (!allAreVocatives)
                {
                    if (i == vocativeParts.Length-1)
                    {
                        continue;
                    }
                }
                
                string vocativePart = vocativeParts[i];
                if (vocativesDone) continue;

                if (vocativePart.ContainsCheck(" li ", " e "))
                {
                    vocativesDone = true;
                }

                ComplexChain vocativeChain = ProcessEnPiChain(vocativePart);
                Vocative v = new Vocative(vocativeChain);
                headVocatives.Add(v);
            }
        }


        public Chain ProcessPiChain(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Cannot parse null/empty subjects");
            }
            if (value.ContainsCheck(" la ") || value.EndCheck(" la"))
            {
                throw new ArgumentException("Contains la. This is not possible in a pi chain.: " + value);
            }
            //if (value.ContainsCheck("~"))
            //{
            //    throw new ArgumentException("Contains preposition. This isn't possible in a pi chain. (well not right //now. kule pi lon palisa): actual: " + value);
            //}
            //soweli ~lon ma ni pi ma suli ~sama ma ante

            string piChains = value;

            string[] piLessTokens = Splitters.SplitOnPi(piChains);

            List<HeadedPhrase> piCollection = new List<HeadedPhrase>();
            foreach (string piLessToken in piLessTokens)
            {
                HeadedPhrase piPhrase = HeadedPhraseParser(piLessToken);
                piCollection.Add(piPhrase);
            }
            return new Chain(Particles.pi, piCollection.ToArray());

        }

        public ComplexChain ProcessEnPiChain(string subjects)
        {
            if (String.IsNullOrEmpty(subjects))
            {
                throw new ArgumentException("Cannot parse null/empty subjects");
            }
            foreach (var particle in new[] { "la", "li" })
            {
                if (subjects.StartsOrContainsOrEnds(particle))
                {
                    throw new ArgumentException("Subject phrase : " + subjects + " Contains " + particle + ". This is not possible.");
                }
            }

            string[] subjectTokens = Splitters.SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            //jan ~tan ma pi pali suli ~tawa mani pi ma suli en soweli pi tawa wawa
            //jan ~tan ma pi pali suli ~tawa mani pi ma suli /en/ soweli pi tawa wawa
            //jan ~tan ma //pi// pali suli ~tawa mani //pi// ma suli /en/ soweli //pi// tawa wawa

            //BUG: Following code wraps simple chain in unnecessary complex chain.
            List<ComplexChain> subChains = new List<ComplexChain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                if (piChains == "")
                    continue; //But how did that happen?

                string[] piLessTokens = Splitters.SplitOnPi(piChains);

                List<Chain> piCollection = new List<Chain>();
                foreach (string piLessToken in piLessTokens)
                {
                    Chain piPhrase = ProcessPiChain(piLessToken);
                    piCollection.Add(piPhrase);
                }
                ComplexChain piChain = new ComplexChain(Particles.pi, piCollection.ToArray());
                subChains.Add(piChain);
            }

            if (subChains[0].SubChains.Length > 1 && subChains[0].SubChains.Last().ToString().Split(new char[] { '*', ' ', '-' }).Length == 1)
            {
                string lastWord = subChains[0].SubChains.Last().ToString();
                if (Number.IsPomanNumber(lastWord) && lastWord.Replace("#", "").Length > 1)
                {
                    //Poman numbers with 2 letters or more represent 2+ words.
                }
                else if (subjects.Contains(" en "))
                {
                    //HACK: maybe a compound modifier.  This actually usually fails.
                    return ProcessPiEnChain(subjects);
                }
                else
                {
                    throw new TpSyntaxException("final pi in pi chain must be followed by 2 words, otherwise just use juxtaposition (i.e. 2 adjacent words with no particle) : " + subjects);
                }
            }

            ComplexChain subject = new ComplexChain(Particles.en, subChains.ToArray());
            return subject;
        }


        //This only works for 1 subject!
        //kule pi walo en pimeja
        public ComplexChain ProcessPiEnChain(string subjects)
        {
            if (String.IsNullOrEmpty(subjects))
            {
                throw new ArgumentException("Cannot parse null/empty subjects");
            }
            foreach (var particle in new[] { "la", "li" })
            {
                if (subjects.StartsOrContainsOrEnds(particle))
                {
                    throw new ArgumentException("Subject phrase : " + subjects + " Contains " + particle + ". This is not possible.");
                }
            }

            string[] singleSubjectWithCompoundModifers = Splitters.SplitOnPi(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            //jan ~tan ma pi pali suli ~tawa mani pi ma suli en soweli pi tawa wawa
            //jan ~tan ma pi pali suli ~tawa mani pi ma suli /en/ soweli pi tawa wawa
            //jan ~tan ma //pi// pali suli ~tawa mani //pi// ma suli /en/ soweli //pi// tawa wawa

            //BUG: Following code wraps simple chain in unnecessary complex chain.
            List<ComplexChain> subChains = new List<ComplexChain>();
            for (int i = 0; i < singleSubjectWithCompoundModifers.Length; i++)
            {
                string piChains = singleSubjectWithCompoundModifers[i];

                if (piChains == "")
                    continue; //But how did that happen?

                string[] enLessTokens = Splitters.SplitOnEn(piChains);

                List<Chain> piCollection = new List<Chain>();
                foreach (string enLessToken in enLessTokens)
                {
                    Chain piPhrase = ProcessPiChain(enLessToken);
                    piCollection.Add(piPhrase);
                }
                ComplexChain piChain = new ComplexChain(Particles.pi, piCollection.ToArray());
                subChains.Add(piChain);
            }

            //if (subChains[0].SubChains.Length > 1 && subChains[0].SubChains.Last().ToString().Split(new char[] { '*', ' ', '-' }).Length == 1)
            //{
            //    throw new TpSyntaxException("final pi in pi chain must be followed by 2 words, otherwise just use juxtaposition (i.e. 2 adjacent words with no particle) : " + subjects);
            //}

            ComplexChain subject = new ComplexChain(Particles.en, subChains.ToArray());
            return subject;
        }


        // jan li jo e soweli e kili e wawa lon anpa tawa anpa
        //     li jo e soweli e kili e wawa lon anpa tawa anpa
        public TpPredicate ProcessPredicates(string liPart)
        {

            if (string.IsNullOrWhiteSpace(liPart))
            {
                throw new InvalidOperationException("Missing argument, cannot continue");
            }
            if (liPart == "li")
            {
                throw new InvalidOperationException("Cannot do anything with just li");
            }
            TokenParserUtils pu = new TokenParserUtils();
            Particle verbPhraseParticle;
            ComplexChain directObjectChain = null;
            VerbPhrase verbPhrase = null;
            PrepositionalPhrase[] prepositionalChain = null;
            ComplexChain nominalPredicate = null;
            PiPredicate piPredicate = null;

            //Transitive Path.
            if (liPart.Split(new[] { ' ', '\t' }).Contains("e"))
            {
                string[] eParts = Splitters.SplitOnE(liPart);

                string[] verbPhraseParts = pu.WordsPunctuationAndCompounds(eParts[0]); //Could contain particles.

                if (!Particle.CheckIsParticle(verbPhraseParts[0]))
                {
                    throw new TpSyntaxException("uh-oh not a particle: " + verbPhraseParts[0] + " from " + liPart);
                }
                verbPhraseParticle = new Particle(verbPhraseParts[0]);

                //Only process preps in normalized sentences
                string[] partsWithPreps = null;

                if (verbPhraseParts.Length > 1)
                {
                    if (verbPhraseParts.Any(x => x == "pi"))
                    {

                        //nominal predicate
                        nominalPredicate =
                            new ComplexChain(Particles.en,
                                new[]{
                                    ProcessPiChain(string.Join(" ", ArrayExtensions.Tail(verbPhraseParts)))
                                });

                    }
                    else
                    {
                        verbPhrase = VerbPhraseParser(ArrayExtensions.Tail(verbPhraseParts));

                    }
                }

                string verbsMaybePrepositions = eParts[eParts.Length - 1];


                if (verbsMaybePrepositions.ContainsCheck("~"))
                {
                    partsWithPreps = Splitters.SplitOnPrepositions(verbsMaybePrepositions);
                    if (partsWithPreps.Length == 1)
                    {
                        //This is the last e phrase or 1st prep.
                        if (partsWithPreps[0].ContainsCheck("~"))
                        {
                            //That is a prep phrase (is this possible?)
                        }
                        else
                        {
                            eParts[eParts.Length - 1] = partsWithPreps[0];
                            //No prep phrases.
                        }
                    }
                }

                string[] directObjects = ArrayExtensions.Tail(eParts);

                //List<HeadedPhrase> doNPs = new List<HeadedPhrase>();
                List<Chain> doPiChains = new List<Chain>();

                //Fancy foot work for when we have e ... ~... & that's all.
                string[] toUse;
                if (partsWithPreps != null)
                {
                    toUse = partsWithPreps.Where(x => x.StartCheck("e ")).ToArray();
                    directObjects[directObjects.Length - 1] = toUse[0];
                    toUse = directObjects;
                }
                else
                {
                    toUse = directObjects;
                }

                foreach (string directObject in toUse)
                {
                    if (directObject.Length <= 2)
                    {
                        throw new TpParseException("This is a degenerate e phrase, i.e. it is only e or e space. Missing a ni, e.g. e ni: possibly. ref: " + liPart);
                    }
                    string eFree = directObject.Substring(2);
                    Chain phrase = ProcessPiChain(eFree);
                    doPiChains.Add(phrase);
                }
                directObjectChain = new ComplexChain(Particles.e, doPiChains.ToArray());

                if (partsWithPreps != null)
                {
                    prepositionalChain = ProcessPrepositionalPhrases(partsWithPreps).ToArray();
                }
            }
            else
            {
                //Intransitives & Predictates

                string[] ppParts = Splitters.SplitOnPrepositions(liPart);

                if (ppParts.Length == 0) //Excect at least "li verb" or "li noun"
                {
                    throw new InvalidOperationException("Whoa, got " + ppParts.Length + " parts for " + liPart);
                }

                if (Punctuation.ContainsPunctuation(ppParts[0]))
                {
                    throw new InvalidOperationException("This has punctuation, may fail to parse : " + ppParts[0]);
                }
                string[] verbPhraseParts = pu.WordsPunctuationAndCompounds(ppParts[0]);

                if (!Particle.CheckIsParticle(verbPhraseParts[0]))
                {
                    throw new TpSyntaxException("uh-oh not a particle: " + verbPhraseParts[0] + " from " + liPart);
                }
                verbPhraseParticle = new Particle(verbPhraseParts[0]);


                if (verbPhraseParts.Length > 1)
                {
                    if (verbPhraseParts[0].ContainsCheck("XXXXZiXXXX"))
                    {
                        //piPredicate
                        ComplexChain phrase = new ComplexChain(Particles.en,
                            new[]{
                                    ProcessPiChain(string.Join(" ", ArrayExtensions.Tail(verbPhraseParts)))
                                });

                        piPredicate = new PiPredicate(Particles.pi, phrase);

                    }
                    else if (verbPhraseParts.Any(x => x == "pi"))
                    {
                        //nominal predicate
                        nominalPredicate = new ComplexChain(Particles.en,
                            new[]{
                                ProcessPiChain(string.Join(" ", ArrayExtensions.Tail(verbPhraseParts)))}
                            );
                    }
                    else
                    {
                        verbPhrase = VerbPhraseParser(ArrayExtensions.Tail(verbPhraseParts));

                    }
                }


                string[] prepositions = ArrayExtensions.Tail(ppParts);

                if (prepositions.Length != 0)
                {
                    List<PrepositionalPhrase> pChains = new List<PrepositionalPhrase>();
                    foreach (string pp in prepositions)
                    {
                        string[] phraseParts = pu.WordsPunctuationAndCompounds(pp);//Could contain particles.
                        string preposition = phraseParts[0];
                        string[] tail = ArrayExtensions.Tail(phraseParts);

                        if (tail.Length == 0)
                        {
                            //uh oh. This is an intransitive verb, like "ni li lon"
                            //HACK: Oh, this is so ugly (still sort of ugly)
                            verbPhrase = new VerbPhrase(new Word(preposition.Replace("~", "")));
                            //or a noun phrase.

                            continue;
                        }

                        PrepositionalPhrase foundPrepositionalPhrase = new PrepositionalPhrase(new Word(preposition), ProcessEnPiChain(string.Join(" ", tail)));
                        pChains.Add(foundPrepositionalPhrase);
                    }
                    if (pChains.Count > 0)
                    {
                        prepositionalChain = pChains.ToArray();
                    }
                    else
                    {
                        //We changed our mind about a phrase being a prep phrase. Turned out to be verb phrase or predicate.
                    }
                }
            }
            if (piPredicate != null)
            {
                return new TpPredicate(verbPhraseParticle, piPredicate, prepositionalChain);
            }
            else if (nominalPredicate == null)
                return new TpPredicate(verbPhraseParticle, verbPhrase, directObjectChain, prepositionalChain);
            else
            {
                return new TpPredicate(verbPhraseParticle, nominalPredicate, directObjectChain, prepositionalChain);

            }
        }

        private VerbPhrase VerbPhraseParser(string[] verbPhraseText)
        {
            //Adjectives & noun phrases will sneak in here. Maybe need more punctuation?

            Word[] asWords = verbPhraseText.Select(x => new Word(x)).ToArray();
            List<Word> tokens = TurnThisWordsIntoWordsWithTaggedWords(asWords);

            WordSet modals = new WordSet();
            Word headVerb = null;
            WordSet adverbs = new WordSet();
            foreach (Word token in tokens)
            {
                //modals until used up. Strictly by dictionary.
                if (headVerb == null)
                {
                    if (Token.IsModal(token))
                    {
                        modals.Add(token);
                        continue;
                    }
                }

                //head verb, only because we ran out of modals. (unless there is only one word!)
                if (headVerb == null)
                {
                    headVerb = token; //If number, proper modifier, etc, then this is not really a verb!
                    continue;
                }
                //Adverbs thereafter.
                adverbs.Add(token);
            }

            if (headVerb == null)
            {
                //Shoot!
                modals = new WordSet();
                headVerb = null;
                adverbs = new WordSet();
                foreach (Word token in tokens)
                {
                    //modals until used up. Strictly by dictionary.
                    //if (headVerb == null)
                    //{
                    //    if (Token.IsModal(token))
                    //    {
                    //        modals.Add(token);
                    //        continue;
                    //    }
                    //}

                    //head verb, only because we ran out of modals. (unless there is only one word!)
                    if (headVerb == null)
                    {
                        headVerb = token; //If number, proper modifier, etc, then this is not really a verb!
                        continue;
                    }
                    //Adverbs thereafter.
                    adverbs.Add(token);
                }
            }

            return new VerbPhrase(headVerb, modals, adverbs);
        }

        public List<PrepositionalPhrase> ProcessPrepositionalPhrases(string[] partsWithPreps)
        {
            List<PrepositionalPhrase> prepositionalChain = new List<PrepositionalPhrase>();
            foreach (string partsWithPrep in partsWithPreps)
            {
                if (partsWithPrep.ContainsCheck("~")) //Is it really?
                {
                    TokenParserUtils pu = new TokenParserUtils();
                    string preposition = pu.WordsPunctuationAndCompounds(partsWithPrep)[0];
                    string tail = partsWithPrep.Replace(preposition, "").Trim();
                    //These chains are ordered.
                    //kepeken x lon y kepeken z lon a   NOT EQUAL TO kepeken x  kepeken z lon a lon y
                    //Maybe.
                    prepositionalChain.Add(new PrepositionalPhrase(new Word(preposition), string.IsNullOrEmpty(tail) ? null : ProcessEnPiChain(tail)));
                }
                else
                {
                    //Is that surprising?
                    //The first part is not a prep phrase, it is a verb intr or predicate.
                    // throw new InvalidOperationException("Why doesn't a part with Prep contain a ~?");
                }
            }
            return prepositionalChain;
        }

        public HeadedPhrase HeadedPhraseParser(string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            foreach (string s in value)
            {
                if (s.ContainsCheck(" "))
                {
                    throw new ArgumentException("One of the strings in the array contains spaces, this must not have been properly normalized.: " + s);
                }
                if (s.ContainsCheck("~"))
                {
                    throw new ArgumentException("One of the strings in the array starts with a ~, so the prep wasn't stripped off. : " + s);
                }
            }

            //No Pi!
            HeadedPhrase phrase = new HeadedPhrase(new Word(value[0]), new WordSet(ArrayExtensions.Tail(value)));
            return phrase;
        }

        /// <summary>
        /// Parses simple headed phrases fine. Parses some headed phrases with PP modifiers, but
        /// not if the PP is in maximal form.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public HeadedPhrase HeadedPhraseParser(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }

            foreach (string particle in new[] { "pi", "la", "e", "li" })
            {
                if (value.StartsOrContainsOrEnds(particle))
                {
                    throw new TpSyntaxException("Headed phrases have no particles. This one has " + particle + " ref: " + value + " (Did we forget the li between the subject and verb?)");
                }
            }

            PrepositionalPhrase[] pp = null;
            if (value.ContainsCheck("~"))
            {
                string[] headAndPreps = Splitters.SplitOnPrepositions(value);
                value = headAndPreps[0];
                pp = ProcessPrepositionalPhrases(ArrayExtensions.Tail(headAndPreps)).ToArray();
            }
            //No Pi!
            TokenParserUtils pu = new TokenParserUtils();

            Word[] words = pu.ValidWords(value);


            if (words.Length == 0)
            {
                throw new InvalidOperationException("Failed to parse: " + value);
            }
            //Word head = words[0];
            Word[] tail = words;//ArrayExtensions.Tail(words);

            //EXTRACT MORPHOLOGICAL STRUCTURE OF MODIFIERS HERE.

            var mergedTail = TurnThisWordsIntoWordsWithTaggedWords(tail);


            HeadedPhrase phrase = new HeadedPhrase(mergedTail[0],
                new WordSet(ArrayExtensions.Tail(mergedTail.ToArray())),
                pp);
            return phrase;
        }

        public List<Word> TurnThisWordsIntoWordsWithTaggedWords(Word[] tail)
        {
            Word currentWord = tail[0];
            List<Word> mergedTail = new List<Word>();
            bool skipNext = false;
            //jan pona kin.
            bool wordInProgress = false;
            if (tail.Length > 1)
            {
                //mergedTail.Add(currentWord);
                int resumeAt = -1;
                for (int i = 0; i < tail.Length; i++)
                {
                    currentWord = tail[i];
                    if (resumeAt != -1)
                    {
                        if (i < resumeAt) continue;
                    }

                    bool stopLookAhead = false;
                    TaggedWord possible = null;
                    for (int j = tail.Length - 1; j > i; j--)
                    {
                        if (stopLookAhead) continue; //PERF prob here.


                        try
                        {
#if VS2013
                            possible = new TaggedWord(currentWord, new WordList(new ArraySegment<Word>(tail, i + 1, j - i)));
#else
                            possible = new TaggedWord(currentWord, new WordList(tail.Skip(i + 1).Take(j - i)));
#endif

                            resumeAt = j + 1;
                            stopLookAhead = true; //we found the largest possible. now stop.
                        }
                        catch (InvalidOperationException ex)
                        {
                            //resumeAt = j + 1;
                        }
                    }

                    //Okay, we looked everywhere.
                    if (possible == null)
                    {
                        //This isn't a suitable head for a TaggedWord.
                        mergedTail.Add(currentWord);
                    }
                    else
                    {
                        mergedTail.Add(possible);
                    }

                    //if (skipNext)
                    //{
                    //    skipNext = false;
                    //    continue;
                    //}
                    //Word following = tail[i];
                    //if (TaggedWord.TagWords.Contains(following.Text))
                    //{
                    //    //kin, ala
                    //    currentWord = new TaggedWord(currentWord, new WordList() {following});
                    //    wordInProgress = true;
                    //    continue;
                    //}
                    //if (i < tail.Length - 1 && following.Text == "ala" && tail[i + 1] == currentWord.Text)
                    //{

                    //    //x ala x
                    //    currentWord = new TaggedWord(currentWord, new WordList() {following, tail[i + 1]});
                    //    skipNext = true;
                    //    wordInProgress = true;
                    //    continue;
                    //}
                    //if (i < tail.Length - 1 && currentWord.Text == tail[i + 1])
                    //{
                    //    //reduplication, 1 level.
                    //    currentWord = new TaggedWord(currentWord, new WordList() { tail[i + 1] });
                    //    wordInProgress = true;
                    //    continue;
                    //}

                    ////Done or wasn't a tag word.
                    //if (wordInProgress)
                    //{
                    //    mergedTail.Add(currentWord);
                    //}
                    //else
                    //{
                    //    currentWord = following;
                    //    mergedTail.Add(currentWord);
                    //}
                    //wordInProgress = false;
                }
                //if (wordInProgress)
                //{
                //    mergedTail.Add(currentWord);
                //}
            }
            else
            {
                mergedTail.Add(tail[0]);
            }
            return mergedTail;
        }

        public string[] FindXalaX(string value)
        {
            Regex x = new Regex(@"\b(\w+)\s+ala\s+\1\b");
            List<string> s = new List<string>();
            foreach (var v in x.Matches(value))
            {
                s.Add(v.ToString());
            }
            return s.ToArray();
        }
    }
}
