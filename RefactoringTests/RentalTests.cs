namespace RefactoringTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;

    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void WhenGettingMovie_ItShouldReturnTheMovie()
        {
            // Arrange
            Movie expectedMovie = new Movie("a", 1);
            Movie actualMovie;

            Rental myRental = new Rental(expectedMovie, 0);

            // Act
            actualMovie = myRental.Movie;

            // Assert
            Assert.AreEqual(expectedMovie, actualMovie);
        }

        [TestMethod]
        public void WhenGettingDaysRented_ItShouldReturnTheDaysRented()
        {
            // Arrange
            const int expectedDaysRented = 9;
            int actualDaysRented;

            Rental myRental = new Rental(null, expectedDaysRented);

            // Act
            actualDaysRented = myRental.DaysRented;

            // Assert
            Assert.AreEqual(expectedDaysRented, actualDaysRented);
        }
    }
}