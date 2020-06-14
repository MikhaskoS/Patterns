using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.PrototypeFactory
{
    public class Demo
    {
        public static void Test()
        {
            var john = EmployeeFactory.NewMainOfficeEmployee("John", 123);
           
            Console.WriteLine(john);
        }
    }
}
