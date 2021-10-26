using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Function
    {   
        //Метод для показа информации о сувенире по ключу
        static void KeyMatchingForList(int key, ref bool flag)
        {
            foreach (Souvenir value in AddDelete.collectionClass)
            {
                if (value.ManufacturerRequisites == key)
                {
                    value.DisplayInformationSouvenir();
                    flag = true;
                }
            }
        }
        //Метод для показа информации о производителю по ключу
        static void KeyMatchingForDictionary(int key, ref bool flag)
        {
            if (AddDelete.Manufacturers.ContainsKey(key))
            {
                AddDelete.Manufacturers[key].DisplayInformationManufacturer();
                flag = true;
            }
        }

        //Метод для вывода информации о сувенирах по названию производителя
        public static void DisplayInformationByManufacturer()
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация о сувенирах заданного производителя: ");
            
            //Механизм обработки исключительных ситуаций(если нет производителя с таким названием)
            try
            {
                //Проход по элементам словаря
                foreach(KeyValuePair<int, Manufacturer> keyValue in AddDelete.Manufacturers)
                {//Проверка, есть ли такое название
                    if (keyValue.Value.ManufacturerName == name)
                KeyMatchingForList( keyValue.Key, ref flag);
                    //Вывод информации по ключу
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия производителя {name} нет в базе!");
            }
        }

        //Метод для вывода информации о сувенирах по названию страны производителя
        public static void DisplayInformationByCountry()
        {
            Console.Write("Введите название страны: ");
            string country = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация o сувенирах, произведенных в заданной стране: ");
            
            //Механизм обработки исключительных ситуаций(если нет страны с таким названием)
            try
            {
                //Проход по элементам словаря
                foreach (KeyValuePair<int, Manufacturer> keyValue in AddDelete.Manufacturers)
                {//Проверка, есть ли такое название страны
                    if (keyValue.Value.ManufacturerCountry == country)
                KeyMatchingForList(keyValue.Key, ref flag);
                    //Вывод информации по ключу
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия страны {country} нет в базе!");
            }

        }

        //Метод для вывода информации о производителях, чьи цены на сувениры меньше заданной
        public static void DisplayInformationByPrice()
        {
            Console.Write("Введите цену: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Введите цену в формате: 105,62 or 105 ");
            }
            bool flag = false;
            Console.WriteLine("Информация o производителях, чьи цены на сувениры меньше заданной: ");
    
            //Механизм обработки исключительных ситуаций(если нет цены на сувениры меньше заданной)
            try
            {
                //Проход по элементам списка
                foreach (Souvenir value in AddDelete.collectionClass)
                {
                    if(value.Price < price)
                    {
                        KeyMatchingForDictionary( value.ManufacturerRequisites, ref flag);
                        //Вывод информации по ключу
                    }

                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Сувенира с ценой, меньше чем {price} нет в базе!");
            }
        }

        //Метод для вывода информации о производителях заданного сувенира, произведенного в заданном году
        public static void DisplayInformationByDate()
        {
            Console.Write("Введите название сувенира: ");
            string souvenirName = Console.ReadLine();
            Console.Write("Введите дату выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate) || releaseDate > 2021)
            {
                Console.Write("Введите год в формате: 2021 ");
            }
            bool flag = false;
            Console.WriteLine("Информация о производителях заданного сувенира, произведенного в заданном году: ");

            //Механизм обработки исключительных ситуаций(если нет сувенира с заданным названием и датой)
            try
            {
                //Проход по элементам списка
                foreach (Souvenir value in AddDelete.collectionClass)
                {
                    //Если подходит под условия
                    if (value.SouvenirName == souvenirName && value.ReleaseDate == releaseDate)
                    {
                        KeyMatchingForDictionary(value.ManufacturerRequisites, ref flag);
                        //Вывод информации по ключу
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Сувенира с названием {souvenirName} и датой выпуска {releaseDate} нет в базе!");
            }
        }

        
    }
}
