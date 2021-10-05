using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyzerProblem1;

namespace MsTestforMoodAnalyzer
{
    [TestClass]

    public class MsTestForMoodAnalyzer
    {
        [TestMethod]
        [TestCategory("negativescenario")]
        public void GivenNullShouldReturnHappy()
        {
            //Arrange
            string excepted = "happy";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(null);

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }
    }
}