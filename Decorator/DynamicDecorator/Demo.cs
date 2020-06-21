using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DynamicDecorator
{
    public class Demo
    {
        public static void Test()
        {
            var circle = new Circle(2);
            Console.WriteLine(circle.AsString());

            var redCircle = new ColoredShape(circle, "red");
            Console.WriteLine(redCircle.AsString());

            // декоратор поверх декоратора!
            var redHalfTransparentSquare = new TransparentShape(redCircle, 0.5f);
            Console.WriteLine(redHalfTransparentSquare.AsString());
        }
    }

    #region Базовые классы

    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    public sealed class Circle : Shape
    {
        private float radius;

        public Circle() : this(0)
        {

        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public override string AsString() => $"A circle of radius {radius}";
    }

    public sealed class Square : Shape
    {
        private readonly float side;

        public Square() : this(0)
        {

        }

        public Square(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }

    #endregion


    #region dynamic decorators

    public class ColoredShape : Shape
    {
        private readonly Shape shape;
        private readonly string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() =>
          $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }

    #endregion
}
