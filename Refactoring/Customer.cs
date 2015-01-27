namespace Refactoring
{
    using System.Collections.Generic;

    public class Customer
    {
        private IList<Rental> _rentals;

        public Customer(string name)
        {
            Name = name;
            _rentals = new List<Rental>();
        }

        public string Name { get; private set; }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            int frequentRenterPoints = 0;
            IEnumerator<Rental> rentals = _rentals.GetEnumerator();
            string result = "Rental Record for " + Name + "\n";
            while (rentals.MoveNext())
            {
                Rental each = rentals.Current;

                // Add frequent renter points
                frequentRenterPoints += each.GetFrequentRenterPoints();

                // Show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
            }

            // Add footer lines
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }

        private double GetTotalAmount()
        {
            double result = 0;

            IEnumerator<Rental> rentals = _rentals.GetEnumerator();
            while (rentals.MoveNext())
            {
                Rental each = rentals.Current;
                result += each.GetCharge();
            }

            return result;
        }
    }
}