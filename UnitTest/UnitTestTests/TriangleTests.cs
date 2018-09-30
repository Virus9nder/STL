using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Tests
{
    [TestClass()]
    public class TriangleTests
    {

        [TestMethod()]
        public void GeneralTest()
        {
            double AB = 1;
            double BC = 1;
            double CA = 1;
            
            bool Check = Triangle.Check(AB,BC,CA);
            
            Assert.AreEqual(true, Check);
            
        }

        [TestMethod()]
        public void ZeroTest()
        {
            double AB = 1;
            double BC = 0;
            double CA = 1;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }

        [TestMethod()]
        public void MinusTest()
        {
            double AB = -1;
            double BC = 1;
            double CA = 1;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }

        [TestMethod()]
        public void ConvertTest()
        {
            double AB = Convert.ToDouble("1,1");
            double BC = 1;
            double CA = 1;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(true, Check);

        }

        [TestMethod()]
        public void BoundaryTest()
        {
            double AB = 0.00000000000000000000000000000000000000000000000001;
            double BC = 1;
            double CA = 1;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }

        [TestMethod()]
        public void MaxMinValueTest()
        {
            double AB = double.MaxValue;
            double BC = 2*double.MinValue;
            double CA = double.MaxValue;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }

        [TestMethod()]
        public void MaxValueTest()
        {
            double AB = double.MaxValue;
            double BC = double.MaxValue;
            double CA = double.MaxValue;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(true, Check);

        }

        [TestMethod()]
        public void UpperMaxValueTest()
        {
            double AB = double.MaxValue + double.MinValue;
            double BC = double.MaxValue + double.MinValue;
            double CA = double.MaxValue + double.MinValue;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }

        [TestMethod()]
        public void BoundaryLowerTest()
        {
            double AB = 1 + 0.000000011;
            double BC = 2;
            double CA = 3 + 0.00000001;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(true, Check);

        }

        [TestMethod()]
        public void BoundaryUpperTest()
        {
            double AB = 1;
            double BC = 2;
            double CA = 3 + 0.00000001;

            bool Check = Triangle.Check(AB, BC, CA);

            Assert.AreEqual(false, Check);

        }
        

    }
}