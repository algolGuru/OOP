using System;
using VolumetricBodies.Bodies;
using Xunit;

namespace VolumetricBodiesTests
{
    public class ConeTests
    {
        [Fact]
        public void CountVolume_CountConeVolumeWihZeroParams_Error()
        {
            //Arange
            var baseRadius = 0;
            var height = 10;
            var density = 10;

            //Act
            var cone = new Cone( baseRadius, height, density );

            //Assert
            Assert.True( cone.GetBaseRadius() < 0 );
            Assert.True( cone.GetHeight() < 0 );
        }

        [Fact]
        public void CountVolume_CountConeVolume_GetCone()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 10;

            //Act
            var cone = new Cone( baseRadius, height, density );

            //Assert
            Assert.True( Math.Truncate( cone.GetVolume() ) == 1047 );
            Assert.True( Math.Truncate( cone.GetMass() ) == 10471 );
        }
    }
}
