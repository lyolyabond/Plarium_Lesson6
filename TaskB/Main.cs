using System;

//4. Сувениры.В сущностях(типах) хранится информация о сувенирах и их производителях.
//Для сувениров необходимо хранить:
//— название;
//— реквизиты производителя;
//— дату выпуска;
//— цену.
//Для производителей необходимо хранить:
//— название;
//— страну.
//Вывести информацию о сувенирах заданного производителя.
//Вывести информацию о сувенирах, произведенных в заданной стране.
//Вывести информацию о производителях, чьи цены на сувениры меньше заданной.
//Вывести информацию о производителях заданного сувенира, произведенного в заданном году.
//Удалить заданного производителя и его сувениры.


namespace TaskB
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("--Выберите действие: --");
            Console.WriteLine("1 - Не использовать объекты по умолчанию\n2 - Инициализировать по умолчанию");
           int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    //Вызов метода с меню для консоли
                    Menu.ConsoleMenu();
                    break;

                case 2:
                    //Добавление в список сувениров и в словарь произаодителей
                    Function.collectionClass.Add(new Classes.Souvenir("монета", 1, 2006, 1006.26m));
                    Function.AddManufacturer(new Classes.Manufacturer("Global", "Россия"));
                    Function.collectionClass.Add( new Classes.Souvenir("статуэтка", 2, 2020, 105m));
                    Function.AddManufacturer(new Classes.Manufacturer("UKR", "Украина"));
                    Function.collectionClass.Add(new Classes.Souvenir("магнитик", 3, 2020, 12000m));
                    Function.AddManufacturer(new Classes.Manufacturer("Global", "Украина"));
                    //Установка значения статического поля в конечный ключ
                    Function.ID = 3;
                    Console.Clear();
                    //Вызов метода с меню для консоли
                    Menu.ConsoleMenu();
                    break;

                default: break;
            }  
        }
    }
}
