﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTest.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void GeneralTest()
        {
            Assert.IsTrue(Figure.isTriangle(1, 1, 1));
        }

        [TestMethod()]
        public void ZeroTest()
        {
            Assert.IsFalse(Figure.isTriangle(1, 0, 1));
        }

        [TestMethod()]
        public void MinusTest()
        {
            Assert.IsFalse(Figure.isTriangle(-1, 1, 1));
        }

        [TestMethod()]
        public void ConvertTest()
        {
            Assert.IsTrue(Figure.isTriangle(Convert.ToDouble("1,1"), 1, 1));
        }

        [TestMethod()]
        public void BoundaryTest()
        {
            Assert.IsFalse(Figure.isTriangle(0.00000000000000000000000000000000000000000000000001, 1, 1));
        }

        [TestMethod()]
        public void MaxMinValueTest()
        {
            Assert.IsFalse(Figure.isTriangle(double.MaxValue, 2 * double.MinValue, double.MaxValue));
        }

        [TestMethod()]
        public void MaxValueTest()
        {
            Assert.IsTrue(Figure.isTriangle(double.MaxValue, double.MaxValue, double.MaxValue));
        }

        [TestMethod()]
        public void UpperMaxValueTest()
        {
            Assert.IsFalse(Figure.isTriangle(double.MaxValue + double.MinValue, double.MaxValue + double.MinValue, double.MaxValue + double.MinValue));
        }

        [TestMethod()]
        public void BoundaryLowerTest()
        {
            Assert.IsTrue(Figure.isTriangle(1 + 0.000000011, 2, 3 + 0.00000001));
        }

        [TestMethod()]
        public void BoundaryUpperTest()
        {
            Assert.IsFalse(Figure.isTriangle(1, 2, 3 + 0.00000001));
        }

    }
}