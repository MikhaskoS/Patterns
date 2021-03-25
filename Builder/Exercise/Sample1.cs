using System;
using System.Text;


namespace Builder.Exercise
{
    public class Sample1
    {
        public static void Test()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }

    public class CodeBuilder
    {
        private const int _indentSize = 2;  // пробелы (отступ)
        private StringBuilder _codeString = new StringBuilder();

        public CodeBuilder(string className)
        {
            _codeString.Append($"public class {className}\n{{\n");
        }

        public CodeBuilder AddField(string name, string type)
        {
            _codeString.Append(new string(' ', _indentSize));
            _codeString.Append($"public {type} {name};\n");
            return this;
        }

        public override string ToString()
        {
            _codeString.Append("}");
            return _codeString.ToString(); ;
        }
    }

}
