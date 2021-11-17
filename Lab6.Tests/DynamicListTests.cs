using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Lab6.Tests
{
    namespace Lab6.Tests
    {
        public class DynamicListTests
        {   
            [Fact]
            public void TestIndexer()
            {
                var list = new DynamicList<int>{1};
                
                list[0] = 2;
                
                Assert.Equal(2,list[0]);
                Assert.Throws<IndexOutOfRangeException>(()=>list[1]);
                Assert.Throws<IndexOutOfRangeException>(()=>list[1] = 2);
            }
            [Fact]
            public void TestGetEnumerator()
            {
                var list = new DynamicList<int>{1,2,3,4};
                var actualList = new DynamicList<int>();
                
                foreach (var item in list)
                {
                    actualList.Add(item);
                }
                
                Assert.Equal(list,actualList);
            }
            [Fact]
            public void TestAddMethod()
            {
                var list = new DynamicList<int>();
                
                list.Add(1);

                Assert.Equal(1, list[0]);
            }

            [Fact]
            public void TestRemoveMethod()
            {
                var list = new DynamicList<int> {1};
           
                var removed = list.Remove(1);
                var removed2 = list.Remove(1);
  
                Assert.True(removed);
                Assert.False(removed2);
            }

            [Fact]
            public void TestRemoveAtMethod()
            {
                var list = new DynamicList<int> {1};
       
                list.RemoveAt(0);
                var count = list.Count;

                Assert.Equal(0, count);
                Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
            }

            [Fact]
            public void TestClearMethod()
            {
                var list = new DynamicList<int>{1, 2, 3, 4};
                
                list.Clear();
                var count = list.Count;
                
                Assert.Equal(0, count);
            }
        }
    }
}