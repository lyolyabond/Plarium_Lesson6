using System;
using System.Collections.Generic;
//4. Сувениры.В сущностях(типах) хранится информация о сувенирах и их производителях.
//Для сувениров необходимо хранить:
//— название;
//— реквизиты производителя;
//— дату выпуска;
//— цену.
//Для производителей необходимо хранить:
//— название;
//— страну.
//Вывести информацию о сувенирах заданного производителя.
//Вывести информацию о сувенирах, произведенных в заданной стране.
//Вывести информацию о производителях, чьи цены на сувениры меньше заданной.
//Вывести информацию о производителях заданного сувенира, произведенного в заданном году.
//Удалить заданного производителя и его сувениры.


namespace TaskB
{
    class Program
    {
       
        static void Menu()
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
                        Function.EnterInformation();
                    
                        break;
                    case 1:
                        Function.DisplayInformationByManufacturer();
                        break;
                    case 2:
                        Function.DisplayInformationByCountry();
                        break;
                    case 3:
                        Function.DisplayInformationByPrice();
                        break;
                    case 4:
                        Function.DisplayInformationByDate();
                        break;
                    case 5:
                        Function.DeleteItemByManufacturer();
                        break;
                    case 6:
                        if(Function.collectionClass.Length() > 0)
                        {
                            foreach(Classes.Souvenir souvenir in Function.collectionClass)
                            {
                                souvenir.DisplayInformationSouvenir();
                                 foreach (KeyValuePair<int, Classes.Manufacturer> keyValue in Function.Manufacturers)
                                {
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

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("--Выберите действие: --");
            Console.WriteLine("1 - Добавить сувениры и ввести информацию о них\n2 - Инициализировать по умолчанию");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:  
                    Menu();
                    break;

                case 2:

                    Function.collectionClass.Add(new Classes.Souvenir("монета", 1, 2006, 1006.26m));
                    Function.AddManufacturer(new Classes.Manufacturer("Global", "Россия"));
                    Function.collectionClass.Add( new Classes.Souvenir("статуэтка", 2, 2020, 105m));
                    Function.AddManufacturer(new Classes.Manufacturer("UKR", "Украина"));
                    Function.collectionClass.Add(new Classes.Souvenir("магнитик", 3, 2020, 12000m));
                    Function.AddManufacturer(new Classes.Manufacturer("Global", "Украина"));
                    Console.Clear();
                    Menu();
                    break;

                default: break;
            }  
        }
    }
}
