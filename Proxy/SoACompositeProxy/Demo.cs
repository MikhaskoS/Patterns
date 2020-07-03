using System.Collections.Generic;

namespace Proxy.SoACompositeProxy
{
    public class Demo
    {
        public static void Test()
        {
            var creatures = new BadCreature[100];
            foreach (var c in creatures)
            {
                // В памяти, данные класса BadCreature хранятся в периодическом виде
                // byte int int byte int int... и при работе с массивом таких объектов
                // комп работает неэффективно, прыгая через ненужные параметры
                c.X++; // not memory-efficient
            }

            var creatures2 = new Creatures(100);
            foreach (var c in creatures2)
            {
                c.X++;
            }
        }
    }

    public class BadCreature
    {
        public byte Age;
        public int X, Y;
    }


    public class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct Creature
        {
            private readonly Creatures creatures;
            private readonly int index;

            public Creature(Creatures creatures, int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }


        public Creature this[int index]
          => new Creature(this, index);

        public IEnumerator<Creature> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
                yield return new Creature(this, pos);
        }
    }
}
