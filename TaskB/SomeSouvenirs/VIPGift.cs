using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class VIPGift : Souvenir
    {
        //Реализация абстрактного свойства
        protected override string KindOfSouvenir => "VIP сувенир";
        public string Occasion { get; set; }
        public VIPGift(string souvenirName, string occasion,  int releaseDate, decimal price)
            : base(souvenirName, releaseDate, price)
        {
            Occasion = occasion;
        }
        public VIPGift()
        { }
        //Переопределение метода
        public override void DisplayInformationSouvenir()
        {
            base.DisplayInformationSouvenir();
            Console.WriteLine($"Повод для подарка: {Occasion}");
            Console.WriteLine("--------------------------");
        }
    }
}
