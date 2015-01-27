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
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator<Rental> rentals = _rentals.GetEnumerator();
            string result = "Rental Record for " + Name + "\n";
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = rentals.Current;

                // Determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2)*1.5;
                        }
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        }
                        break;
                }

                // Add frequent renter points
                frequentRenterPoints++;

                // Add bonus for a two day new release rental
                if (each.Movie.PriceCode == Movie.NEW_RELEASE && each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                // Show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            // Add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}