using Autofac;
using System;


namespace Bridge.Bridge
{
    public class Demo
    {
        public static void Test()
        {
            var raster = new RasterRenderer();
            var vector = new VectorRenderer();
            var circle = new Circle(vector, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

            #region Autofac

            // инициализируем контейнер
            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(),
              p.Positional<float>(0)));

            // todo: delegate factories

            using (var c = cb.Build())  // <--
            {
                var circ = c.Resolve<Circle>(
                  new PositionalParameter(0, 5.0f)
                );
                circ.Draw();
                circ.Resize(2);
                circ.Draw();
            }

            #endregion
        }
    }

    #region Renderer

    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }

    #endregion

    // Для связи фигур с растеризатором используется объект из вершины иерархии
    // таким образом реализуется мост
    public abstract class Shape
    {
        protected IRenderer renderer;

        // a bridge between the shape that's being drawn an
        // the component which actually draws it
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
}
