using System;


namespace Singleton.SingletonBase
{
    public class Demo
    {
        public static void Test()
        {
            var db = SingletonDatabase.Instance;

            // works just fine while you're working with a real database.
            var city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
