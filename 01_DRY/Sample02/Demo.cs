using System;
using System.Collections.Generic;
using System.Text;

namespace _01_DRY.Sample02
{
    public static class Demo
    {
        public static void Test()
        {
            List<Action> actions = GetActionSteps();
            foreach (var action in actions)
            {
                MakeAction(action);
            }
        }

        public static readonly string Address = Constants.Address;
        public static readonly string Format = Constants.Format;

        private static void DummyFunc()
        {
            WriteToConsole("Петя", "школьный друг", 30);
        }
        private static void DummyFuncAgain()
        {
            WriteToConsole("Вася", "сосед", 54);
        }
        private static void DummyFuncMore()
        {
            WriteToConsole("Николай", "сын", 4);
        }

        private static void WriteToConsole(string name, string description, int age)
        {
            Console.WriteLine(Format, name, description, Address, age);
        }

        private static void MakeAction(Action action)
        {
            string methodName = action.Method.Name;
            Console.WriteLine("Начало работы метода {0}", methodName);
            action();
            Console.WriteLine("Окончание работы метода {0}", methodName);
        }


        private static List<Action> GetActionSteps()
        {
            return new List<Action>() { 
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
