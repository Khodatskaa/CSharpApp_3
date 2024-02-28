using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpApp_3
{
    public class Program
    {
        static void Main()
        {
            // Task 1
            int[] numbers = { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10, 10 };
            NumberAnalyzer numberAnalyzer = new NumberAnalyzer();
            numberAnalyzer.AnalyzeNumbers(numbers);

            // Task 2
            int[] numbers2 = { 2, 4, 6, 8, 10, 12 };
            NumberCounter numberCounter = new NumberCounter();
            numberCounter.CountValuesLessThan(numbers2, 7);

            // Task 3
            int[] array = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };
            int[] sequence = { 7, 6, 5 };
            SequenceCounter sequenceCounter = new SequenceCounter();
            sequenceCounter.CountSequenceOccurrences(array, sequence);

            // Task 4
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 4, 5, 6, 7, 8 };
            ArrayMerger arrayMerger = new ArrayMerger();
            int[] mergedArray = arrayMerger.MergeArraysWithoutRepetition(array1, array2);
            Console.WriteLine($"Merged Array: {string.Join(", ", mergedArray)}");

            // Task 5
            int[,] twoDArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            TwoDArrayAnalyzer twoDArrayAnalyzer = new TwoDArrayAnalyzer();
            twoDArrayAnalyzer.FindMinMax(twoDArray);

            // Task 6
            string sentence = "The quick brown fox jumps over the lazy dog";
            WordCounter wordCounter = new WordCounter();
            int wordCount = wordCounter.CountWords(sentence);
            Console.WriteLine($"Word Count: {wordCount}");

            // Task 7
            WordReverser wordReverser = new WordReverser();
            string reversedWords = wordReverser.ReverseWords(sentence);
            Console.WriteLine($"Reversed Words: {reversedWords}");

            // Task 8
            VowelCounter vowelCounter = new VowelCounter();
            int vowelCount = vowelCounter.CountVowels(sentence);
            Console.WriteLine($"Vowel Count: {vowelCount}");

            // Task 9
            string sourceString = "Why she had to go. I don't know, she wouldn't say";
            string searchWord = "she";
            SubstringCounter substringCounter = new SubstringCounter();
            int substringCount = substringCounter.CountSubstringOccurrences(sourceString, searchWord);
            Console.WriteLine($"Substring Count: {substringCount}");
        }
    }

    public class NumberAnalyzer
    {
        public void AnalyzeNumbers(int[] numbers)
        {
            int evenCount = numbers.Count(n => n % 2 == 0);
            int oddCount = numbers.Count(n => n % 2 != 0);
            int uniqueCount = numbers.Distinct().Count();

            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Unique Count: {uniqueCount}");
        }
    }

    public class NumberCounter
    {
        public void CountValuesLessThan(int[] numbers, int threshold)
        {
            int count = numbers.Count(n => n < threshold);
            Console.WriteLine($"Number of values less than {threshold}: {count}");
        }
    }

    public class SequenceCounter
    {
        public void CountSequenceOccurrences(int[] array, int[] sequence)
        {
            int count = 0;
            for (int i = 0; i <= array.Length - sequence.Length; i++)
            {
                if (array.Skip(i).Take(sequence.Length).SequenceEqual(sequence))
                {
                    count++;
                }
            }

            Console.WriteLine($"Number of repetitions of the sequence: {count}");
        }
    }

    public class ArrayMerger
    {
        public int[] MergeArraysWithoutRepetition(int[] array1, int[] array2)
        {
            return array1.Union(array2).ToArray();
        }
    }

    public class TwoDArrayAnalyzer
    {
        public void FindMinMax(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int current = array[i, j];
                    min = Math.Min(min, current);
                    max = Math.Max(max, current);
                }
            }

            Console.WriteLine($"Minimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");
        }
    }

    public class WordCounter
    {
        public int CountWords(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }

    public class WordReverser
    {
        public string ReverseWords(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }

    public class VowelCounter
    {
        public int CountVowels(string sentence)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";

            foreach (char c in sentence)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            return count;
        }
    }

    public class SubstringCounter
    {
        public int CountSubstringOccurrences(string source, string searchWord)
        {
            int count = 0;
            int index = 0;

            while ((index = source.IndexOf(searchWord, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                index += searchWord.Length;
                count++;
            }

            return count;
        }
    }
}

