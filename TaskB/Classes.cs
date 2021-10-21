using System;
using System.Collections.Generic;
using System.Text;


namespace TaskB
{
    public class Classes
    {
        //Класс производителя сувениров
        public class Manufacturer
        {
            public Manufacturer(string manufacturerName, string manufacturerCountry)
            {
                ManufacturerName = manufacturerName;
                ManufacturerCountry = manufacturerCountry;
 
            }
            public string ManufacturerName { get; }
            public string ManufacturerCountry { get; }
            public void DisplayInformationManufacturer()
            {
                Console.WriteLine($"Название производителя: {ManufacturerName}");
                Console.WriteLine($"Страна производителя: {ManufacturerCountry}");      
                Console.WriteLine("--------------------------\n");
            }
        }

        //Класс сувенира
        public class Souvenir
        {
           
            //Инициализирующий конструктор
            public Souvenir(string souvenirName, int manufacturerRequisites, int releaseDate, decimal price)
            {
                SouvenirName = souvenirName;
                ManufacturerRequisites = manufacturerRequisites;
                ReleaseDate = releaseDate;
                Price = price;
               
            }
            //Конструктор по умолчанию
            public Souvenir()
            { }

            public string Country { get; set; }
            public string SouvenirName { get; set; }
            public int ManufacturerRequisites { get; set; }
            public int ReleaseDate { get; set; }
            public decimal Price { get; set; }
           
          
            public void DisplayInformationSouvenir()
            {
                Console.WriteLine($"Название сувенира: {SouvenirName}");
                Console.WriteLine($"Реквизиты производителя(ID): {ManufacturerRequisites}");
                Console.WriteLine($"Год выпуска: {ReleaseDate}");
                Console.WriteLine($"Цена: {Price}");
                Console.WriteLine("--------------------------");
            }

            
        }
        
    }
}
