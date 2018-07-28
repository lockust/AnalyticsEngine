using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AnalyticsEngine.Tests
{
    [TestClass]
    public class TestEngine
    {
        
        [TestMethod]
        public void TestBasicFunctionality()
        {
            var numbers = new List<double>() { 1.223, 40.2123, 1.123, 1.123, 1.123 };
            var calc = new AnalyticsCalculator(numbers);
            var analytics = calc.GetAnalytics();
            Assert.AreEqual(8.9609, Math.Round(analytics.Mean, 4));
            Assert.AreEqual(15.6258, Math.Round(analytics.StdDev, 4));
            Assert.AreEqual(0.80, analytics.Frequencies[0].Frequency);
            Assert.AreEqual(0.20, analytics.Frequencies[4].Frequency);
            Assert.AreEqual(0.00, analytics.Frequencies[1].Frequency);
        }

        [TestMethod]
        public void TestExtremeValues()
        {
            var numbers = new List<double>() { 0, 100};
            var calc = new AnalyticsCalculator(numbers);
            var analytics = calc.GetAnalytics();
            Assert.AreEqual(50.00, Math.Round(analytics.Mean, 4));
            Assert.AreEqual(0.50, analytics.Frequencies[0].Frequency);
            Assert.AreEqual(0.50, analytics.Frequencies[10].Frequency);
            Assert.AreEqual(0.00, analytics.Frequencies[1].Frequency);
            Assert.AreEqual(0.00, analytics.Frequencies[9].Frequency);
        }
        [TestMethod]
        public void TestEmptyValues()
        {
            var numbers = new List<double>();
            var calc = new AnalyticsCalculator(numbers);
            var analytics = calc.GetAnalytics();
            Assert.AreEqual(double.NaN, Math.Round(analytics.Mean, 4));
            Assert.AreEqual(double.NaN, analytics.Frequencies[0].Frequency);
            Assert.AreEqual(double.NaN, analytics.Frequencies[10].Frequency);
            Assert.AreEqual(double.NaN, analytics.Frequencies[1].Frequency);
            Assert.AreEqual(double.NaN, analytics.Frequencies[9].Frequency);
        }

    }
}
