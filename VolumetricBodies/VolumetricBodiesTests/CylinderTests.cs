using System;
using VolumetricBodies.Bodies;
using Xunit;

namespace VolumetricBodiesTests
{
    public class CylinderTests
    {
        [Fact]
        public void CountVolume_CountCylinderVolumeWihZeroParams_Error()
        {
            //Arange
            var baseRadius = 0;
            var height = 10;
            var density = 10;

            //Act
            var cylinder = new Cylinder( baseRadius, height, density );

            //Assert
            Assert.True( cylinder.GetBaseRadius() < 0 );
            Assert.True( cylinder.GetHeight() < 0 );
        }

        [Fact]
        public void CountVolume_CountCylinderVolume_GetCylinder()
        {
            //Arange
            var baseRadius = 10;
            var height = 10;
            var density = 1;

            //Act
            var cylinder = new Cylinder( baseRadius, height, density );

            //Assert
            Assert.True( Math.Truncate( cylinder.GetVolume() ) == 3141 );
            Assert.True( Math.Truncate( cylinder.GetMass() ) == 3141 );
        }
    }
}
