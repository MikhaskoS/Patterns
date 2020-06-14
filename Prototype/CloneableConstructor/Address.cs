namespace Prototype.CloneableConstructor
{
    public class Address
    {
        public string StreetAddress, City, Country;

        public Address(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            Country = country;
        }

        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}," +
                $" {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }

    
}
