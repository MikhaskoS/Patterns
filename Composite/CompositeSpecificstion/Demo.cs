using System;
using System.Collections.Generic;
using System.Linq;


namespace Composite.CompositeSpecificstion
{
    public class Demo
    {
        public static void Test()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();

            // пример комбинации фильтров
            Console.WriteLine(">>Combinations filters");
            //var largeGreenSpec = new ColorSpecification(Color.Green)
            //               & new SizeSpecification(Size.Large);
            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new AndSpecification<Product>(new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
        }
    }

    //--------------------------------------------------
    //             Паттерн спецификация + компоновщик
    //--------------------------------------------------
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, Specification<T> spec);
    }

    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T p);

        // поскольку это абстрактный класс (а не интерфейс, как обычно делается),
        // мы можем перегрузить оператор для комбинации условий фильтрации
        public static Specification<T> operator &(Specification<T> first, Specification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }

    #region combinator

    // 
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params Specification<T>[] items) : base(items)
        {
        }

        public override bool IsSatisfied(T t)
        {
            // Any -> OrSpecification
            return items.All(i => i.IsSatisfied(t));
        }
    }


    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] items;

        public CompositeSpecification(params Specification<T>[] items)
        {
            this.items = items;
        }
    }

    #endregion


    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, Specification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    public class ColorSpecification : Specification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.Color == color;
        }
    }

    public class SizeSpecification : Specification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.Size == size;
        }
    }
}
