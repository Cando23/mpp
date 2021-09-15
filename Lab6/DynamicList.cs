﻿using System;
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
        public int Count
        {
            get { return _count; }
        }
        public bool Add(T newItem)
        {
            try
            {
                Array.Resize(ref _array, _count+1);
                _array[_count++] = newItem;
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
                int index = Array.IndexOf(_array, item);
                _array = _array.Where((val, i) => i != index).ToArray();
                _count--;
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
                _count--;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) _array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>) _array).GetEnumerator();
        }
    }
    
}