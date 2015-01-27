namespace Refactoring
{
    using System;

    class Program
    {
        static void Main()
        {
            Movie regular = new Movie("The Regular Movie", Movie.REGULAR);
            Movie childrens = new Movie("The Childrens Movie", Movie.CHILDRENS);
            Movie newRelease = new Movie("The New Release Movie", Movie.NEW_RELEASE);

            Customer me = new Customer("Miguel");

            Rental myRental = new Rental(regular, 2);
            me.AddRental(myRental);

            myRental = new Rental(childrens, 3);
            me.AddRental(myRental);

            myRental = new Rental(newRelease, 4);
            me.AddRental(myRental);

            Console.Out.WriteLine(me.Statement());
            Console.In.ReadLine();
        }
    }
}
