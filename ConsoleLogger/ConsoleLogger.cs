using System;
using System.ComponentModel.Composition;
using Formatter;

namespace Logger
{
    [Export]
    public class ConsoleLogger
    {
        private FormatterBase formatterBase;

        [Import]        
        private Func<Type, FormatterBase> FormatterFunc { get; set; }

        public void Log(string message, Type formatterType)
        {
            FormatterBase formatterBase = FormatterFunc(formatterType);
            string formattedString = formatterBase.Format(message);
            Console.WriteLine(formattedString);
        }
    }
}
