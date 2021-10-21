using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
     class Structure
    {
        //Структура "Чёрный ящик"
        public struct BlackBox
        {
            //Отсортированное множество
            public SortedSet<double> setOfNumbers;
            //Счётчик К
            public int K;
            //Метод добавления уникального числа в множество
            public void AddNumber(double number)
            {
                if(setOfNumbers.Add(number))
                {
                    Console.WriteLine("Число успешно добавлено в множество!");
                }
                else Console.WriteLine("Число не добавлено, потому что такое уже есть в множестве!");
            }
            //Метод возвращение K-го по минимальности числа из множества
            public double MinimumElementByKNumber(ref bool flag)
            {
                int i = 0;
                //Проверка, что К лежит в диапазаноне от 0 до количества чисел в множестве
                if(K <= setOfNumbers.Count - 1  && K >= 0)
                { 
                    //Проход по элементам множества
                    foreach(double value in setOfNumbers)
                    {
                        //Если индекс совпадает с заданным
                        //Возвращает i-тый элемент
                        if(i == K)  
                        return value;
                    
                         ++i;
                     }
                }
                //Флаг показывает, что не найдено элемент по такому индексу
                flag = false;
                return -1;
                   
            }
        }
    }
}
