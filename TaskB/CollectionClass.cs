using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TaskB
{
    class CollectionClass
    {
        List<Classes.Souvenir> souvenirs;
        public CollectionClass()
        {
            souvenirs = new List<Classes.Souvenir>();
        }
        public Classes.Souvenir this[int index]
        {
            get 
            {
                if (souvenirs.Count > 0)
                   return souvenirs[index];
                else return null;
            }
            set
            {
                souvenirs[index] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < souvenirs.Count; i++)
            {
                yield return souvenirs[i];
            }
        }
        public int Length()
        {
            return souvenirs.Count;
        }
        public void Remove(int key)
        {
            souvenirs.RemoveAt(key);
        }
        public void Add(Classes.Souvenir souvenir)
        {
            souvenirs.Add(souvenir);
        }
    }
}
