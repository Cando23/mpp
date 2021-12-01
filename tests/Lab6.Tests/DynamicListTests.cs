using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Lab6.Tests
{
    public class DynamicListTests
    {
        [Fact]
        public void GetEnumerator_ReturnsSameItems()
        {
            var list = new DynamicList<int> { 1, 2, 3, 4 };
            var stub = Mock.Of<IEnumerable<int>>(i => i.GetEnumerator() == list.GetEnumerator());
            var expected = 1;
            foreach (var item in stub)
            {
                Assert.Equal(expected++, item);
            }
        }

        [Fact]
        public void IEnumerableGetEnumerator_ReturnsSameItems()
        {
            var list = new DynamicList<int> { 1, 2, 3, 4 };
            var actualList = new DynamicList<int> { 1, 2, 3, 4 };
            Assert.Equal(list, actualList);
        }

        [Fact]
        public void Indexer_ReturnsSameItem()
        {
            var list = new DynamicList<int> { 1 };
            list[0] = 2;
            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void Indexer_ThrowsOutOfRangeException()
        {
            var list = new DynamicList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => list[1]);
            Assert.Throws<IndexOutOfRangeException>(() => list[1] = 2);
        }

        [Fact]
        public void Add_SingleItem_ReturnsSameItem()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            Assert.Equal(1, list[0]);
        }

        [Fact]
        public void Remove_SingleItem_ReturnsTrue()
        {
            var list = new DynamicList<int> { 1 };
            var removed = list.Remove(1);
            Assert.True(removed);
        }

        [Fact]
        public void Remove_NonexistentItem_ReturnsFalse()
        {
            var list = new DynamicList<int>();
            var removed = list.Remove(1);
            Assert.False(removed);
        }

        [Fact]
        public void RemoveAt_Index_NoElements()
        {
            var list = new DynamicList<int> { 1 };
            list.RemoveAt(0);
            var count = list.Count;
            Assert.Equal(0, count);
        }

        [Fact]
        public void RemoveAt_NonexistentIndex_ThrowsOutOfRangeException()
        {
            var list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
        }

        [Fact]
        public void Clear_list_IsEmpty()
        {
            var list = new DynamicList<int> { 1, 2, 3, 4 };
            list.Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void Count_ReturnsListLength()
        {
            var list = new DynamicList<int> { 1, 2, 3, 4, 5 };
            var count = list.Count;
            Assert.Equal(5, count);
        }
    }
}