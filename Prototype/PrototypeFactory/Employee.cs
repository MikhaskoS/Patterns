﻿using System;

namespace Prototype.PrototypeFactory
{
    [Serializable]
    public class Employee
    {
        public string Name;
        public Address Address;

        public Employee(string name, Address address)
        {
            Name = name;// ?? throw new ArgumentNullException(paramName: nameof(name));
            Address = address;// ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        public Employee(Employee other)
        {
            Name = other.Name;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: " +
                $"Street: {Address.StreetAddress} City: {Address.City} Suite: {Address.Suite}";
        }

        //partial class EmployeeFactory {}
    }
}
