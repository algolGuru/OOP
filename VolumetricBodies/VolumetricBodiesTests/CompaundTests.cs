using System;
using System.Collections.Generic;
using VolumetricBodies.Bodies;
using Xunit;

namespace VolumetricBodiesTests
{
    public class CompaundTests
    {
        [Fact]
        public void CompaundBodyCreate_TryToAddInvalidBody_Error()
        {
            //Arange
            var baseRadius = 0;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );

            //Act
            var compoundBody = new CompoundBody();
            compoundBody.AddChildBody( cone );

            //Assert
            Assert.True( compoundBody.GetBodies().Count == 0 );
        }

        [Fact]
        public void CompaundBodyCreate_TryToAddValidBody_CompoundBodyGetChildBody()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );

            //Act
            var compoundBody = new CompoundBody();
            compoundBody.AddChildBody( cone );

            //Assert
            Assert.True( compoundBody.GetBodies().Count == 1 );
        }

        [Fact]
        public void CompaundBodyCreate_TryToAddListOfValidBodies_CompoundBodyGetChildBodies()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );
            var cylinder = new Cylinder( baseRadius, height, density );

            //Act
            var compoundBody = new CompoundBody();
            compoundBody.AddChildBody( cone );
            compoundBody.AddChildBody( cylinder );

            //Assert
            Assert.True( compoundBody.GetBodies().Count == 2 );
        }

        [Fact]
        public void CountBodyParams_CountParamsForValidChildBodies_ReturnBodyParams()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );
            var cylinder = new Cylinder( baseRadius, height, density );

            //Act
            var compoundBody = new CompoundBody();
            compoundBody.AddChildBody( cone );
            compoundBody.AddChildBody( cylinder );

            //Assert
            Assert.True( compoundBody.GetBodies().Count == 2 );
            Assert.True( Math.Truncate( compoundBody.GetState().Mass ) == 41887 );
            Assert.True( Math.Truncate( compoundBody.GetState().Volume ) == 4188 );
            Assert.True( Math.Truncate( compoundBody.GetState().Density ) == 10 );
        }

        [Fact]
        public void CountBodyParams_AddCompaundBodyInCompaundBody_ParamsWasIncremented()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );
            var cylinder = new Cylinder( baseRadius, height, density );
            var compoundBody = new CompoundBody();
            var compoundBody2 = new CompoundBody();
            compoundBody2.AddChildBody( cone );
            compoundBody2.AddChildBody( cylinder );


            //Act
            compoundBody.AddChildBody( compoundBody2 );

            //Assert
            Assert.True( compoundBody.GetBodies().Count == 1 );
            Assert.True( Math.Truncate( compoundBody.GetState().Mass ) == 41887 );
            Assert.True( Math.Truncate( compoundBody.GetState().Volume ) == 4188 );
            Assert.True( Math.Truncate( compoundBody.GetState().Density ) == 10 );
        }

        [Fact]
        public void AddChildBody_AddThisBody_Error()
        {
            ///Arrange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );
            var compoundBody = new CompoundBody();

            //Assert
            Assert.True( compoundBody.AddChildBody( cone ) );
            Assert.False( compoundBody.AddChildBody( compoundBody ) );
        }

        [Fact]
        public void AddChildBody_AddThisParentBody_Error()
        {
            ///Arrange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var compoundBody1 = new CompoundBody();
            var cone = new Cone( baseRadius, height, density );
            var compoundBody = new CompoundBody( compoundBody1 );
            compoundBody1.AddChildBody( compoundBody );

            //Assert
            Assert.True( compoundBody.AddChildBody( cone ) );
            Assert.False( compoundBody.AddChildBody( compoundBody ) );
            Assert.False( compoundBody.AddChildBody( compoundBody1 ) );
        }
    }
}