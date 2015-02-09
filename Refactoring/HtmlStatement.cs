namespace Refactoring
{
    public class HtmlStatement : Statement
    {
        protected override string HeaderString(Customer customer)
        {
            return string.Format("<H1>Rentals for <EM>{0}</EM></H1><P>\n", customer.Name);
        }

        protected override string EachRentalString(Rental rental)
        {
            return string.Format("{0}: {1}<BR>\n", rental.Movie.Title, rental.GetCharge());
        }

        protected override string FooterString(Customer customer)
        {
            var footerString = string.Format("<P>You owe <EM>{0}</EM><P>\n", customer.GetTotalAmount());
            footerString += string.Format("On this rental you earned <EM>{0}</EM> frequent renter points<P>", customer.GetTotalFrequentRenterPoints());
            return footerString;
        }
    }
}