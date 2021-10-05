using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem1;

namespace MsTestforMoodAnalyzer
{
    [TestClass]
    public class MsTestForMoodAnalyzer
    {
        [TestMethod]
        [TestCategory("Customexception")]
        public void GivenNullShouldReturnCustomNullException()
        {
            //Arrange
            string expected = "Message should not be null";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(null);
            try
            {
                //ACT
                string actual = moodAnalyser.AnalyzeMood();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Customexception")]
        public void GivenEmptyShouldReturnCustomEmptyException()
        {

            //Arrange
            string expected = "Message should not be empty";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(string.Empty);
            try
            {
                //ACT
                string actual = moodAnalyser.AnalyzeMood();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

        /// TC-4 Create Default Constructor Using Reflection
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Given_MoodAnalyzer_Using_Reflection_Return_defaultConstructor()
        {
            //Creating object of the class to test
            MoodAnalyzer expected = new MoodAnalyzer();
            object obj = null;
            try
            {
                //ACT
                //
                ModeAnalyzerFactory factory = new ModeAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                throw new Exception(ex.Message);
            }
            obj.Equals(expected);
        }
        //For negative scenario, if class or constrotor name passed wrong it will give custom exception message
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyzerUsingReflectionReturnException()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerFactory factory = new ModeAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnaly");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}