using System;


namespace Builder.MultiBuilder
{
    public class Person
    {
        public Person()
        {
            Console.WriteLine("Creating an instance of Person");
        }

        // address
        public string StreetAddress, Postcode, City;

        // employment info
        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}," +
                   $" {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}," +
                   $" {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
}
