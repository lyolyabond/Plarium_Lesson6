using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class BusinessSouvenir : Souvenir
    {
        //Реализация абстрактного свойства
        protected override string KindOfSouvenir => "Бизнес-сувенир";
        public string CompanyName { get; set; }
        public BusinessSouvenir(string souvenirName, string companyName, int releaseDate, decimal price)
            : base(souvenirName, releaseDate, price)
        {
            CompanyName = companyName;
        }
        public BusinessSouvenir()
        { }
        //Переопределение метода
        public override void DisplayInformationSouvenir()
        {
            base.DisplayInformationSouvenir();
            Console.WriteLine($"Название компании бизнес-сувенира: {CompanyName}");
            Console.WriteLine("--------------------------");
        }
    }
}
