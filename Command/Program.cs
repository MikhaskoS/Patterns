using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    // Здесь приведен пример более универсального паттерна Command.
    // Во-первых, обработка команд вынесена из основного класса,что соответствует SOLID
    // Во-вторых, паттерн Command совмещен с паттерном Composite (компоновщик), что позволяет
    //  группировать комманды
    class Program
    {
        static void Main(string[] args)
        {
            Command.Demo.Test();

            //var demo = new DemoClass();
            //var command = new SingleCommand(demo, SingleCommand.Action.CommAdd, 20);
            //command.Call();
            //Console.WriteLine(demo);
            //command.Undo();
            //Console.WriteLine(demo);
            //-------------------------------

            var demo1 = new DemoClass();
            var command1 = new SingleCommand(demo1, SingleCommand.Action.CommAdd, 20);
            var command2 = new SingleCommand(demo1, SingleCommand.Action.CommAdd, 40);
            var command3 = new SingleCommand(demo1, SingleCommand.Action.CommRemove, 10);
            var commands = new CompositeCommand(new[] { command1, command2, command3 });
            commands.Call();
            Console.WriteLine(demo1);
            commands.Undo();
            Console.WriteLine(demo1);
        }
    }

    public class DemoClass
    {
        private int balance;
        private int min = 0;
        private int max = 100;
        public bool AddCommand(int val)
        {
            if (balance + val > max)
                return false;
            else
            {
                balance += val;
                return true;
            }

        }
        public bool RemoveCommand(int val)
        {
            if (balance - val < 0)
                return false;
            else
            {
                balance -= val;
                return true;
            }
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public interface ICommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
    }

    public class SingleCommand : ICommand
    {
        private readonly DemoClass demo;
        private readonly Action action;
        private readonly int amount;

        public enum Action
        {
            CommAdd, CommRemove
        }

        public SingleCommand(DemoClass demo, Action action, int amount)
        {
            this.demo = demo;
            this.action = action;
            this.amount = amount;
        }

        #region ICommand

        public bool Success { get; set; }

        public void Call()
        {
            switch (action)
            {
                case Action.CommAdd:
                    Success = demo.AddCommand(amount);
                    break;
                case Action.CommRemove:
                    Success = demo.RemoveCommand(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!Success) return;
            switch (action)
            {
                case Action.CommAdd:
                    Success = demo.RemoveCommand(amount);
                    break;
                case Action.CommRemove:
                    Success = demo.AddCommand(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }

    public class CompositeCommand : List<SingleCommand>, ICommand
    {
        public CompositeCommand()
        {

        }

        public CompositeCommand(IEnumerable<SingleCommand> collection ) : base (collection)
        {

        }

        #region  ICommand

        public bool Success { get; set; }

        public void Call()
        {
            Success = true;
            ForEach(cmd =>
            {
                cmd.Call();
                Success &= cmd.Success;
            });
        }

        public void Undo()
        {
            // в обратном порядке
            foreach (var cmd in ((IEnumerable<SingleCommand>)this).Reverse())
            {
                cmd.Undo();
            }
        }

        #endregion
    }
}
