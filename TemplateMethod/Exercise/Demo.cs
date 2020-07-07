using System;

namespace TemplateMethod.Exercise
{
    public class Demo
    {
        public static void Test()
        {
            Creature creature1 = new Creature(1, 2);
            Creature creature2 = new Creature(2, 5);

            TemporaryCardDamageGame game1 =
                new TemporaryCardDamageGame(new Creature[] { creature1, creature2 });

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine($"creature1: {creature1.Attack} \\ {creature1.Health}");
                Console.WriteLine($"creature2: {creature2.Attack} \\ {creature2.Health}");
                game1.Combat(0, 1);
                Console.WriteLine($"--creature1: {creature1.Attack} \\ {creature1.Health}");
                Console.WriteLine($"--creature2: {creature2.Attack} \\ {creature2.Health}");
            }
        }
    }

    public class Creature
    {
        public int Attack, Health;

        public Creature(int attack, int health)
        {
            Attack = attack;
            Health = health;
        }
    }

    public abstract class CardGame
    {
        public Creature[] Creatures;

        public CardGame(Creature[] creatures)
        {
            Creatures = creatures;
        }

        // returns -1 if no clear winner (both alive or both dead)
        public int Combat(int creature1, int creature2)
        {
            Creature first = Creatures[creature1];
            Creature second = Creatures[creature2];
            Hit(first, second);
            Hit(second, first);
            bool firstAlive = first.Health > 0;
            bool secondAlive = second.Health > 0;
            if (firstAlive == secondAlive) return -1;
            return firstAlive ? creature1 : creature2;
        }

        // attacker hits other creature
        protected abstract void Hit(Creature attacker, Creature other);
    }

    public class TemporaryCardDamageGame : CardGame
    {
        public TemporaryCardDamageGame(Creature[] creatures) : base(creatures)
        {
        }

        // todo
        protected override void Hit(Creature attacker, Creature other)
        {
            int h1 = other.Health - attacker.Attack;

            if (h1 <= 0) other.Health = h1;
        }
    }

    public class PermanentCardDamage : CardGame
    {
        public PermanentCardDamage(Creature[] creatures) : base(creatures)
        {

        }

        // todo
        protected override void Hit(Creature attacker, Creature other)
        {
            attacker.Health -= other.Attack;
        }
    }

}
