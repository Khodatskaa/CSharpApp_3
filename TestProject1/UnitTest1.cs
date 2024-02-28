using CSharpApp_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSharpApp_3.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestNumberAnalyzer()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10, 10 };
            NumberAnalyzer numberAnalyzer = new NumberAnalyzer();

            Assert.AreEqual(6, numberAnalyzer.CountEven(numbers));
            Assert.AreEqual(6, numberAnalyzer.CountOdd(numbers));
            Assert.AreEqual(10, numberAnalyzer.CountUnique(numbers));
        }

        [TestMethod]
        public void TestNumberCounter()
        {
            int[] numbers = { 2, 4, 6, 8, 10, 12 };
            NumberCounter numberCounter = new NumberCounter();

            Assert.AreEqual(3, numberCounter.CountValuesLessThan(numbers, 7));
        }

        [TestMethod]
        public void TestSequenceCounter()
        {
            int[] array = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };
            int[] sequence = { 7, 6, 5 };
            SequenceCounter sequenceCounter = new SequenceCounter();

            Assert.AreEqual(3, sequenceCounter.CountSequenceOccurrences(array, sequence));
        }

        [TestMethod]
        public void TestArrayMerger()
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 4, 5, 6, 7, 8 };
            ArrayMerger arrayMerger = new ArrayMerger();

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, arrayMerger.MergeArraysWithoutRepetition(array1, array2));
        }

        [TestMethod]
        public void TestTwoDArrayAnalyzer()
        {
            int[,] twoDArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            TwoDArrayAnalyzer twoDArrayAnalyzer = new TwoDArrayAnalyzer();

            Assert.AreEqual(1, twoDArrayAnalyzer.FindMin(twoDArray));
            Assert.AreEqual(9, twoDArrayAnalyzer.FindMax(twoDArray));
        }

        [TestMethod]
        public void TestWordCounter()
        {
            string sentence = "The quick brown fox jumps over the lazy dog";
            WordCounter wordCounter = new WordCounter();

            Assert.AreEqual(9, wordCounter.CountWords(sentence));
        }

        [TestMethod]
        public void TestWordReverser()
        {
            string sentence = "sun cat dogs cup tea";
            WordReverser wordReverser = new WordReverser();

            Assert.AreEqual("nus tac sgod puc aet", wordReverser.ReverseWords(sentence));
        }

        [TestMethod]
        public void TestVowelCounter()
        {
            string sentence = "The quick brown fox jumps over the lazy dog";
            VowelCounter vowelCounter = new VowelCounter();

            Assert.AreEqual(9, vowelCounter.CountVowels(sentence));
        }

        [TestMethod]
        public void TestSubstringCounter()
        {
            string sourceString = "Why she had to go. I don't know, she wouldn't say";
            string searchWord = "she";
            SubstringCounter substringCounter = new SubstringCounter();

            Assert.AreEqual(2, substringCounter.CountSubstringOccurrences(sourceString, searchWord));
        }
    }

}
