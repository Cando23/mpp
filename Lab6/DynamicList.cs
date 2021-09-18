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
            Count = 0;
            _array = new T[0];
        }
        private T[] _array;
        public int Count { get; private set; }

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
            set { 
                _array[index] = value;
                Count++;
            }
        }

        public bool Add(T newItem)
        {
            try
            {
                Array.Resize(ref _array, Count+1);
                _array[Count++] = newItem;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool Remove(T item)
        {
            try
            {
                var index = Array.IndexOf(_array, item);
                _array = _array.Where((val, i) => i != index).ToArray();
                Count--;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool RemoveAt(int index)
        {
            
            try
            {
                _array = _array.Where((val, i) => index != i).ToArray();
                Count--;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public void Clear()
        {
            Array.Clear(_array, 0, Count);
            Array.Resize(ref _array,0);
            Count = 0;
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