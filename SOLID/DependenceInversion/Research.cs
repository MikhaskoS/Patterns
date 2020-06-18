using System;
using System.Linq;


namespace SOLID.DependenceInversion
{
    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    // Нарушение принципа инверсной зависимости. Высокоуровневый модуль
        //    // зависит от низкоуровневого (Relationships). Любые изменения в низкоуровневом
        //    // модуле поломают высокоуровневый

        //    // high-level: find all of john's children
        //    var relations = relationships.Relations;
        //    foreach (var r in relations
        //      .Where(x => x.Item1.Name == "John"
        //                  && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        // Правильный подход - для извлечения информации используется
        // абстракция в виде интерфейса (конструктор)
        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {p.Name}");
            }
        }
    }
}
