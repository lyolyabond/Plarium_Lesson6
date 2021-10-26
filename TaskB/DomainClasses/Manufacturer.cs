using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    //Класс производителя сувениров
    class Manufacturer
    {
        public event EventHandler <EventDelegate.KeyEventArgs> ManufacturerRemoved;
        //Инициализирующий конструктор
        public Manufacturer(string manufacturerName, string manufacturerCountry)
        {
            ManufacturerName = manufacturerName;
            ManufacturerCountry = manufacturerCountry;
        }
        //Конструктор по умолчанию
        public Manufacturer()
        { }
        public string ManufacturerName { get; }
        public string ManufacturerCountry { get; }
        public void DisplayInformationManufacturer()
        {
            Console.WriteLine($"Название производителя: {ManufacturerName}");
            Console.WriteLine($"Страна производителя: {ManufacturerCountry}");
            Console.WriteLine("--------------------------\n");
        }

        //Метод вызывает событие
        public void OnManufacturerRemoved(int key)
        {
            EventDelegate.KeyEventArgs keyEventArgs = new EventDelegate.KeyEventArgs();
            keyEventArgs.key = key;
            //Вызов события, проверка на null перед вызовом
            ManufacturerRemoved?.Invoke(this, keyEventArgs);
        }
    }
}
