using System;


namespace SOLID.Exercise
{
    /*
     *    Класс OrderRepository изначально был реализован для работы с заказами, 
     *    хранящимися в MySQL. Но однажды нам потребовалось реализовать работу с 
     *    данными о заказах, например, через API стороннего веб-сервиса. 
     *    Какие изменения нам надо будет внести?
     *    class Order
     *    {
     *       int orderId;
     *       string Name;
     *    }
     *    class OrderRepository
     *    {
     *       public Order Load(int orderId) { return ... }
     *       public void Save(Order order) { ... }
     *       public void Update(Order order) { ... }
     *       public void Delete(Order order) { ... }
     *    }
     */
    public static class Test1
    {
        public static void Demo()
        {
            OrderRepository<Order> or = new OrderRepository<Order>(new  MySQLOrderRepository());
            or.Save(new Order());
        }
    }

    interface IRepository<T>
    {
        T Load(int orderId);
        void Save(T order);
        void Update(T order);
        void Delete(T order);
    }

    class OrderRepository<T>
    {
        IRepository<T> _repository;
        public OrderRepository(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(T order) => _repository.Delete(order);
        public T Load(int orderId) => _repository.Load(orderId);
        public void Save(T order) => _repository.Save(order);
        public void Update(T order) => _repository.Update(order);
    }

    class Order
    {
        int orderId;
        string Name;
    }

    class MySQLOrderRepository : IRepository<Order>
    {
        public void Delete(Order order)
        {
            Console.WriteLine("MySQL Delete");
        }

        public Order Load(int orderId)
        {
            Console.WriteLine("MySQL Load");
            return new Order();
        }

        public void Save(Order order)
        {
            Console.WriteLine("MySQL Save");
        }

        public void Update(Order order)
        {
            Console.WriteLine("MySQL Update");
        }
    }
}
