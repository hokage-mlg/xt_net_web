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
        public T[] Arr;
        public int Pos = -1;
        public DynamicArrEnum(T[] Arr) { this.Arr = Arr; }
        public void Reset() { Pos = -1; }
        public void Dispose() { }
        object IEnumerator.Current => Current;
        public T Current
        {
            get
            {
                try
                {
                    return Arr[Pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public bool MoveNext()
        {
            Pos++;
            return (Pos < Arr.Length);
        }
    }
}
