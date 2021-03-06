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

        [TestMethod]
        public void GivenMoodAnalyzeClasssNameShouldReturnMoodAnalyzeObject()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyze("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyzeClassNameShouldReturnObjectUsingParameterizedConstructor()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyzerFactory.CreatemoodAnalyzeUsingParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "HAPPY");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string actual = MoodAnalyzerFactory.InvokeAnalyzeMood("HAPPY", "AnalyzeMood");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyzerFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        
        [TestMethod]
        public void SetField_ImProper_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyzerFactory.SetField("HAPPY", "me");
            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        
        [TestMethod]
        public void Setting_NullMessge_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyzerFactory.SetField(null, "message");
            }
            catch (MoodAnalyzerException exception)
            {
                Assert.AreEqual("Message should not be null", exception.Message);
            }
        }

    }
}