using System;


namespace Proxy.ProxyProtection
{
    public  class Demo
    {
        public static void Test()
        {
            ICar car = new CarProxy(new Driver(12)); // 22
            car.Drive();
        }
    }

    #region Car
    
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car being driven");
        }
    }

    #endregion

    #region Driver

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    #endregion

    public class CarProxy : ICar
    {
        private Car car = new Car();
        private Driver driver;

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
                car.Drive();
            else
            {
                Console.WriteLine("Driver too young");
            }
        }
    }

  
}
