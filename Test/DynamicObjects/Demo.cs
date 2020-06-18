using MoreLinq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.DynamicObjects
{
    class Demo
    {
        internal static void Test()
        {
            // Динамический словарь.
            dynamic person = new DynamicDictionary();

            // Динамические свойства
            person.FirstName = "Ellen";
            person.LastName = "Adams";

            person.ToString();

            // TryInvokeMember делает доступными методы словаря
            person.Remove("firstname");
            person.ToString();

            person.Clear();   // TryInvokeMember
        }

        public class DynamicDictionary : DynamicObject
        {
            Dictionary<string, object> dictionary
                = new Dictionary<string, object>();

            public int Count => dictionary.Count;

            public override bool TryGetMember(
                GetMemberBinder binder, out object result)
            {
                string name = binder.Name.ToLower();
                return dictionary.TryGetValue(name, out result);
            }

            public override bool TrySetMember(
                SetMemberBinder binder, object value)
            {
                dictionary[binder.Name.ToLower()] = value;
                return true;
            }

            // Делаем доступными методы класса Dictionary для DynamicDictionary
            public override bool TryInvokeMember(InvokeMemberBinder binder,
                object[] args, out object result)
            {
                Type dictType = typeof(Dictionary<string, object>);
                try
                {
                    result = dictType.InvokeMember(
                                 binder.Name,
                                 BindingFlags.InvokeMethod,
                                 null, dictionary, args);
                    return true;
                }
                catch
                {
                    result = null;
                    return false;
                }
            }

            public override string ToString()
            {
                dictionary.ForEach((val) => Console.WriteLine($"{val.Key} {val.Value}"));

                return string.Empty;
            }

            public void Print()
            {
                foreach (var pair in dictionary)
                    Console.WriteLine(pair.Key + " " + pair.Value);
                if (dictionary.Count == 0)
                    Console.WriteLine("No elements in the dictionary.");
            }
        }

    }
}
