using System;


namespace Proxy.VirtualProxy
{
    // Задача: имеется некоторый класс Bitmap - недоступный для модификации.
    //     В нашем случае, при инициализации объекта этого класса происходит
    //     загрузка изображения. Сделать так,чтобы это происходило в момент прорисовки
    // Решение: вводим для метода Draw интерфейс IImage так чтобы Bitmap формально его реализовывал.
    //     Это позволяет сделать обертку в виде виртуального наследника.
    public class Demo
    {
        public static void DrawImage(IImage img)
        {
            Console.WriteLine("About to draw the image");
            img.Draw();
            Console.WriteLine("Done drawing the image");

        }

        public static void Test()
        {
            var img = new LazyBitmap("pokemon.png");
            DrawImage(img);
        }
    }

    public interface IImage
    {
        void Draw();
    }

    class Bitmap : IImage
    {
        private readonly string filename;

        public Bitmap(string filename)
        {
            this.filename = filename;
            Console.WriteLine($"Loading image from {filename}");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing image {filename}");
        }
    }

    class LazyBitmap : IImage
    {
        private readonly string filename;
        private Bitmap bitmap;

        public LazyBitmap(string filename)
        {
            this.filename = filename;
        }


        public void Draw()
        {
            if (bitmap == null)
                bitmap = new Bitmap(filename);

            bitmap.Draw();
        }
    }
}
