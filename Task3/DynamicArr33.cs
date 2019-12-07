using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArr33<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        T[] dynArr = null;
        public int Length { get; set; } = 0;
        public int Capacity => dynArr.Length;
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();
        public DynamicArrEnum<T> GetEnumerator() => new DynamicArrEnum<T>(ToArray());
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();
        public object Clone() => new DynamicArr33<T>(dynArr);
        public T this[int i]
        {
            get
            {
                if (i >= Length || i < -Length)
                    throw new ArgumentException("Check index");
                if (i >= 0)
                    return dynArr[i];
                else
                    return dynArr[Length + i];
            }
            set
            {
                if (i >= Length || i < -Length)
                    throw new ArgumentException("Check index");
                if (i >= 0)
                    dynArr[i] = value;
                else
                    dynArr[Length + i] = value;
            }
        }
        public DynamicArr33() { dynArr = new T[8]; }
        public DynamicArr33(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be > 0");
            dynArr = new T[capacity];
        }
        public DynamicArr33(IEnumerable<T> arr)
        {
            dynArr = new T[arr.Count()];
            foreach (var i in arr)
            {
                dynArr[Length] = i;
                Length++;
            }
        }
        public T[] ToArray()
        {
            T[] res = new T[Length];
            for (int i = 0; i < Length; i++)
                res[i] = dynArr[i];
            return res;
        }
        public void NewCapacity(int len)
        {
            int length;
            T[] tmp = new T[len];
            if (dynArr.Length > len)
                length = len;
            else
                length = dynArr.Length;
            for (int i = 0; i < length; i++)
                tmp[i] = dynArr[i];
            dynArr = tmp;
        }
        public void CapacityChecking(int len)
        {
            int capacity = Capacity;
            while (len > capacity)
                capacity *= 2;
            if (capacity != Capacity)
                NewCapacity(capacity);
        }
        public void Add(T unit)
        {
            CapacityChecking(Length + 1);
            dynArr[Length] = unit;
            Length++;
        }
        public void AddRange(IEnumerable<T> arr)
        {
            CapacityChecking(Length + arr.Count());
            foreach (var i in arr)
            {
                dynArr[Length] = i;
                Length++;
            }
        }
        public bool Remove(T unit)
        {
            for (int i = 0; i < dynArr.Length; i++)
            {
                if (dynArr[i].GetHashCode() == unit.GetHashCode())
                {
                    for (; i < dynArr.Length - 1; i++)
                        dynArr[i] = dynArr[i + 1];
                    Length--;
                    return true;
                }
            }
            return false;
        }
        public void Insert(int pos, T unit)
        {
            if (pos >= Length || pos < -Length)
                throw new ArgumentOutOfRangeException("Check index");
            CapacityChecking(Length++);
            if (pos < 0)
                pos = Length + pos;
            for (int i = Length - 1; i > pos; i--)
                dynArr[i + 1] = dynArr[i];
            dynArr[pos] = unit;
        }
        public static void DynamicArrDisplay()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            DynamicArr33<int> arr1 = new DynamicArr33<int>();
            arr1.AddRange(nums);
            arr1.Add(9);
            arr1.Add(10);
            Console.WriteLine("Elements from first array:");
            foreach (var i in arr1)
                Console.Write(i + " ");
            arr1.Remove(5);
            arr1.Insert(0, 100);
            Console.WriteLine();
            Console.WriteLine("Elements from first array after deleting from middle some element " +
                "and adding in the begining new element:");
            foreach (var i in arr1)
                Console.Write(i + " ");
            var arr2 = (DynamicArr33<int>)arr1.Clone();
            arr2.Remove(6);
            Console.WriteLine();
            Console.WriteLine("Elements from second array (with removed 6 element):");
            foreach (var i in arr2)
                Console.Write(i + " ");
            Console.ReadLine();
        }
    }
}
