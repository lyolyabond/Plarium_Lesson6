using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Menu
    {
        public static void ConsoleMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--Выберите, какое действие хотите совершить--");
                Console.WriteLine("0 - Добавить сувенир\n1 - Вывести информацию о сувенирах заданного производителя " +
                    " \n2 - Вывести информацию о сувенирах, произведенных в заданной стране " +
                    " \n3 - Вывести информацию о производителях, чьи цены на сувениры меньше заданной " +
                    "\n4 - Вывести информацию о производителях заданного сувенира, произведенного в заданном году " +
                    "\n5 - Удалить заданного производителя и его сувениры \n6 - Вывести информацию о сувенирах " +
                    "\n7 - выйти\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Function.EnterInformation();
                        break;
                    case 1:
                        Console.Clear();
                        Function.DisplayInformationByManufacturer();
                        break;
                    case 2:
                        Console.Clear();
                        Function.DisplayInformationByCountry();
                        break;
                    case 3:
                        Console.Clear();
                        Function.DisplayInformationByPrice();
                        break;
                    case 4:
                        Console.Clear();
                        Function.DisplayInformationByDate();
                        break;
                    case 5:
                        Console.Clear();
                        Function.DeleteItemByManufacturer();
                        break;
                    case 6:
                        Console.Clear();
                        //Вывод информации обо всех сувенирах и их производителях
                        if (Function.collectionClass.Length() > 0)
                        {
                            foreach (Classes.Souvenir souvenir in Function.collectionClass)
                            {
                                souvenir.DisplayInformationSouvenir();
                                foreach (KeyValuePair<int, Classes.Manufacturer> keyValue in Function.Manufacturers)
                                {
                                    //Если равны ключ и реквизиты производителя
                                    if (keyValue.Key == souvenir.ManufacturerRequisites)
                                    {
                                        Function.Manufacturers[keyValue.Key].DisplayInformationManufacturer();
                                        break;
                                    }
                                }
                            }
                        }
                        else Console.WriteLine("Нет информации о сувенирах!");
                        break;
                    default: break;
                }
            } while (choice != 7);
        }
    }
}
