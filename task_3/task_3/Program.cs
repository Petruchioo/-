using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IPrinter
    {
        void PrintInConsole(string message);
        void PrintInWebPage(string message, string url);
        void PrintInFile(string message, string path);
        void ChangeConsolePrintColor(ConsoleColor color);
        ConsoleColor GetCurrentConsoleColor();
    }
    public class Printer : IPrinter
    {
        private ConsoleColor _privatePrintColor = ConsoleColor.Red;
        public void ChangeConsolePrintColor(ConsoleColor color)
        {
            _privatePrintColor = color;
        }
        public ConsoleColor GetCurrentConsoleColor() => _privatePrintColor;
        public void PrintInConsole(string message)
        {
            // Set font color to selected
            Console.ForegroundColor = _privatePrintColor;
            Console.WriteLine(message);
            // Востанавливаем поведение по умолчанию
            Console.ForegroundColor = ConsoleColor.White; //если хотим вернуть по умолчанию нужно прописать Console.ForegroundColor 
        }
        public void PrintInFile(string message, string path)
        {
            var writer = new StreamWriter(path);
            writer.WriteLine(message);
        }
        public void PrintInWebPage(string message, string url) //а есть? нужно добвать if()
        {
            // У нас нет подключения к интернету
            throw new NotImplementedException();
        }
    }
}
