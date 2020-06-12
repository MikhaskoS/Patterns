using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependenceInversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }
}
