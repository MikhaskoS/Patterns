using System;
using System.Collections.Generic;


namespace HomeWork.Lesson01
{
    public class Task2
    {
        // Реализовать программу из раздела «Повторяющиеся фрагменты кода» 
        // с помощью делегата  Func. 
        public static void Test()
        {
            List<Func<string>> actions = GetActionStepsExt();

            foreach (var action in actions)
            {
                MakeAction(action);
            }
        }

        public static readonly string Address = Constants.Address;
        public static readonly string Format = Constants.Format;

        private static string DummyFunc()
        {
            return WriteToConsole("Петя", "школьный друг", 30);
        }
        private static string DummyFuncAgain()
        {
            return WriteToConsole("Вася", "сосед", 54);
        }
        private static string DummyFuncMore()
        {
            return WriteToConsole("Николай", "сын", 4);
        }

        private static string WriteToConsole(string name, string description, int age)
        {
            string result = String.Format(Format, name, description, Address, age);

            return result;
        }


        private static void MakeAction(Func<string> action)
        {
            string methodName = action.Method.Name;
            Console.WriteLine("Начало работы метода {0}", methodName);
            action();
            Console.WriteLine("Окончание работы метода {0}", methodName);
        }


        private static List<Func<string>> GetActionStepsExt()
        {
            return new List<Func<string>>
            {
                DummyFunc,
                DummyFuncAgain,
                DummyFuncMore
            };
        }
    }

    public static class Constants
    {
        public static readonly string Address = "Москва, Россия";
        public static readonly string Format = "{0} - {1}, адрес {2}, возраст {3}";
    }
}
