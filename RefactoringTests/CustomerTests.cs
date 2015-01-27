using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactoringTests
{
    using Refactoring;

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void WhenGettingName_ItShouldReturnTheName()
        {
            // Arrange
            const string expectedName = "My Expected Name";
            string actualName;

            Customer myCustomer = new Customer(expectedName);

            // Act
            actualName = myCustomer.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void WhenStatementWithEmptyRentals_ItShouldReturnTheZeroStatement()
        {
            // Arrange
            const string expectedStatement = "Rental Record for \nAmount owed is 0\nYou earned 0 frequent renter points";
            string actualStatement;
            Customer myCustomer = new Customer(string.Empty);

            // Act
            actualStatement = myCustomer.Statement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }
    }
}
