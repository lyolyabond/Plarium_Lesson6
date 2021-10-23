using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class PromotionalSouvenir : Souvenir
    {
        //Реализация абстрактного свойства
        protected override string KindOfSouvenir => "Промосувенир";
        public string CompanyName { get; set; }
        public PromotionalSouvenir(string souvenirName, string companyName, int releaseDate, decimal price)
            : base(souvenirName,  releaseDate, price)
        {
            CompanyName = companyName;
        }
        public PromotionalSouvenir()
        { }
        //Переопределение метода
        public override void DisplayInformationSouvenir()
        {
            base.DisplayInformationSouvenir();
            Console.WriteLine($"Название компании промосувенира: {CompanyName}");
            Console.WriteLine("--------------------------");
        }
    }
}
