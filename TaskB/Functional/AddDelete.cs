using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class AddDelete
    {
        //Переменная, которая хранит последний ключ
        public static int ID = 0;
        //Коллекция, которая хранит ключи и объекты класса производителя
        public static Dictionary<int, Manufacturer> Manufacturers = new Dictionary<int, Manufacturer>();
        //Объект класса для работы со списком сувениров
        public static CollectionClass collectionClass = new CollectionClass();

        //Метод добавления объекта производителя в словарь
        public static void AddManufacturer(Manufacturer manufacturer)
        {
            Manufacturers.Add(ID, manufacturer);
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
                //Проход по элементам словаря
                foreach (KeyValuePair<int, Manufacturer> keyValue in Manufacturers)
                {//Проверка, есть ли такое название
                    if (keyValue.Value.ManufacturerName == name)
                    {
                        //Удаление элемента по ключу из словаря производителей
                        Manufacturers.Remove(keyValue.Key);
                        for (int i = 0; i < collectionClass.Length(); i++)
                        {
                            if (collectionClass[i].ManufacturerRequisites == keyValue.Key)
                            {
                                //Удаление элемента по индексу из списка сувениров
                                collectionClass.Remove(i);
                                flag = true;
                            }
                        }
                    }
                }
                if (flag)
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
