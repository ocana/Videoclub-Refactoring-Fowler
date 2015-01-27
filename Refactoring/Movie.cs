namespace Refactoring
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int PriceCode { get; set; }

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
    }
}