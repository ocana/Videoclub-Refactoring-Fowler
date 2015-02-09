namespace Refactoring
{
    using System.Text;

    public class TextStatement : Statement
    {
        public override string Value(Customer customer)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Rental Record for {0}\n", customer.Name);

            foreach (var rental in customer.Rentals)
            {
                // Show figures for this rental
                result.AppendFormat("\t{0}\t{1}\n", rental.Movie.Title, rental.GetCharge());
            }

            // Add footer lines
            result.AppendFormat("Amount owed is {0}\n", customer.GetTotalAmount());
            result.AppendFormat("You earned {0} frequent renter points", customer.GetTotalFrequentRenterPoints());

            return result.ToString();
        }
    }
}