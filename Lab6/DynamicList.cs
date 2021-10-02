using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class DynamicList<T> : IEnumerable<T>
    {
        public DynamicList()
        {
            _count = 0;
            _array = new T[0];
        }

        private T[] _array;
        private int _count;
        public int Count => _count;

        public T this[int index]
        {
            get
            {
                try
                {
                    return _array[index];
                }
                catch (IndexOutOfRangeException exception)
                {
                    throw new IndexOutOfRangeException(exception.Message);
                }
            }
            set
            {
                _array[index] = value;
                _count++;
            }
        }

        public void Add(T newItem)
        {
            Array.Resize(ref _array, Count + 1);
            _array[_count++] = newItem;
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(_array, item);
            if (index == -1)
                return false;
            _array = _array.Where((val, i) => i != index).ToArray();
            _count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (_count == 0 || index >= _count || index < 0)
                throw new ArgumentOutOfRangeException();
            _array = _array.Where((val, i) => index != i).ToArray();
            _count--;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, Count);
            Array.Resize(ref _array, 0);
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}