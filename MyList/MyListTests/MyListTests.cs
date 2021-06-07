using MyList;
using MyListLib;
using System;
using Xunit;

namespace MyListTests
{
    public class ListTests
    {
        [Fact]
        public void Constructor_CreateEmptyList_ReturnsEmptyList()
        {
            var list = new MyList<int>();

            Assert.Equal( 0, list.GetCount() );
        }

        [Fact]
        public void Constructor_CreateListWithElement_ReturnsListWithOneElement()
        {
            var list = new MyList<int>( 1 );

            Assert.Equal( 1, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
        }

        [Fact]
        public void Constructor_CreateListWithList_ReturnsListWithAllElements()
        {
            var list = new MyList<int> { 1, 2, 3 };

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 2, list[ 1 ].GetData() );
            Assert.Equal( 3, list[ 2 ].GetData() );
        }

        [Fact]
        public void Constructor_CreateListStrings_ReturnsListWithStrings()
        {
            var list = new MyList<string> { "1", "2", "3" };

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( "1", list[ 0 ].GetData() );
            Assert.Equal( "2", list[ 1 ].GetData() );
            Assert.Equal( "3", list[ 2 ].GetData() );
        }

        [Fact]
        public void AddInList_AddInTail_AddedElementInTail()
        {
            var list = new MyList<int>();
            list.Add( 1 );

            Assert.Equal( 1, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
        }

        [Fact]
        public void AddInList_AddInHead_AddedElementInHead()
        {
            var list = new MyList<int>();
            list.Add( 3 );
            list.AddInHead( 1 );

            Assert.Equal( 2, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 3, list[ 1 ].GetData() );
        }

        [Fact]
        public void AddInList_InsertAfter_AddedElementInCenter()
        {
            var list = new MyList<int>();
            list.Add( 3 );
            list.Add( 1 );

            list.InsertAfter( list[ 0 ], 5 );

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( 3, list[ 0 ].GetData() );
            Assert.Equal( 5, list[ 1 ].GetData() );
            Assert.Equal( 1, list[ 2 ].GetData() );
        }

        [Fact]
        public void AddInList_InsertBefoore_AddedElementInCenter()
        {
            var list = new MyList<int>();
            list.Add( 3 );
            list.Add( 1 );
            list.Add( 4 );

            list.InsertBefore( list[ 1 ], 5 );

            Assert.Equal( 4, list.GetCount() );
            Assert.Equal( 3, list[ 0 ].GetData() );
            Assert.Equal( 5, list[ 1 ].GetData() );
            Assert.Equal( 1, list[ 2 ].GetData() );
            Assert.Equal( 4, list[ 3 ].GetData() );
        }

        [Fact]
        public void GetCount_CheckCountOfEmptyList_ReturnsZero()
        {
            var list = new MyList<int>();

            Assert.Equal( 0, list.GetCount() );
        }

        [Fact]
        public void GetCount_CheckCountOfListWithNotNullCount_ReturnsCount()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };

            Assert.Equal( 4, list.GetCount() );
        }

        [Fact]
        public void CheckEmumerator()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            var counter = 0;
            foreach( var i in list.GetStdEnumerator() )
            {
                Assert.Equal( i.GetData(), list[ counter ].GetData() );
                counter++;
            }
        }

        [Fact]
        public void CheckReverseEmumerator()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            var counter = list.GetCount() - 1;
            foreach( var i in list.GetReverseEnumerator() )
            {
                Assert.Equal( i.GetData(), list[ counter ].GetData() );
                counter--;
            }
        }

        [Fact]
        public void DeleteFromList_DeleteFromCenter_ElementDeleted()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            list.Delete( list[ 1 ] );

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 3, list[ 1 ].GetData() );
            Assert.Equal( 4, list[ 2 ].GetData() );
        }

        [Fact]
        public void DeleteFromList_DeleteFromHead_ElementDeleted()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            list.Delete( list[ 0 ] );

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( 2, list[ 0 ].GetData() );
            Assert.Equal( 3, list[ 1 ].GetData() );
            Assert.Equal( 4, list[ 2 ].GetData() );
        }

        [Fact]
        public void DeleteFromList_DeleteFromTail_ElementDeleted()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            list.Delete( list[ 3 ] );

            Assert.Equal( 3, list.GetCount() );
            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 2, list[ 1 ].GetData() );
            Assert.Equal( 3, list[ 2 ].GetData() );
        }

        [Fact]
        public void CheckIndexAccess()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };

            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 2, list[ 1 ].GetData() );
            Assert.Equal( 3, list[ 2 ].GetData() );
            Assert.Equal( 4, list[ 3 ].GetData() );
        }

        [Fact]
        public void CheckCopyConstructor()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };
            var list2 = new MyList<int>( list );


            Assert.Equal( 1, list[ 0 ].GetData() );
            Assert.Equal( 2, list[ 1 ].GetData() );
            Assert.Equal( 3, list[ 2 ].GetData() );
            Assert.Equal( 4, list[ 3 ].GetData() );

            Assert.Equal( 1, list2[ 0 ].GetData() );
            Assert.Equal( 2, list2[ 1 ].GetData() );
            Assert.Equal( 3, list2[ 2 ].GetData() );
            Assert.Equal( 4, list2[ 3 ].GetData() );

            list.Add( 5 );
            Assert.True( list2.GetCount() != 5 );
        }

        [Fact]
        public void CheckIndexAccess_OutOfRange_ReturnOutOfRangeExeption()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };

            Assert.Throws<IndexOutOfRangeException>( () => list[ 10 ] );
        }

        [Fact]
        public void CheckIndexAccess_OutOfRangeLess_ReturnOutOfRangeExeption()
        {
            var list = new MyList<int>() { 1, 2, 3, 4 };

            Assert.Throws<IndexOutOfRangeException>( () => list[ -2 ] );
        }

        [Fact]
        public void CheckListOfLists()
        {
            var listItem = new MyList<int> { 1, 2, 3 };
            var listItem2 = new MyList<int> { 4, 5, 6 };
            var listItem3 = new MyList<int> { 7, 8, 9 };


            var list = new MyList<MyList<int>> { listItem, listItem2, listItem3 };

            Assert.Equal( 1, list[ 0 ].GetData()[ 0 ].GetData() );
            Assert.Equal( 2, list[ 0 ].GetData()[ 1 ].GetData() );
            Assert.Equal( 3, list[ 0 ].GetData()[ 2 ].GetData() );
            Assert.Equal( 4, list[ 1 ].GetData()[ 0 ].GetData() );
            Assert.Equal( 5, list[ 1 ].GetData()[ 1 ].GetData() );
            Assert.Equal( 6, list[ 1 ].GetData()[ 2 ].GetData() );
            Assert.Equal( 7, list[ 2 ].GetData()[ 0 ].GetData() );
            Assert.Equal( 8, list[ 2 ].GetData()[ 1 ].GetData() );
            Assert.Equal( 9, list[ 2 ].GetData()[ 2 ].GetData() );
        }
    }
}
