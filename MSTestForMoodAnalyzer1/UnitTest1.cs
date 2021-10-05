using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem1;

namespace MsTestForMoodAnalyzer1
{
    [TestClass]
    [TestCategory("sadgroup")]
    public class MsTestForMoodAnalyzer1
    {

        [TestMethod]
        public void GivenSadShouldReturnSad()
        {

            //Arrange
            string excepted = "sad";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in a sad Mood");

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        [TestCategory("happygroup")]
        public void GivenAnyShouldReturnHappy()
        {
            //AAA Methology

            //Arrange
            string excepted = "happy";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in any Mood");

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }
    }
}