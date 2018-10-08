using System;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    class NUnitTests
    {
        [Test]
        public void GeneralTest()
        {
            Assert.IsTrue(Figure.isTriangle(1, 1, 1));
        }

        [Test]
        public void ZeroTest()
        {
            Assert.IsFalse(Figure.isTriangle(1, 0, 1));
        }

        [Test]
        public void MinusTest()
        {
            Assert.IsFalse(Figure.isTriangle(-1, 1, 1));
        }

        [Test]
        public void ConvertTest()
        {
            Assert.IsTrue(Figure.isTriangle(Convert.ToDouble("1,1"), 1, 1));
        }

        [Test]
        public void BoundaryTest()
        {
            Assert.IsFalse(Figure.isTriangle(0.00000000000000000000000000000000000000000000000001, 1, 1));
        }

        [Test]
        public void MaxMinValueTest()
        {
            Assert.IsFalse(Figure.isTriangle(double.MaxValue, 2 * double.MinValue, double.MaxValue));
        }

        [Test]
        public void MaxValueTest()
        {
            Assert.IsTrue(Figure.isTriangle(double.MaxValue, double.MaxValue, double.MaxValue));
        }

        [Test]
        public void UpperMaxValueTest()
        {
            Assert.IsFalse(Figure.isTriangle(double.MaxValue + double.MinValue, double.MaxValue + double.MinValue, double.MaxValue + double.MinValue));
        }

        [Test]
        public void BoundaryLowerTest()
        {
            Assert.IsTrue(Figure.isTriangle(1 + 0.000000011, 2, 3 + 0.00000001));
        }

        [Test]
        public void BoundaryUpperTest()
        {
            Assert.IsFalse(Figure.isTriangle(1, 2, 3 + 0.00000001));
        }

    }
}
