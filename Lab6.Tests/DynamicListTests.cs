using System;
using System.Collections.Generic;
using Moq;
using Xunit;

   namespace Lab6.Tests
    {
        public class DynamicListTests
        {
            [Fact]
            public void Indexer_ReturnsSameItem()
            {
                var list = new DynamicList<int> {1};
                list[0] = 2;
                Assert.Equal(2, list[0]);
            }
            [Fact]
            public void Indexer_ThrowsOutOfRangeException()
            {
                var list = new DynamicList<int> ();
                Assert.Throws<IndexOutOfRangeException>(() => list[1]);
                Assert.Throws<IndexOutOfRangeException>(() => list[1] = 2);
            }

            [Fact]
            public void GetEnumerator_ReturnsSameList()
            {
                var list = new DynamicList<int> {1, 2, 3, 4};
                var actualList = new DynamicList<int>();
                foreach (var item in list)
                {
                    actualList.Add(item);
                }
                Assert.Equal(list, actualList);
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
                var list = new DynamicList<int> {1};
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
                var list = new DynamicList<int> {1};
                list.RemoveAt(0);
                var count = list.Count;
                Assert.Equal(0, count);
            }

            [Fact]
            public void RemoveAt_NonexistentIndex_ThrowsOutOfRangeException()
            {
                var list = new DynamicList<int> ();
                Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
            }

            [Fact]
            public void Clear_ReturnsZero()
            {
                var list = new DynamicList<int> {1, 2, 3, 4};
                list.Clear();
                var count = list.Count;
                Assert.Equal(0, count);
            }
        }
    }
