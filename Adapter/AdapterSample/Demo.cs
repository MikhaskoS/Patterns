using MoreLinq;
using System;
using System.Collections.Generic;

namespace Adapter.AdapterSample
{
    public partial class Demo
    {
        // Имеем некоторые объекты - коллекции из Line
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1, 1, 10, 10),
            new VectorRectangle(3, 3, 6, 6)
        };

        // Это наш единственный метод для отображения заданных коллекций.
        // Задача - написать адаптер, который позволит это сделать
        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }

        public static void Test()
        {
            DrawPoints();
            //DrawPoints();

            //DrawPointsLazy();
        }

        //--------------------------------------------------
        private static List<Point> points = new List<Point>();
        private static bool prepared = false;

        private static void Prepare()
        {
            if (prepared) return;
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(p => points.Add(p));
                }
            }
            prepared = true;
        }

        private static void DrawPointsLazy()
        {
            Prepare();
            points.ForEach(DrawPoint);
        }

        //--------------------------------------------------

        private static void DrawPoints()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
    }
}
