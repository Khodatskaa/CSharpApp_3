using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class ProgramTests
    {
        private StringWriter mockConsole;

        [TestInitialize]
        public void Initialize()
        {
            mockConsole = new StringWriter();
            Console.SetOut(mockConsole);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockConsole.Dispose();
        }

        [TestMethod]
        public void TestTask1()
        {
            // Arrange
            string input = "1\n2\n3\n4\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Max of A: "));
            Assert.IsTrue(output.Contains("Min of A: "));
            Assert.IsTrue(output.Contains("Sum of A: "));
            Assert.IsTrue(output.Contains("Product of A: "));
            Assert.IsTrue(output.Contains("Sum of even elements in A: "));
            Assert.IsTrue(output.Contains("Sum of odd columns in B: "));
        }

        [TestMethod]
        public void TestTask2()
        {
            // Arrange
            StringReader stringReader = new StringReader("0.1\n0.2\n0.3\n0.4\n0.5\n");
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Sum of elements between minimum and maximum: "));
        }

        [TestMethod]
        public void TestTask3()
        {
            // Arrange
            StringReader stringReader = new StringReader("abc\n3\n");
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Encrypted String: "));
        }

        [TestMethod]
        public void TestTask4()
        {
            // Arrange & Act
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Result: "));
        }

        [TestMethod]
        public void TestTask5()
        {
            // Arrange
            string input = "5+2-3";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Result: 4"));
        }

        [TestMethod]
        public void TestTask6()
        {
            // Arrange
            StringReader stringReader = new StringReader("today is a good day for walking. i will try to walk near the sea.");
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("Today is a good day for walking. I will try to walk near the sea."));
        }

        [TestMethod]
        public void TestTask7()
        {
            // Arrange
            StringReader stringReader = new StringReader("This is an invalid1 word in a sentence. Another sentence with invalid2 word.");
            Console.SetIn(stringReader);

            // Assert
            string output = mockConsole.ToString();
            Assert.IsTrue(output.Contains("This is an ******* word in a sentence. Another sentence with ******* word."));
        }
    }

}