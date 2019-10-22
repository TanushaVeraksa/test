using InequalityTriangles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InequalityTriangles.Test
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void IsTrianglePossibleEquilateralTriangle()
        {
            Assert.IsTrue(Triangle.TheExistenceOfTriangle(15, 15, 15));
        }

        [TestMethod]
        public void IsTrianglePossibleEgyptianTriangle()
        {
            Assert.IsTrue(Triangle.TheExistenceOfTriangle(3, 4, 5));
        }

        [TestMethod]
        public void IsTrianglePossibleSumLessThanSideLength()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(10, 20, 35));
        }

        [TestMethod]
        public void IsTrianglePossibleZeroLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(0, 10, 20));
        }

        [TestMethod]
        public void IsTrianglePossibleTwoZeroLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(0, 0, 10));
        }
        [TestMethod]
        public void IsTrianglePossibleThreeZeroLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(0, 0, 0));
        }
        [TestMethod]
        public void IsTrianglePossibleOneNegativeLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(-10, 10, 10));
        }
        [TestMethod]
        public void IsTrianglePossibleTwoNegativeLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(-10, 10, -10));
        }
        [TestMethod]
        public void IsTrianglePossibleAllNegativeLengthSide()
        {
            Assert.IsFalse(Triangle.TheExistenceOfTriangle(-10, -10, -10));
        }
        [TestMethod]
        public void IsTrianglePossibleSumMoreThanSideLength()
        {
            Assert.IsTrue(Triangle.TheExistenceOfTriangle(15, 25, 30));
        }
    }
}
