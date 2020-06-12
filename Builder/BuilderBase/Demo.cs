using System;


namespace Builder.BuilderBase
{
    public class Demo
    {
        internal static void Test()
        {
            var worlds = new[] { "Hello", "World" };
            var builder = new HtmlBuilder("ul");
            foreach (var word in worlds)
                builder.AddChild("li", word);

            // fluent builder
            builder
                .AddChildFluent("li", "HelloFluent")
                .AddChildFluent("li", "WorldFluent");
            
            Console.WriteLine(builder.ToString());
            Console.WriteLine(new string('+', 50));

            // with factory method
            {
                var builder2 = HtmlElement.Create("ul");
                builder2
                    .AddChildFluent("li", "hello")
                    .AddChildFluent("li", "world");
                Console.WriteLine(builder2);
            }

            Console.WriteLine(new string('+', 50));
            // with implicit operator
            {
                var root = HtmlElement
                  .Create("ul")
                  .AddChildFluent("li", "hello")
                  .AddChildFluent("li", "world");
                Console.WriteLine(root);  // <- произошло преобразование типа
            }
        }
    }
}
