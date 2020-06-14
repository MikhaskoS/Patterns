using System;

namespace Prototype.PrototypeFactory
{
    [Serializable]
    public class Address
    {
        public string StreetAddress, City;
        public int Suite;

        public Address(string streetAddress, string city, int suite)
        {
            StreetAddress = streetAddress;
            City = city;
            Suite = suite;
        }

        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Suite = other.Suite;
        }
    }
}
