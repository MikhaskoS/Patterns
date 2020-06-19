using System;

namespace Factories.Factories
{
    public class Demo
    {
        public static void Test()
        {
            // Задача. Имеется класс Point. Требуется написать удобные онструкторы 
            // для инициализации объекта в декартовой и полярной системе координат
            // т.е. способ задать точку ч/з XY или полярный радиус/угол

            var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
            var origin = Point.Origin;

            var p2 = Point.Factory.NewCartesianPoint(1, 2);
        }
    }

    public class Point
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        private double x, y;

        // конструктор закрыт для объявления
        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // вариант без использования фабрики
        public Point(double a, double b,  CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    x = a;
                    y = b;
                    break;
            }
        }

        #region фабричные методы (если не хотим делать саму фабрику)

        // factory property
        public static Point Origin => new Point(0, 0);

        // constant field
        public static Point Origin2 = new Point(0, 0);

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        #endregion

        #region Внутренняя фабрика
        // можно фабрику разместить прямо внутри объекта (если не нужно открывать конструктор)
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
        #endregion

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    // Внешняя фабрика (но в этом случае конструктор следует сделать публичным)
    class PointFactory
    {
        public static Point NewCartesianPoint(float x, float y)
        {
            return new Point(x, y); // needs to be public
        }
    }
}
