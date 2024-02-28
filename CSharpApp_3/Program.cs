using System;
using System.Linq;

namespace CSharpApp_3
{
    public class Program
    {
        static void Main()
        {
            // Task 1
            double[] A = new double[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Task 1: Enter 5 numbers for array A:");
            for (int i = 0; i < 5; i++)
            {
                A[i] = Convert.ToDouble(Console.ReadLine());
            }

            Random random = new();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble();
                }
            }

            Console.WriteLine("\nArray A:");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nArray B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }

            double maxA = A.Max();
            double minA = A.Min();
            double sumA = A.Sum();
            double productA = A.Aggregate(1.0, (acc, x) => acc * x);
            double sumEvenA = A.Where(x => x % 2 == 0).Sum();
            double sumOddColumnsB = B.Cast<double>().Where((_, index) => index % 4 % 2 != 0).Sum();

            Console.WriteLine($"\nMax of A: {maxA}");
            Console.WriteLine($"Min of A: {minA}");
            Console.WriteLine($"Sum of A: {sumA}");
            Console.WriteLine($"Product of A: {productA}");
            Console.WriteLine($"Sum of even elements in A: {sumEvenA}");
            Console.WriteLine($"Sum of odd columns in B: {sumOddColumnsB}");

            // Task 2
            Console.WriteLine("\nTask 2:");
            int minIndex = 0, maxIndex = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (B[i, j] < B[minIndex, maxIndex])
                    {
                        minIndex = i;
                        maxIndex = j;
                    }
                }
            }

            double sumTask2 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == minIndex && j > minIndex && j < maxIndex)
                    {
                        sumTask2 += B[i, j];
                    }
                    else if (i == minIndex + 1 && j <= maxIndex)
                    {
                        sumTask2 += B[i, j];
                    }
                    else if (i == minIndex + 2 && j <= maxIndex)
                    {
                        sumTask2 += B[i, j];
                    }
                }
            }

            Console.WriteLine($"Sum of elements between minimum and maximum: {sumTask2}");

            // Task 3
            Console.WriteLine("\nTask 3:");
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();
            Console.WriteLine("Enter the shift for Caesar cipher:");
            int shift = int.Parse(Console.ReadLine());

            string encryptedString = EncryptCaesarCipher(inputString, shift);
            Console.WriteLine($"Encrypted String: {encryptedString}");

            // Task 4
            Console.WriteLine("\nTask 4:");
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

            int[,] resultMatrix = MatrixOperations.MultiplyMatrices(matrix1, matrix2);

            // Task 5
            Console.WriteLine("\nTask 5:");
            Console.WriteLine("Enter an arithmetic expression:");
            string arithmeticExpression = Console.ReadLine();

            int resultTask5 = ArithmeticCalculator.CalculateExpression(arithmeticExpression);
            Console.WriteLine($"Result: {resultTask5}");

            // Task 6
            Console.WriteLine("\nTask 6:");
            Console.WriteLine("Enter text:");
            string inputTextTask6 = Console.ReadLine();

            string resultTextTask6 = TextCaseConverter.ConvertFirstLetterToUpper(inputTextTask6);
            Console.WriteLine($"Result: {resultTextTask6}");

            // Task 7
            Console.WriteLine("\nTask 7:");
            Console.WriteLine("Enter text:");
            string inputTextTask7 = Console.ReadLine();

            string[] invalidWords = ["invalid1", "invalid2", "invalid3"];
            string resultTextTask7 = InvalidWordChecker.CheckAndReplaceInvalidWords(inputTextTask7, invalidWords);
            Console.WriteLine($"Result: {resultTextTask7}");
        }

        static string EncryptCaesarCipher(string input, int shift)
        {
            char[] result = input.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    char offset = char.IsUpper(result[i]) ? 'A' : 'a';
                    result[i] = (char)((result[i] + shift - offset) % 26 + offset);
                }
            }

            return new string(result);
        }

        class MatrixOperations
        {
            public static int[,] MultiplyByNumber(int[,] matrix, int factor)
            {
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);

                int[,] result = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = matrix[i, j] * factor;
                    }
                }

                return result;
            }

            public static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
            {
                int rows = matrix1.GetLength(0);
                int columns = matrix1.GetLength(1);

                int[,] result = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                return result;
            }

            public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
            {
                int rows1 = matrix1.GetLength(0);
                int columns1 = matrix1.GetLength(1);
                int columns2 = matrix2.GetLength(1);

                int[,] result = new int[rows1, columns2];

                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < columns2; j++)
                    {
                        for (int k = 0; k < columns1; k++)
                        {
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }

                return result;
            }
        }

        class ArithmeticCalculator
        {
            public static int CalculateExpression(string expression)
            {
                string[] terms = expression.Split('+', '-');

                int result = int.Parse(terms[0]);

                for (int i = 1; i < terms.Length; i++)
                {
                    if (expression[i - 1] == '+')
                    {
                        result += int.Parse(terms[i]);
                    }
                    else if (expression[i - 1] == '-')
                    {
                        result -= int.Parse(terms[i]);
                    }
                }

                return result;
            }
        }

        class TextCaseConverter
        {
            public static string ConvertFirstLetterToUpper(string input)
            {
                string[] sentences = input.Split('.');

                for (int i = 0; i < sentences.Length; i++)
                {
                    sentences[i] = sentences[i].Trim();

                    if (!string.IsNullOrEmpty(sentences[i]))
                    {
                        sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i][1..];
                    }
                }

                return string.Join(". ", sentences);
            }
        }

        class InvalidWordChecker
        {
            public static string CheckAndReplaceInvalidWords(string input, string[] invalidWords)
            {
                foreach (var word in invalidWords)
                {
                    if (input.Contains(word))
                    {
                        input = input.Replace(word, new string('*', word.Length));
                    }
                }

                return input;
            }
        }
    }
}
