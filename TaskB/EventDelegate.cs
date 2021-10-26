using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class EventDelegate
    {
        //Делегат для изменения цены
        public delegate void PriceChangeDelegate(ref bool flag);
        //Делегат для сортировки
        public delegate void SortDelegate();

        //Класс, который содержит значение для использования событий
        public class KeyEventArgs : EventArgs
        {
            public int key;
        }
    }
}
