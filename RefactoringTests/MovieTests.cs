namespace RefactoringTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;

    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void WhenGettingTitle_ItShouldReturnTheTitle()
        {
            // Arrange
            const string expectedTitle = "My Expected Title";
            string actualTitle;

            Movie myMovie = new Movie(expectedTitle, Movie.REGULAR);

            // Act
            actualTitle = myMovie.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void WhenGettingPriceCode_ItShouldReturnThePriceCode()
        {
            // Arrange
            const int expectedPriceCode = Movie.REGULAR;
            int actualPriceCode;

            Movie myMovie = new Movie(string.Empty, expectedPriceCode);

            // Act
            actualPriceCode = myMovie.PriceCode;

            // Assert
            Assert.AreEqual(expectedPriceCode, actualPriceCode);
        }

        [TestMethod]
        public void WhenSettingPriceCode_ItShouldReturnTheNewPriceCode()
        {
            // Arrange
            const int expectedPriceCode = Movie.REGULAR;
            int actualPriceCode = Movie.NEW_RELEASE;

            Movie myMovie = new Movie(string.Empty, actualPriceCode);

            // Act
            myMovie.PriceCode = expectedPriceCode;
            actualPriceCode = myMovie.PriceCode;

            // Assert
            Assert.AreEqual(expectedPriceCode, actualPriceCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenSettingUnknownPriceCode_ItShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            const int unknownPriceCode = -9999;
            Movie myMovie = new Movie(string.Empty, Movie.REGULAR);

            // Act
            myMovie.PriceCode = unknownPriceCode;
        }
    }
}