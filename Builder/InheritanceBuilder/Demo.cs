using System;

namespace Builder.InheritanceBuilder
{
    public class Demo
    {
        // Person  {   Person.Builder   }
        // PersonBuilder (abstract)
        //          |
        //   PersonInfoBuilder
        //          |
        //   PersonJobBuilder
        //          |
        // PersonBirthDateBuilder
        //          |
        //       Builder

        public static void Test()
        {
            var me = Person.New
                .Called("Dmitri")         // <- Вернет Person.Builder!!!
                .WorksAsA("Quant")
                .Born(DateTime.UtcNow)
                .Build();

            Console.WriteLine(me);
        }
    }
}
