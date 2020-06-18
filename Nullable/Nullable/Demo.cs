using System;


namespace Nullable.Nullable
{
    public class Demo
    {
        // Минус такого подхода в отсутствии масштабируемости
        // Он хорош для небольших классов
        internal static void Test()
        {
            var log = new ConsoleLog();
            BankAccount bankAccaunt = new BankAccount(log);
            bankAccaunt.Deposit(100);   // Deposited $100, balance is now 100

            // Что, если нам не нужны логи, а внутрь BankAccaunt нельзя лезть
            // Способ 1
            var log1 = new NullLog();
            BankAccount bankAccount1 = new BankAccount(log1);
            bankAccount1.Deposit(200);

            // Способ 2 (обертка над Ilog)
            var log2 = new OptionalLog(null);
            BankAccount bankAccount2 = new BankAccount(log2);
            bankAccount2.Deposit(300);

            BankAccount bankAccount3 = new BankAccount(new OptionalLog(new ConsoleLog()));
            bankAccount3.Deposit(400);
        }
    }

    #region Способ 1

    public sealed class NullLog : ILog
    {
        public void Info(string msg) { }
        public void Warn(string msg) { }
    }

    #endregion

    #region Способ 2

    class OptionalLog : ILog
    {
        private ILog impl;

        public OptionalLog(ILog impl)
        {
            this.impl = impl;
        }

        public void Info(string msg)
        {
            impl?.Info(msg);
        }

        public void Warn(string msg)
        {
            throw new NotImplementedException();
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
