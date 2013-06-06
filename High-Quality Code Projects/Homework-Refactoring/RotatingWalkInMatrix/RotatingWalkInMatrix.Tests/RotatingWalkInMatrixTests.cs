namespace RotatingWalkInMatrix.Tests
{
    using System;
    using RotatingWalkInMatrix.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RotatingWalkInMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MoreThanMaxSizeMatrixExceptionTest()
        {
            Matrix matrix = new Matrix(Matrix.MaxSize + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroSizeMatrixExceptionTest()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        public void WalkMatrixWithSizeOneTest()
        {
            Matrix matrix = new Matrix(1);

            matrix.Walk();

            string expected = string.Format("{0, 5}", 1);
            string actual = matrix.ToString();
            Assert.AreEqual(expected, actual, "Matrix with size one not walked correctly!");
        }

        [TestMethod]
        public void WalkMatrixWithSizeTwoTest()
        {
            Matrix matrix = new Matrix(2);

            matrix.Walk();

            string expected = string.Format("{1, 5}{2, 5}{0}{3, 5}{4, 5}", Environment.NewLine, 1, 4, 3, 2);
            string actual = matrix.ToString();
            Assert.AreEqual(expected, actual, "Matrix with size two not walked correctly!");
        }

        [TestMethod]
        public void WalkMatrixWithSizeThreeTest()
        {
            Matrix matrix = new Matrix(3);

            matrix.Walk();

            string expected = string.Format(
                "{1, 5}{2, 5}{3, 5}{0}{4, 5}{5, 5}{6, 5}{0}{7, 5}{8, 5}{9, 5}",
                Environment.NewLine, 1, 7, 8, 6, 2, 9, 5, 4, 3);
            string actual = matrix.ToString();
            Assert.AreEqual(expected, actual, "Matrix with size two not walked correctly!");
        }

        [TestMethod]
        public void WalkMatrixWithSizeSixTest()
        {
            Matrix matrix = new Matrix(6);

            matrix.Walk();

            string expected = string.Format(
                ("{1, 5}{2, 5}{3, 5}{4, 5}{5, 5}{6, 5}{0}" +
                 "{7, 5}{8, 5}{9, 5}{10, 5}{11, 5}{12, 5}{0}" +
                 "{13, 5}{14, 5}{15, 5}{16, 5}{17, 5}{18, 5}{0}" +
                 "{19, 5}{20, 5}{21, 5}{22, 5}{23, 5}{24, 5}{0}" +
                 "{25, 5}{26, 5}{27, 5}{28, 5}{29, 5}{30, 5}{0}" +
                 "{31, 5}{32, 5}{33, 5}{34, 5}{35, 5}{36, 5}"),
                Environment.NewLine,
                1, 16, 17, 18, 19, 20,
                15, 2, 27, 28, 29, 21,
                14, 31, 3, 26, 30, 22,
                13, 36, 32, 4, 25, 23,
                12, 35, 34, 33, 5, 24,
                11, 10, 9, 8, 7, 6);
            string actual = matrix.ToString();
            Assert.AreEqual(expected, actual, "Matrix with size six not walked correctly!");
        }
    }
}
