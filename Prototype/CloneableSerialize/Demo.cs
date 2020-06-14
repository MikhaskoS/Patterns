using System;


namespace Prototype.CloneableSerialize
{
    // Наиболее универсальный способ клонирования - через сериализацию объектов
    // однако, тут нужно точно знать - что может не попасть в сериализацию
    // (например, словари не сериализуются в XML сериализации)

    // Сериализация решает проблему со вложенными объектами, поскольку сериализуется весь граф
    // Минусы - расход памяти, дыры в сериализациях
    public class Demo
    {
        public static void Test()
        {
            Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

            //Foo foo2 = foo.DeepCopy(); // crashes without [Serializable]
            Foo foo2 = foo.DeepCopyXml();

            foo2.Whatever = "xyz";
            Console.WriteLine(foo);
            Console.WriteLine(foo2);
        }
    }

    //[Serializable] // this is, unfortunately, required
    public class Foo
    {
        public uint Stuff;
        public string Whatever;

        public override string ToString()
        {
            return $"{nameof(Stuff)}: {Stuff}, {nameof(Whatever)}: {Whatever}";
        }
    }
}
