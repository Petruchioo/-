using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1
{
    public class Program //заменить public на internal 
    {
        static void Main()
        {
            var allowedOperations = new HashSet<string> { "+", "-" };
            Console.WriteLine("Введите выражение для вычисления и нажмите enter:");
            var input = Console.ReadLine().Trim().ToLower();
            var splited = input.Split();
            if (splited.Length == 0)
            {
                throw new ArgumentException(nameof(input));
            }
            for (int i = 0; i < splited.Length; i++)
            {
                if (i % 2 != 0) // лучше сначала отлавливать аргумент i % 2 == 0 и потом уже числа
                {
                    if (!allowedOperations.Contains(splited[i]))
                    {
                        throw new ArgumentOutOfRangeException(splited[i]); // я бы пробросил  ArgumentException
                    }
                }
                else
                {
                    if (!int.TryParse(splited[i], out var _))
                    {
                        throw new ArgumentOutOfRangeException(splited[i]); // я бы пробросил  ArgumentException
                    }
                }
            }
            var result = 0;
            var lastOperation = "+";
            for (int i = 0; i < splited.Length; i++)
            {
                if (i % 2 != 0)
                {
                    lastOperation = splited[i];
                }
                else
                {
                    switch (lastOperation)
                    {
                        case "+":
                            result += int.Parse(splited[i]);
                            break;
                        case "-":
                            result -= int.Parse(splited[i]);
                            break;
                    }
                }

            }
            Console.WriteLine($"Результат: {result}");
        }
    }
}
