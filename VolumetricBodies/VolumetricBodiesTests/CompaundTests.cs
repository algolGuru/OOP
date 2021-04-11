using System;
using System.Collections.Generic;
using System.Text;
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
            var compaundBody = new CompoundBody( new List<Body> { cone } );

            //Assert
            Assert.True( compaundBody.GetBodies().Count == 0 );
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
            var compaundBody = new CompoundBody( new List<Body> { cone } );

            //Assert
            Assert.True( compaundBody.GetBodies().Count == 1 );
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
            var compaundBody = new CompoundBody( new List<Body> { cone, cylinder } );

            //Assert
            Assert.True( compaundBody.GetBodies().Count == 2 );
        }

        [Fact]
        public void CountBodyParams_CountParamsForValiChildBodies_ReturnBodyParams()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;
            var cone = new Cone( baseRadius, height, density );
            var cylinder = new Cylinder( baseRadius, height, density );

            //Act
            var compaundBody = new CompoundBody( new List<Body> { cone, cylinder } );

            //Assert
            Assert.True( compaundBody.GetBodies().Count == 2 );
            Assert.True( Math.Truncate( compaundBody.GetMass() ) == 41887 );
            Assert.True( Math.Truncate( compaundBody.GetVolume() )== 4188 );
            Assert.True( Math.Truncate( compaundBody.GetDensity() ) == 10 );
            
        }
    }
}
