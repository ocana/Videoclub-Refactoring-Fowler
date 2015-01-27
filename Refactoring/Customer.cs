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
            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                // Show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + rental.GetCharge() + "\n";
            }

            // Add footer lines
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";

            return result;
        }

        private double GetTotalAmount()
        {
            double result = 0;

            foreach (var rental in _rentals)
            {
                result += rental.GetCharge();
            }

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;

            foreach (var rental in _rentals)
            {
                result += rental.GetFrequentRenterPoints();
            }

            return result;
        }
    }
}