using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;

//5.Реализовать структуру «черный ящик», хранящую множество чисел имеющую внутренний счетчик K,
//изначально равный нулю. Структура должна поддерживать операции добавления числа
//в множество и возвращение K-го по минимальности числа из множества.

namespace TaskA
{
    class Program
    {
        //Метод выводит содержимое множества или показывает, что пустое
        public static void DisplaySetOfNumbers(SortedSet<double> setOfNumbers)
        {
            Console.WriteLine("\n--Множество--");
            if (setOfNumbers.Count == 0)
                Console.Write("Пустое множество");
            else
            {
                foreach (var value in setOfNumbers)
                {
                    Console.Write($"{value} ");
                }
            }
        }

        static void Main(string[] args)
        {
            Structure.BlackBox blackBox;
            blackBox.K = 0;
            blackBox.setOfNumbers = new SortedSet<double>();

           
            Console.Write("Введите сколько чисел вы хотите добавить в множество: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count<0)
            {
                Console.Write("Ошибка! Введите корректное значение: ");
            }
      //Первоначальное добавления чисел в множество
            for(int i = 0; i < count; i++)
            {
                Console.Write($"Введите {i + 1} значение: ");
                blackBox.AddNumber(double.Parse(Console.ReadLine()));
            }
            DisplaySetOfNumbers(blackBox.setOfNumbers);
           

            int num;
            do
            {
            //Меню 
                Console.WriteLine("\nВыберите, какую операцию хотите совершить:\n1 - Добавить число в множество" +
                    "\n2 - Найти K-ое по минимальности число из множества\n3 - выйти");
                num = int.Parse(Console.ReadLine());
                switch(num)
                {
                    case 1:
                        Console.Write($"Введите число, которое хотите добавить: ");
                        //Вызов метода добавления нового числа
                        blackBox.AddNumber(double.Parse(Console.ReadLine()));
                        //Показ содержимого множества
                        DisplaySetOfNumbers(blackBox.setOfNumbers);
                        break;
                    case 2:
                        Console.Write($"Введите K-ый индекс числа по минимальности: ");
                        //Присваивание нового значения счётчику
                        blackBox.K = int.Parse(Console.ReadLine());
                        bool flag = true;
                        //Вызов метода возвращения K-го по минимальности числа из множества
                        double result = blackBox.MinimumElementByKNumber(ref flag);
                        if (flag)
                        Console.WriteLine($"Это число {result}");
                        else Console.WriteLine($"Такого индекса не существует!");
                        break;
                    default: break;
                }
            } while (num != 3);
        
        }
    }
}
