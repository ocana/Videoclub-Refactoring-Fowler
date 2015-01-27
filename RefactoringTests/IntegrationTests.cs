using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactoringTests
{
    using Refactoring;

    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void When3RentalsButDaysRentedAreZero()
        {
            // Arrange
            const int daysRented = 0;

            Movie regular = new Movie("The Regular Movie", Movie.REGULAR);
            Movie childrens = new Movie("The Childrens Movie", Movie.CHILDRENS);
            Movie newRelease = new Movie("The New Release Movie", Movie.NEW_RELEASE);

            Customer myCustomer = new Customer("Miguel");

            Rental myRental = new Rental(regular, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(childrens, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(newRelease, daysRented);
            myCustomer.AddRental(myRental);

            const string expectedStatement = "Rental Record for Miguel\n\tThe Regular Movie\t2\n\tThe Childrens Movie\t1,5\n\tThe New Release Movie\t0\nAmount owed is 3,5\nYou earned 3 frequent renter points";

            string actualStatement;

            // Act
            actualStatement = myCustomer.Statement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void When3RentalsButUnknownMoviesPriceCodes()
        {
            // Arrange
            const int unknownPriceCode = -9;

            Movie regular = new Movie("The Regular Movie", unknownPriceCode);
            Movie childrens = new Movie("The Childrens Movie", unknownPriceCode);
            Movie newRelease = new Movie("The New Release Movie", unknownPriceCode);

            Customer myCustomer = new Customer("Miguel");

            const int daysRented = 4;
            Rental myRental = new Rental(regular, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(childrens, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(newRelease, daysRented);
            myCustomer.AddRental(myRental);

            const string expectedStatement = "Rental Record for Miguel\n\tThe Regular Movie\t0\n\tThe Childrens Movie\t0\n\tThe New Release Movie\t0\nAmount owed is 0\nYou earned 3 frequent renter points";

            string actualStatement;

            // Act
            actualStatement = myCustomer.Statement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void When3RentalsEachMovieOneDayRented()
        {
            // Arrange
            const int daysRented = 1;

            Movie regular = new Movie("The Regular Movie", Movie.REGULAR);
            Movie childrens = new Movie("The Childrens Movie", Movie.CHILDRENS);
            Movie newRelease = new Movie("The New Release Movie", Movie.NEW_RELEASE);

            Customer myCustomer = new Customer("Miguel");

            Rental myRental = new Rental(regular, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(childrens, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(newRelease, daysRented);
            myCustomer.AddRental(myRental);

            const string expectedStatement = "Rental Record for Miguel\n\tThe Regular Movie\t2\n\tThe Childrens Movie\t1,5\n\tThe New Release Movie\t3\nAmount owed is 6,5\nYou earned 3 frequent renter points";

            string actualStatement;

            // Act
            actualStatement = myCustomer.Statement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void When3RentalsEachMovieTenDaysRented()
        {
            // Arrange
            const int daysRented = 10;

            Movie regular = new Movie("The Regular Movie", Movie.REGULAR);
            Movie childrens = new Movie("The Childrens Movie", Movie.CHILDRENS);
            Movie newRelease = new Movie("The New Release Movie", Movie.NEW_RELEASE);

            Customer myCustomer = new Customer("Miguel");

            Rental myRental = new Rental(regular, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(childrens, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(newRelease, daysRented);
            myCustomer.AddRental(myRental);

            const string expectedStatement = "Rental Record for Miguel\n" +
                                             "\tThe Regular Movie\t14\n\tThe Childrens Movie\t12\n\tThe New Release Movie\t30\n" +
                                             "Amount owed is 56\nYou earned 4 frequent renter points";

            string actualStatement;

            // Act
            actualStatement = myCustomer.Statement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void When3RentalsEachMovieTenDaysRentedInHtml()
        {
            // Arrange
            const int daysRented = 10;

            Movie regular = new Movie("The Regular Movie", Movie.REGULAR);
            Movie childrens = new Movie("The Childrens Movie", Movie.CHILDRENS);
            Movie newRelease = new Movie("The New Release Movie", Movie.NEW_RELEASE);

            Customer myCustomer = new Customer("Miguel");

            Rental myRental = new Rental(regular, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(childrens, daysRented);
            myCustomer.AddRental(myRental);

            myRental = new Rental(newRelease, daysRented);
            myCustomer.AddRental(myRental);

            const string expectedStatement = "<H1>Rentals for <EM>Miguel</EM></H1><P>\nThe Regular Movie: 14<BR>\nThe Childrens Movie: 12<BR>" +
                                             "\nThe New Release Movie: 30<BR>\n<P>You owe <EM>56</EM><P>\n" +
                                             "On this rental you earned <EM>4</EM> frequent renter points<P>";

            string actualStatement;

            // Act
            actualStatement = myCustomer.HtmlStatement();

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }
    }
}
