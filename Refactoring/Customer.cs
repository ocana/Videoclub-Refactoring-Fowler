namespace Refactoring
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Customer
    {
        public IList<Rental> Rentals { get; private set; }

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public string Name { get; private set; }

        public void AddRental(Rental arg)
        {
            Rentals.Add(arg);
        }

        public string Statement()
        {
            return new TextStatement().Value(this);
        }

        public string HtmlStatement()
        {
            return new HtmlStatement().Value(this);
        }

        public double GetTotalAmount()
        {
            return Rentals.Sum(rental => rental.GetCharge());
        }

        public int GetTotalFrequentRenterPoints()
        {
            return Rentals.Sum(rental => rental.GetFrequentRenterPoints());
        }
    }
}