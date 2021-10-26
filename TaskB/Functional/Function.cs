using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Function
    {
        //Вывод информации о сувенирах и их поизводителях
        public static void DisplayAllInformation()
        {
            //Проверка списка на пустоту
            if (AddDelete.collectionClass.Length() > 0)
            {
                //Проход по элементам списка
                foreach (Souvenir souvenir in AddDelete.collectionClass)
                {
                    //Показ информации о сувенире
                    souvenir.DisplayInformationSouvenir();
                    //Проход по элемнтам словаря
                    foreach (KeyValuePair<int, Manufacturer> keyValue in AddDelete.Manufacturers)
                    {
                        //Если равны ключ и реквизиты производителя
                        if (keyValue.Key == souvenir.ManufacturerRequisites)
                        {
                            //Показ информации о производителе
                            AddDelete.Manufacturers[keyValue.Key].DisplayInformationManufacturer();
                            break;
                        }
                    }
                }
            }
            //Если список пуст
            else Console.WriteLine("Нет информации о сувенирах!");
        }

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
            string name = Input.InputManufacturerName();
            bool flag = false;
            Console.WriteLine("Информация о сувенирах заданного производителя: ");

            //Механизм обработки исключительных ситуаций(если нет производителя с таким названием)
            try
            {
                //Проход по элементам словаря
                foreach (KeyValuePair<int, Manufacturer> keyValue in AddDelete.Manufacturers)
                {//Проверка, есть ли такое название
                    if (keyValue.Value.ManufacturerName == name)
                        KeyMatchingForList(keyValue.Key, ref flag);
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
            string country = Input.InputManufacturerCountry();
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
            decimal price = Input.InputPrice();
            bool flag = false;
            Console.WriteLine("Информация o производителях, чьи цены на сувениры меньше заданной: ");

            //Механизм обработки исключительных ситуаций(если нет цены на сувениры меньше заданной)
            try
            {
                //Проход по элементам списка
                foreach (Souvenir value in AddDelete.collectionClass)
                {
                    if (value.Price < price)
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
                Console.WriteLine($"Сувенира с ценой, меньше чем {price} нет в базе!");
            }
        }

        //Метод для вывода информации о производителях заданного сувенира, произведенного в заданном году
        public static void DisplayInformationByDate()
        {
            string souvenirName = Input.InputSouvenirName();
            int releaseDate = Input.InputReleaseDate();
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
        //Метод изменения цены сувенира по ID
        public static void PriceChange(ref bool flag)
        {
            Console.Write("Введите ID сувенира: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Введите натуральное число: ");
            }
           
            //Механизм обработки исключительных ситуаций(если нет сувенира с заданным названием и датой)
            try
            {
                //Проход по элементам списка
                foreach (Souvenir value in AddDelete.collectionClass)
                {
                    //Если подходит под условия
                    if (value.ManufacturerRequisites == id)
                    {
                        decimal price = Input.InputPrice();
                        if (value.Price != price)
                        {
                            value.Price = price;
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели старую цену!");
                            return;
                        }
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Сувенира с ID {id} нет в базе!");
            }
        }
        //Оповещение об изменении цены
        public static void PriceChangeNotification(ref bool flag)
        {
            if (flag)
             Console.WriteLine($"Вы изменили цену!"); 
        }

        //Метод который сортирует список по параметру, в зависимости от переданного делегата
        public static void SortList(EventDelegate.SortDelegate sortDelegate)
        {
            if (AddDelete.collectionClass.Length() > 0)
            {
                sortDelegate();
                Console.WriteLine("Список отсортирован!");
            }
            else Console.WriteLine("Списк пуст!");
        }
    }
}
