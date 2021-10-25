using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    //Класс сувенира
    abstract class Souvenir
    {
        //Инициализирующий конструктор
        protected Souvenir(string souvenirName, int releaseDate, decimal price)
        {
            SouvenirName = souvenirName;
            ReleaseDate = releaseDate;
            Price = price;
        }
        //Конструктор по умолчанию
        public Souvenir()
        { }
        //Абстрактное свойство
        protected abstract string KindOfSouvenir { get; }
        public string SouvenirName { get; set; }
        //Установка ID
        public int ManufacturerRequisites { get;} = ++AddDelete.ID;
        public int ReleaseDate { get;  set; }
        public decimal Price { get; set; }

        public virtual void DisplayInformationSouvenir()
        {
            Console.WriteLine($"Вид сувенира: {KindOfSouvenir}");
            Console.WriteLine($"Название сувенира: {SouvenirName}");
            Console.WriteLine($"Реквизиты производителя(ID): {ManufacturerRequisites}");
            Console.WriteLine($"Год выпуска: {ReleaseDate}");
            Console.WriteLine($"Цена: {Price}");
        }

    }
}

