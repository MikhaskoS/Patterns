using System;


// Демонстрируется работа существующего интерфейса ICloneable
// В целом, это прием, которым не рекомендуется пользоваться,
// поскольку нет глубокого копирования объектов
namespace Prototype.I_Cloneable
{
    public class Demo
    {
        public static void Test()
        {
            var john = new Person(
                new[] { "John", "Smith" },
                new Address("London Road", 123));

            var jane = (Person)john.Clone();
            jane.Address.HouseNumber = 321; // oops, John is now at 321

            // this doesn't work
            //var jane = john;

            // but clone is typically shallow copy
            jane.Names[0] = "Jane";

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }

    // ICloneable is ill-specified

    interface IDeepCopyable<T>
    {
        T DeepCopy();
    }
  

    public class Address : ICloneable
    {
        public readonly string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }


    public class Person : ICloneable
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return MemberwiseClone();
            //return new Person(Names, Address);
        }
    }
}
