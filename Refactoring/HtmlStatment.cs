namespace Refactoring
{
    using System.Text;

    public class HtmlStatment : Statement
    {
        public override string Value(Customer customer)
        {
            StringBuilder result = new StringBuilder();
            result.Append(HeaderString(customer));

            foreach (var rental in customer.Rentals)
            {
                result.Append(EachRentalString(rental));
            }

            result.Append(FooterString(customer));

            return result.ToString();
        }

        private string HeaderString(Customer customer)
        {
            return string.Format("<H1>Rentals for <EM>{0}</EM></H1><P>\n", customer.Name);
        }

        private string EachRentalString(Rental rental)
        {
            return string.Format("{0}: {1}<BR>\n", rental.Movie.Title, rental.GetCharge());
        }

        private string FooterString(Customer customer)
        {
            var footerString = string.Format("<P>You owe <EM>{0}</EM><P>\n", customer.GetTotalAmount());
            footerString += string.Format("On this rental you earned <EM>{0}</EM> frequent renter points<P>", customer.GetTotalFrequentRenterPoints());
            return footerString;
        }
    }
}