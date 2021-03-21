using ListTask;
using System;
using System.Collections.Generic;
using Xunit;

namespace List.Tests
{
    public class MainTests
    {
        [Fact]
        public void MultiplyElementsByTheMin_MultiplyValidListElements_ListWithMultiplyedElements()
        {
            //Arrange
            ListElementsMultiplyer listElementsMultiplyer = new ListElementsMultiplyer();
            var inputList = new List<float> { 3f, 2.5f, 125f, 2f };
            var waitedReslutList = new List<float> { 6f, 5f, 250f, 4f };

            //Act
            var result = listElementsMultiplyer.MultiplyElementsByTheMin( inputList );

            //Assert
            Assert.NotEmpty( result );
            Assert.Equal( waitedReslutList[0], inputList[0] );
            Assert.Equal( waitedReslutList[1], inputList[1] );
            Assert.Equal( waitedReslutList[2], inputList[2] );
            Assert.Equal( waitedReslutList[3], inputList[3] );
        }

        [Fact]
        public void MultiplyElementsByTheMin_MultiplyEmptyListElements_EmptyList()
        {
            //Arrange
            ListElementsMultiplyer listElementsMultiplyer = new ListElementsMultiplyer();
            var inputList = new List<float> {};

            //Act
            var result = listElementsMultiplyer.MultiplyElementsByTheMin( inputList );

            //Assert
            Assert.Empty( result );
        }

        [Fact]
        public void MultiplyElementsByTheMin_MultiplyValidListElementsWithZeroElement_ListWitZeroElements()
        {
            //Arrange
            ListElementsMultiplyer listElementsMultiplyer = new ListElementsMultiplyer();
            var inputList = new List<float> { 3f, 2.5f, 125f, 0f };
            var waitedReslutList = new List<float> { 0, 0, 0, 0 };

            //Act
            var result = listElementsMultiplyer.MultiplyElementsByTheMin( inputList );

            //Assert
            Assert.NotEmpty( result );
            Assert.Equal( waitedReslutList[ 0 ], inputList[ 0 ] );
            Assert.Equal( waitedReslutList[ 1 ], inputList[ 1 ] );
            Assert.Equal( waitedReslutList[ 2 ], inputList[ 2 ] );
            Assert.Equal( waitedReslutList[ 3 ], inputList[ 3 ] );
        }

        [Fact]
        public void MultiplyElementsByTheMin_MultiplyValidListElementsWithNegative_ListWithMultiplyedElements()
        {
            //Arrange
            ListElementsMultiplyer listElementsMultiplyer = new ListElementsMultiplyer();
            var inputList = new List<float> { 3f, 2.5f, 125f, -2f };
            var waitedReslutList = new List<float> { -6f, -5f, -250f, 4f };

            //Act
            var result = listElementsMultiplyer.MultiplyElementsByTheMin( inputList );

            //Assert
            Assert.NotEmpty( result );
            Assert.Equal( waitedReslutList[ 0 ], inputList[ 0 ] );
            Assert.Equal( waitedReslutList[ 1 ], inputList[ 1 ] );
            Assert.Equal( waitedReslutList[ 2 ], inputList[ 2 ] );
            Assert.Equal( waitedReslutList[ 3 ], inputList[ 3 ] );
        }
    }
}
