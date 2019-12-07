using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArrEnum<T> : IEnumerator<T>
    {
        public T[] arr;
        public int pos = -1;
        public DynamicArrEnum(T[] arr) { this.arr = arr; }
        public void Reset() { pos = -1; }
        public void Dispose() { }
        object IEnumerator.Current => Current;
        public T Current
        {
            get
            {
                try
                {
                    return arr[pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            pos++;
            return (pos < arr.Length);
        }
    }
}
