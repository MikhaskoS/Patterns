using ImpromptuInterface;
using System;
using System.Dynamic;

namespace Nullable.DynamicNullable
{
    public class Demo
    {
        public static void Test()
        {
            var log = Null<ILog>.Instance;
            var bankAccaunt = new BankAccount(log);
            bankAccaunt.Deposit(100);
        }
    }

    #region Способ 3 Dynаmic

    public class Null<T> : DynamicObject where T : class
    {
        //
        public static T Instance
        {
            get
            {
                if (!typeof(T).IsInterface)
                    throw new ArgumentException("I must be an interface type");

                return new Null<T>().ActLike<T>();
            }
        }

        // Делаем так, чтобы наш класс ничего не делал (для безопасности)
        public override bool TryInvokeMember(InvokeMemberBinder binder,
          object[] args, out object result)
        {
            var name = binder.Name;
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }

    #endregion

    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("WARNING: " + msg);
        }
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;// new OptionalLog(log);
        }

        public void Deposit(int amount)
        {
            balance += amount;
            // проверка на null 
            //log?.Info($"Deposited ${amount}, balance is now {balance}");
            log.Info($"Deposited ${amount}, balance is now {balance}");
        }

        public void Withdraw(int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                //log?.Info($"Withdrew ${amount}, we have ${balance} left");
                log.Info($"Withdrew ${amount}, we have ${balance} left");
            }
            else
            {
                //log?.Warn($"Could not withdraw ${amount} because " +
                //          $"balance is only ${balance}");
                log.Warn($"Could not withdraw ${amount} because " +
                        $"balance is only ${balance}");
            }
        }
    }
}
