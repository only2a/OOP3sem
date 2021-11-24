using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
     interface IGen<T>
    {
        public void Add(T item);
        public bool Remove(T item);
        public void ShowInfo();
     }
}
