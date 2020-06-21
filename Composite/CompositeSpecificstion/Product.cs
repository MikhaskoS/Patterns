using System;

namespace Composite.CompositeSpecificstion
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public readonly string Name;
        public readonly Color Color;
        public readonly Size Size;

        public Product(string name, Color color, Size size)
        {
            // ?? - оператор null объединения. Если name == null выводим ошибку
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

}
