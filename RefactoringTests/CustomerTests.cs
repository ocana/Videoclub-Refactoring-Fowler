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

        [TestMethod]
        public void WhenHtmlStatementWithEmptyRentals_ItShouldReturnTheZeroHtmlStatement()
        {
            // Arrange
            const string expectedStatement = "<H1>Rentals for <EM></EM></H1><P>\n<P>You owe <EM>0</EM><P>\n" +
                                             "On this rental you earned <EM>0</EM> frequent renter points<P>";
            string actualStatement;
            Customer myCustomer = new Customer(string.Empty);

            // Act
            actualStatement = myCustomer.HtmlStatement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }
    }
}
