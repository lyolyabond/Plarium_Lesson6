﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskB.SomeSouvenirs;

namespace TaskB
{
    class Menu
    {
        public static void ConsoleMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("--Выберите, какое действие хотите совершить--");
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
                        Menu.EnterInformation();
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
                        AddDelete.DeleteItemByManufacturer();
                        break;
                    case 6:
                        Console.Clear();
                        //Вывод информации обо всех сувенирах и их производителях
                        if (AddDelete.collectionClass.Length() > 0)
                        {
                            foreach (Souvenir souvenir in AddDelete.collectionClass)
                            {
                                souvenir.DisplayInformationSouvenir();
                                foreach (KeyValuePair<int, Manufacturer> keyValue in AddDelete.Manufacturers)
                                {
                                    //Если равны ключ и реквизиты производителя
                                    if (keyValue.Key == souvenir.ManufacturerRequisites)
                                    {
                                        AddDelete.Manufacturers[keyValue.Key].DisplayInformationManufacturer();
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

        //Метод для выбора типа сувенира
        public static Souvenir ChooseTypeOfSouvenir()
        {
            Console.WriteLine("Выберите вид сувенира: ");
            Console.WriteLine("1 - Бизнес-сувенир\n2 - Промосувенир\n3 - Тематический сувенир\n4 - VIP сувенир");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Введите число 1-4: ");
            }
            switch (choice)
            {
                case 1:
                    BusinessSouvenir souvenir1 = new BusinessSouvenir();
                    Console.Write("Введите название компании, в которой дарят сувениры: ");
                    souvenir1.CompanyName = Console.ReadLine();
                    return souvenir1;
                case 2:
                    PromotionalSouvenir souvenir2 = new PromotionalSouvenir();
                    Console.Write("Введите название компании, рекламная кампания которой проходит: ");
                    souvenir2.CompanyName = Console.ReadLine();
                    return souvenir2;
                case 3:
                    ThematicSouvenir souvenir3 = new ThematicSouvenir();
                    Console.Write("Введите название тематики сувенира: ");
                    souvenir3.SubjectMatter = Console.ReadLine();
                    return souvenir3;
                case 4:
                    VIPGift souvenir4 = new VIPGift();
                    Console.Write("Введите название повода для подарка: ");
                    souvenir4.Occasion = Console.ReadLine();
                    return souvenir4;
                default:
                    return null;
            }
        }
    

    //Метод ввода информации о сувенире
    public static void EnterInformation()
    {
        Souvenir souvenir = ChooseTypeOfSouvenir();
        if (souvenir != null)
        {
            Console.Write("Введите название сувенира: ");
            souvenir.SouvenirName = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate) || releaseDate > 2021)
            {
                Console.Write("Введите год в формате 2021: ");
            }
            souvenir.ReleaseDate = releaseDate;

            Console.Write("Введите цену: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Введите цену в формате 105,62 или 105: ");
            }
            souvenir.Price = price;

            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            Console.Write("Введите страну производителя: ");
            string country = Console.ReadLine();
            Console.WriteLine("--------------------------");


            //Добавление сувенира в список
            AddDelete.collectionClass.Add(souvenir);
           //Добавление производителя в словарь 
           AddDelete.AddManufacturer(new Manufacturer(name, country));
            Console.Clear();
        }
    }
   
   }
}
