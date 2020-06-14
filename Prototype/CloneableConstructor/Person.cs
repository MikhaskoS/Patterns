namespace Prototype.CloneableConstructor
{
    public class Person
    {
        public string Name;
        public Address Address;

        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public Person(Person other)
        {
            Name = other.Name;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    
}
