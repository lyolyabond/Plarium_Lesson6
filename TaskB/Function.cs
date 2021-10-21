using System;
using System.Collections.Generic;
using System.Text;


namespace TaskB
{
    class Function
    { 
        static int ID = 0;
        public static Dictionary<int, Classes.Manufacturer> Manufacturers = new Dictionary<int, Classes.Manufacturer>();
        public static CollectionClass collectionClass = new CollectionClass();

        public static void AddManufacturer(Classes.Manufacturer manufacturer)
            {
            Manufacturers.Add(++ID, manufacturer);
            }
      
        //Метод ввода информации о сувенире
        public static void EnterInformation()
        {
            Console.Write("Введите название сувенира: ");
            string souvenirName = Console.ReadLine();
           

            Console.Write("Введите год выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate) || releaseDate > 2021)
            {
                Console.Write("Введите год в формате 2021: ");
            }
            Console.Write("Введите цену: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Введите цену в формате 105,62 или 105: ");
            }

            collectionClass.Add(new Classes.Souvenir(souvenirName, ID, releaseDate, price));

            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            Console.Write("Введите страну производителя: ");
            string country = Console.ReadLine();
            Console.WriteLine("--------------------------");

            Classes.Manufacturer manufacturer = new Classes.Manufacturer(name, country);
            AddManufacturer( manufacturer);
        }

       /*public static void AddToList(Classes.Souvenir souvenir)
        {   
                collectionClass[collectionClass.Length()] = souvenir;
        }*/



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
                foreach(KeyValuePair<int, Classes.Manufacturer> keyValue in Manufacturers)
                {
                    if (keyValue.Value.ManufacturerName == name)
                KeyMatchingForList( keyValue.Key, ref flag);
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
                foreach (KeyValuePair<int, Classes.Manufacturer> keyValue in Manufacturers)
                {
                    if (keyValue.Value.ManufacturerCountry == country)
                KeyMatchingForList(keyValue.Key, ref flag);
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия страны {country} нет в базе!");
            }

        }
        static void KeyMatchingForList(int key, ref bool flag)
        {
                foreach(Classes.Souvenir value in collectionClass)
                { 
                    if (value.ManufacturerRequisites == key)
                    {
                        value.DisplayInformationSouvenir();
                        flag = true;
                    }
                }
        }
        static void KeyMatchingForDictionary( int key, ref bool flag)
        {
            if(Manufacturers.ContainsKey(key))
            {
                Manufacturers[key].DisplayInformationManufacturer();
                flag = true;
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
                foreach (Classes.Souvenir value in collectionClass)
                {
                    if(value.Price < price)
                    {
                        KeyMatchingForDictionary( value.ManufacturerRequisites, ref flag);
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
                foreach (Classes.Souvenir value in collectionClass)
                {
                    if (value.SouvenirName == souvenirName && value.ReleaseDate == releaseDate)
                    {
                        KeyMatchingForDictionary(value.ManufacturerRequisites, ref flag);
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

        //Метод для удаления элементов массива по заданному названию производителя
        public static void DeleteItemByManufacturer()
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            bool flag = false; 
            
            //Механизм обработки исключительных ситуаций(если нет сувенира с заданным названием производителя)
            try
            {
                foreach (KeyValuePair<int, Classes.Manufacturer> keyValue in Manufacturers)
                {
                    if (keyValue.Value.ManufacturerName == name)
                    {
                        Manufacturers.Remove(keyValue.Key);
                        for (int i = 0; i < collectionClass.Length(); i++)
                        {
                            if(collectionClass[i].ManufacturerRequisites == keyValue.Key)
                            {
                                collectionClass.Remove(i);
                                flag = true;
                            }
                        }
                    }
                }
                if(flag)
                {
                    
                    Console.WriteLine("Удаление прошло успешно!");
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Производителя с названием {name} нет в базе!");
            }

        }
    }
}
