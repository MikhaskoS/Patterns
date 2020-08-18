﻿using System;


namespace ChainOfResponsibility.BrokerChain
{
    // В этом примере реализуется принцип CQS (Command Query Separation)
    // в соотвтствии с которым команды и запросы разделяются

    public class Demo
    {
        public static void Test()
        {
            var game = new Game();
            var goblin = new Creature(game, "Strong Goblin", 2, 2);
            Console.WriteLine(goblin);

            using (new DoubleAttackModifier(game, goblin))
            {
                Console.WriteLine(goblin);
                //using (new IncreaseDefenseModifier(game, goblin))
                //{
                //    Console.WriteLine(goblin);
                //}
            }

            Console.WriteLine(goblin);
        }
    }

    #region Query - запрос
    
    public class Query
    {
        public string CreatureName;

        public enum Argument
        {
            Attack, Defense
        }

        public Argument WhatToQuery;

        public int Value; // bidirectional

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName;
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    #endregion

    #region Game 
    
    public class Game // mediator pattern
    {
        public event EventHandler<Query> Queries; // effectively a chain

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    #endregion

    #region Creature

    public class Creature
    {
        private readonly Game game;
        public string Name;
        // первоначальные значения параметров
        private readonly int attack;
        private readonly int defense;

        public Creature(Game game, string name, int attack, int defense)
        {
            this.game = game;
            this.Name = name;
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q);   // срабатывание события
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q);   // срабатывание события
                return q.Value;
            }
        }

        public override string ToString() // no game
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(attack)}: {Attack}, " +
                   $"{nameof(defense)}: {Defense}";
            // ^^^^^^ using a property  ^^^^^^^^^
        }
    }

    #endregion

    #region Modifiers 

    public abstract class CreatureModifier : IDisposable
    {
        protected readonly Game game;
        protected readonly Creature creature;

        protected CreatureModifier(Game game, Creature creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;    // подписываемся на события
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature)
          : base(game, creature) { }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == creature.Name &&
                q.WhatToQuery == Query.Argument.Attack)
                q.Value *= 2;
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Game game, Creature creature)
            : base(game, creature) { }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == creature.Name &&
                q.WhatToQuery == Query.Argument.Defense)
                q.Value += 2;
        }
    }

    #endregion
}
