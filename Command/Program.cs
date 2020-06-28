using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    // Здесь приведен пример более универсального паттерна Command.
    // Во-первых, обработка команд вынесена из основного класса,что соответствует SOLID
    // Во-вторых, паттерн Command совмещен с паттерном Composite (компоновщик), что позволяет
    //  группировать комманды
    class Program
    {
        static void Main(string[] args)
        {
            Command.Demo.Test();
        }
    }
}
