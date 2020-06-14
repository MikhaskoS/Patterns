using System;



namespace Prototype.CloneableConstructor
{
    public class Demo
    {
        // Копирующие конструкторы это вполне работающий метод, но он плохо расширяемый
        // Особенно, если имеются вложенные типы, массивы и т.п.
        public static void Test()
        {
            var john = new Person("John", new Address("123 London Road", "London", "UK"));

            //var jane = john;
            var jane = new Person(john);

            jane.Name = "Jane";

            Console.WriteLine(john); 
            Console.WriteLine(jane);

            jane.Address.City = "Russia";

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
