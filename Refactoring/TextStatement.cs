namespace Refactoring
{
    using System.Text;

    public class TextStatement : Statement
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
            return string.Format("Rental Record for {0}\n", customer.Name);
        }

        private string EachRentalString(Rental rental)
        {
            return string.Format("\t{0}\t{1}\n", rental.Movie.Title, rental.GetCharge());
        }

        private string FooterString(Customer customer)
        {
            var footerString = string.Format("Amount owed is {0}\n", customer.GetTotalAmount());
            footerString += string.Format("You earned {0} frequent renter points", customer.GetTotalFrequentRenterPoints());
            return footerString;
        }
    }
}