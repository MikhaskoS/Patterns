using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;


namespace Singleton.SingletonBase
{
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public static int Count { get; private set; } // для тестрования (убедиться, что = 1)

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");

            // чтение из текстового файла "capitals.txt" вида:
            //Tokyo
            //33200000
            //Manila
            //14750000
            //Lackarta
            //14250000
            capitals = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location)
                  .DirectoryName,
                "capitals.txt")
              )
              .Batch(2)    // <- MoreLinq (загружен чз NuGet)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        // laziness + thread safety (ленивость и потокобезопасность)
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        {
            Count++;
            return new SingletonDatabase();
        });

        public static IDatabase Instance => instance.Value;
    }
}
