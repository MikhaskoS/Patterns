using System;
using System.Text;


namespace Decorator.CustomStringBuilder
{
    public class Demo
    {
        // Создается обертка над StringBuilder
        // (StringBuilder нельзя наследовать)
        public static void Test()
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
              .AppendLine("{")
              .AppendLine("}");
            Console.WriteLine(cb);
        }
    }

    public class CodeBuilder 
    {
        private StringBuilder builder = new StringBuilder();
        
        private int indentLevel = 0;

        public CodeBuilder Indent()
        {
            indentLevel++;
            return this;
        }
        public override string ToString()
        {
            return builder.ToString();
        }

        #region Репликация StringBuilder

        public CodeBuilder Append(char value, int repeatCount)
        {
            builder.Append(value, repeatCount);
            return this;
        }

        public CodeBuilder Append(char[] value, int startIndex, int charCount)
        {
            builder.Append(value, startIndex, charCount);
            return this;
        }

        public CodeBuilder Append(string value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(string value, int startIndex, int count)
        {
            builder.Append(value, startIndex, count);
            return this;
        }

        public CodeBuilder AppendLine()
        {
            builder.AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(string value)
        {
            builder.AppendLine(value);
            return this;
        }

        // .......................................
        #endregion
    }
}
