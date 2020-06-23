using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.UserNames
{
    // Пример: когда имен слишком много, то нет смысла для каждого 
    // повторяющегося имени выделять память
    public class Demo
    {
        public static void Test()
        {
            var user1 = new User("Sam Smith");
            var user2 = new User("James Smith");

            Console.WriteLine(User.Count);

            Console.WriteLine(user1.FullName);
            Console.WriteLine(user2.FullName);
        }
    }

    public class User
    {
        // статический массив (на всех), который реализует паттерн "Приспособленец".
        static List<string> strings = new List<string>();
        
        
        private int[] names;

        public static int Count => strings.Count;

        public User(string fullName)
        {
            // если строки нет - добавим и вернем индекс,
            // если нет, вернем индекс
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }
            
            // дробим имя
            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }
}
