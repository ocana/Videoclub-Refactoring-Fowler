namespace Refactoring
{
    using System;

    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private Price _price;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int PriceCode
        {
            get { return _price.GetPriceCode(); }
            set {
                switch (value)
                {
                    case REGULAR:
                        _price = new RegularPrice();
                        break;
                    case NEW_RELEASE:
                        _price = new NewReleasePrice();
                        break;
                    case CHILDRENS:
                        _price = new ChildrensPrice();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("value", "Incorrect Price Code");
                }
            }
        }

        public string Title { get; private set; }

        public double GetCharge(int daysRented)
        {
            double result = 0;

            switch (PriceCode)
            {
                case REGULAR:
                    result += 2;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5;
                    }
                    break;
                case NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                    {
                        result += (daysRented - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if (PriceCode == NEW_RELEASE && daysRented > 1)
            {
                return 2;
            }

            return 1;
        }
    }
}