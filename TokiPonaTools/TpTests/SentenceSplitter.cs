using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TpLogic;

namespace TpTests
{
    [TestFixture]
    public class SentenceSplitter
    {
        [Test]
        public void SplitSentence()
        {
            SentenceProcessor sp = new SentenceProcessor();
            string test =
                @"mi pilin pona. mi ken ala ken lukin e ni? ni li suli! mi wile e ni: jan li pona.";

            Collection<Sentence> sentences = sp.SplitIntoSentences(test);
            Assert.AreEqual(5,sentences.Count);
        }


        [Test]
        public void SplitSubjects()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string test =
                @"soweli li pilin pona.";

            Collection<Subject> subjects = sp.SplitIntoSubjects(test);
            Assert.AreEqual(1, subjects.Count);
        }


        [Test]
        public void SplitSubjectsInBigSentence()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string text =
                @"mije pi lawa sewi suli li kama anpa e mije ante li kama unpa e meli mute li kama pana e soweli lili mute";
            Collection<Subject> subjects = sp.SplitIntoSubjects(text);
            Assert.AreEqual(1, subjects.Count);
            Assert.AreEqual("mije pi lawa sewi suli", subjects[0].Text);
        }

        [Test]
        public void SplitSubjectsWithEn()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string test =
                @"soweli en waso li pilin pona.";

            Collection<Subject> subjects = sp.SplitIntoSubjects(test);
            Assert.AreEqual(2, subjects.Count);
        }

        [Test]
        public void SplitSubjectsWithAnu()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string test =
                @"soweli anu waso li pilin pona.";

            Collection<Subject> subjects = sp.SplitIntoSubjects(test);
            Assert.AreEqual(2, subjects.Count);
        }

        [Test]
        public void SplitSubjectsWithOrCheckText()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string test =
                @"soweli anu waso li pilin pona.";

            Collection<Subject> subjects = sp.SplitIntoSubjects(test);
            Assert.AreEqual("soweli", subjects[0].Text);
            Assert.AreEqual("waso", subjects[1].Text);
        }

        [Test]
        public void SplitSubjectsWithAndCheckText()
        {
            SubjectProcessor sp = new SubjectProcessor();
            string test =
                @"soweli en waso li pilin pona.";

            Collection<Subject> subjects = sp.SplitIntoSubjects(test);
            Assert.AreEqual("soweli", subjects[0].Text);
            Assert.AreEqual("waso", subjects[1].Text);
        }


        [Test]
        public void SplitVerbPhrasesCount1()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli en waso li pilin pona.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(1, subjects.Count);
        }

        [Test]
        public void SplitVerbPhrasesCount2()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli en waso li pilin pona li moku e moku.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(2, subjects.Count);
        }

        [Test]
        public void SplitVerbPhrasesCount3()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"mije pi lawa sewi suli li kama anpa e mije ante li kama unpa e meli mute li kama pana e soweli lili mute.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(3, subjects.Count);
        }

        [Test]
        public void SplitVerbPhrasesCount4()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"mije pi lawa sewi suli li moku e telo pimeja li kama anpa e mije ante li kama unpa e meli mute li kama pana e soweli lili mute.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(4, subjects.Count);
        }

        [Test]
        public void SplitVerbPhrasesCountSingleThenPhrase()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli pi lawa sewi li soweli li lon ma Apika.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(2, subjects.Count);
        }
        
        [Test]
        public void SplitVerbPhrasesIdentitySingleThenPhrase()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli pi lawa sewi li soweli li lon ma Apika.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual("soweli", subjects[0].Text);
            Assert.AreEqual("lon ma Apika", subjects[1].Text);
        }
        


        [Test]
        public void SplitVerbPhrasesIndentifyTwoParts()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli en waso li pilin pona li moku e moku.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual("pilin pona", subjects[0].Text);
            Assert.AreEqual("moku e moku", subjects[1].Text);
        }


        [Test]
        public void SplitVerbPhrasesIndentifyTransitives()
        {
            VerbPhraseProcessor sp = new VerbPhraseProcessor();
            string test =
                @"soweli en waso li pilin pona li moku e moku.";

            Collection<VerbPhrase> subjects = sp.SplitIntoVerbPhrases(test);
            Assert.AreEqual(VerbPhraseType.Transitive, subjects[1].Type);
        }


        [Test]
        public void SplitNounPhrases()
        {
            NounPhraseProcessor sp = new NounPhraseProcessor();
            string test =
                @"soweli pi lawa sewi";

            Collection<NounPhrase> phrases = sp.SplitIntoNounPhrases(test);
            Assert.AreEqual(2, phrases.Count);
        }

        

        [Test]
        public void FindSingleTailPrepPhrase()
        {
            PrepositionalPhraseProcessor sp = new PrepositionalPhraseProcessor();
            string test =
                @"li lon ma Apika.";

            Collection<PrepositionalPhrase> subjects = sp.SplitIntoPrepPhrases(test);
            Assert.AreEqual(1, subjects.Count);
            Assert.AreEqual("ma Apika", subjects[0].Text);
           // Assert.AreEqual(PpType.lon, subjects[0].Type);
        }

        [Test]
        public void FindSingleTailPrepPhraseWithLiLessVerbPhrase()
        {
            PrepositionalPhraseProcessor sp = new PrepositionalPhraseProcessor();
            string test =
                @"lon ma Apika.";

            Collection<PrepositionalPhrase> subjects = sp.SplitIntoPrepPhrases(test);
            Assert.AreEqual(1, subjects.Count);
            Assert.AreEqual("ma Apika", subjects[0].Text);
            //Assert.AreEqual(PpType.lon, subjects[0].Type);
        }

        [Test]
        public void SplitPrepPhrasesCount4()
        {
            PrepositionalPhraseProcessor sp = new PrepositionalPhraseProcessor();
            string test =
                @"mi lape lon supa sama kiwen tan pali tawa wawa poka jan kepeken ilo.";

            Collection<PrepositionalPhrase> subjects = sp.SplitIntoPrepPhrases(test);
            Assert.AreEqual(6, subjects.Count);
        }


        [Test]
        public void SplitPrepPhrasesCount6WithEPhraseAndPrepsBefore()
        {
            PrepositionalPhraseProcessor sp = new PrepositionalPhraseProcessor();
            string test =
                @"sama en kepeken en tawa mi lape e lape lon supa sama kiwen tan pali tawa wawa poka jan kepeken ilo.";

            Collection<PrepositionalPhrase> subjects = sp.SplitIntoPrepPhrases(test);
            Assert.AreEqual(6, subjects.Count);
        }

        [Test]
        public void FindTheDos()
        {
            DirectObjectProcessor sp = new DirectObjectProcessor();
            string test =
                @"mi mute li lukin e soweli e kala e jan suli.";

            Collection<DirectObject> subjects = sp.SplitIntoDirectObjects(test);
            Assert.AreEqual(3, subjects.Count);
        }

        [Test]
        public void FindTheModals()
        {
            Lexicon l= new Lexicon();
            ModalProcessor sp = new ModalProcessor(l);
            string test =
                @"wile ken kama sona e ni wile ken kama.";

            Collection<Modal> subjects = sp.SplitIntoModals(test);
            Assert.AreEqual(3, subjects.Count);
        }

        [Test]
        public void FindTheSingleModal()
        {
            Lexicon l= new Lexicon();
            ModalProcessor sp = new ModalProcessor(l);
            string test =
                @"kama anpa e mije ante";

            Collection<Modal> subjects = sp.SplitIntoModals(test);
            Assert.AreEqual(1, subjects.Count);
            Assert.AreEqual("kama", subjects[0].Text);
        }
        

        [Test]
        public void FindThatThereAreNoModals()
        {
            Lexicon l = new Lexicon();
            ModalProcessor sp = new ModalProcessor(l);
            string test =
                @"unpa tawa sona e ni wile ken kama.";

            Collection<Modal> subjects = sp.SplitIntoModals(test);
            Assert.AreEqual(0, subjects.Count);
        }

        [Test]
        public void FindThatThereAreNoModalsPostVerbPreE()
        {
            Lexicon l = new Lexicon();
            ModalProcessor sp = new ModalProcessor(l);
            string test =
                @"unpa tawa sona wile ken kama e ni wile ken kama.";

            Collection<Modal> subjects = sp.SplitIntoModals(test);
            Assert.AreEqual(0, subjects.Count);
        }

        [Test]
        public void PostModalTail()
        {
            Lexicon l = new Lexicon();
            ModalProcessor sp = new ModalProcessor(l);
            string test =
                @"wile ken kama unpa tawa sona e ni wile ken kama.";

            Collection<Modal> subjects = sp.SplitIntoModals(test);
            Assert.AreEqual("unpa tawa sona", sp.Tail);
        }
    }
}
