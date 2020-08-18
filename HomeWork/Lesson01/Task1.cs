using System;

namespace HomeWork.Lesson01
{
    public static class Task1
    {
        // Внедрение зависимости через конструктор (constructor injection)

        public static void Test()
        {
            Store store = new Store(new DefaultIdGenerator());
            Customer customer = new Customer(new OtherIdGenerator());

            Console.WriteLine($"Store ID = {store.Id}");
            Console.WriteLine($"Customer ID = {customer.Id}");
        }
    }

    public class Customer
    {
        private readonly IIdGenerator _idGenerator;
        public long Id { get; private set; }
        public string Description { get; set; }

        public Customer(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
            Id = _idGenerator.CalculateId();
        }

    }

    public class Store
    {
        private readonly IIdGenerator _idGenerator;
        public long Id { get; set; }

        public Store(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
            Id = _idGenerator.CalculateId();
        }

    }

    public interface IIdGenerator
    {
        long CalculateId();
    }
    public class DefaultIdGenerator : IIdGenerator
    {
        public long CalculateId()
        {
            long id = DateTime.Now.Ticks;
            return id;
        }
    }
    public class OtherIdGenerator : IIdGenerator
    {
        public long CalculateId()
        {
            long id = DateTime.Now.Ticks * DateTime.Now.Ticks;
            return id;
        }
    }
}
