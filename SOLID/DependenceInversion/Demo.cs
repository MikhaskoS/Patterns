using System;

namespace SOLID.DependenceInversion
{
    public class Demo
    {
        public static void Test()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }

    public class Ops
    {
        public void Test()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
