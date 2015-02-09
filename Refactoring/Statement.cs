namespace Refactoring
{
    using System.Text;

    public abstract class Statement
    {
        public string Value(Customer customer)
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

        protected abstract string HeaderString(Customer customer);

        protected abstract string EachRentalString(Rental rental);

        protected abstract string FooterString(Customer customer);
    }
}