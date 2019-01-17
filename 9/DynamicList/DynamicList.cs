using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicList
{
    class DynamicList<T> : IEnumerable<T>
    {
        private T[] arr;

        public DynamicList()
        {
            arr = new T[0];
        }

        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public int Count
        {
            get => arr.Count();
        }

        public void Add(T item)
        {
            T[] tempArr = arr;
            arr = new T[arr.Length + 1];
            tempArr.CopyTo(arr, 0);
            arr[arr.Length - 1] = item;
        }
        
        public void Clear()
        {
            RemoveAt(0, arr.Length);
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(arr, item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            RemoveAt(index, 1);
        }

        public void RemoveAt(int index, int length)
        {
            if (index > arr.Length) index = arr.Length;
            if (index < 0) index = 0;
            if (arr.Length < index + length)
            {
                length = arr.Length - index;
            }
            
            T[] tempArr = arr;
            arr = new T[arr.Length - length];
            Array.Copy(tempArr, arr, index);
            Array.Copy(tempArr, index + length, arr, index, tempArr.Length - length - index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }
    }
}
