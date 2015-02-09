namespace Refactoring
{
    public class TextStatement : Statement
    {
        protected override string HeaderString(Customer customer)
        {
            return string.Format("Rental Record for {0}\n", customer.Name);
        }

        protected override string EachRentalString(Rental rental)
        {
            return string.Format("\t{0}\t{1}\n", rental.Movie.Title, rental.GetCharge());
        }

        protected override string FooterString(Customer customer)
        {
            var footerString = string.Format("Amount owed is {0}\n", customer.GetTotalAmount());
            footerString += string.Format("You earned {0} frequent renter points", customer.GetTotalFrequentRenterPoints());
            return footerString;
        }
    }
}