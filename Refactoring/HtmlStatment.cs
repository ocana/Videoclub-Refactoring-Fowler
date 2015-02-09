namespace Refactoring
{
    using System.Text;

    public class HtmlStatment : Statement
    {
        public override string Value(Customer customer)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("<H1>Rentals for <EM>{0}</EM></H1><P>\n", customer.Name);

            foreach (var rental in customer.Rentals)
            {
                // Show figures for this rental
                result.AppendFormat("{0}: {1}<BR>\n", rental.Movie.Title, rental.GetCharge());
            }

            // Add footer lines
            result.AppendFormat("<P>You owe <EM>{0}</EM><P>\n", customer.GetTotalAmount());
            result.AppendFormat("On this rental you earned <EM>{0}</EM> frequent renter points<P>", customer.GetTotalFrequentRenterPoints());

            return result.ToString();
        }
    }
}