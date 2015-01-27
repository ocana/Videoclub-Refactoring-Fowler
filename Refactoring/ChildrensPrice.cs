namespace Refactoring
{
    public class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }

            return result;
        }
    }
}