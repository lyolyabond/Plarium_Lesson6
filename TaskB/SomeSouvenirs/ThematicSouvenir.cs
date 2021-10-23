using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class ThematicSouvenir : Souvenir
    {
        //Реализация абстрактного свойства
        protected override string KindOfSouvenir => "Тематический сувенир";
        public string SubjectMatter { get; set; }
        public ThematicSouvenir(string souvenirName, string subjectMatter,  int releaseDate, decimal price)
            : base(souvenirName, releaseDate, price)
        {
            SubjectMatter = subjectMatter;
        }
        public ThematicSouvenir()
        { }
        //Переопределение метода
        public override void DisplayInformationSouvenir()
        {
            base.DisplayInformationSouvenir();
            Console.WriteLine($"Название тематики сувенира: {SubjectMatter}");
            Console.WriteLine("--------------------------");
        }
    }
}
