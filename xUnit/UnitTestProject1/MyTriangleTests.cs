using InequalityTriangles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InequalityTriangles.Test
{
    [TestClass]
    public class MyTriangleTests
    {
        [TestMethod]
        public void IsTrianglePossibleEquilateralTriangle()
        {
            Assert.IsTrue(MyTriangle.TheExistenceOfTriangle(15, 15, 15));
        }

        [TestMethod]
        public void IsTrianglePossibleEgyptianTriangle()
        {
            Assert.IsTrue(MyTriangle.TheExistenceOfTriangle(3, 4, 5));
        }

        [TestMethod]
        public void IsTrianglePossibleSumLessThanSideLength()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(10, 20, 35));
        }

        [TestMethod]
        public void IsTrianglePossibleZeroLengthSide()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(0, 10, 20));
        }

        [TestMethod]
        public void IsTrianglePossibleTwoZeroLengthSide()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(0, 0, 10));
        }
        [TestMethod]
        public void IsTrianglePossibleThreeZeroLengthSide()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(0, 0, 0));
        }
        [TestMethod]
        public void IsTrianglePossibleOneNegativeLengthSide()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(-10, 10, 10));
        }
        [TestMethod]
        public void IsTrianglePossibleTwoNegativeLengthSide()
        {
            Assert.IsFalse(MyTriangle.TheExistenceOfTriangle(-10, 10, -10));
        }
        public void IsTrianglePossibleSumMoreThanSideLength()
        {
            Assert.IsTrue(MyTriangle.TheExistenceOfTriangle(15, 25, 30));
        }
    }
}
