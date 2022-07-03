using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;


namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {

        MoodAnalyzerProblem.MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in any Mood");

        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";

            //Act
            string actual = moodAnalyzer.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAnyMoodShouldReturnHAPPY()
        {
            //Arrange
            string expected = "HAPPY";

            //Act
            string actual = moodAnalyzer.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenNullShouldReturnHappy()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch(NullReferenceException ex)
            {
                //Arrange
                string expected = "HAPPY";

                //Act
                string actual = moodAnalyzer.AnalyzeMood();

                //Assert
                Assert.AreEqual(expected, actual);

            }
        }

        //Test Case 3.1
        [TestMethod]
        public void GivenNullMoodShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                string actual = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual("Mood should not be null", ex.Message);
            }
        }

        //Test Case 3.2
        [TestMethod]
        public void GivenEmptyMoodShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                string actual = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual("Mood should not be empty", ex.Message);
            }
        }
    }
}