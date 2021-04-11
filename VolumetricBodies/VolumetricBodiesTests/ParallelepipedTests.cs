using System;
using VolumetricBodies.Bodies;
using Xunit;

namespace VolumetricBodiesTests
{
    public class ParallelepipedTests
    {
        [Fact]
        public void CountParallelepipedVolume_CountVolumeWihZeroParams_Error()
        {
            //Arange
            var height = 0;
            var widht = 10;
            var dept = 10;
            var density = 10;

            //Act
            var parallelepiped = new Parallelepiped( height, widht, dept, density );

            //Assert
            Assert.True( parallelepiped.GetHeight() < 0 );
            Assert.True( parallelepiped.GetWidth() < 0 );
            Assert.True( parallelepiped.GetDept() < 0 );
        }

        [Fact]
        public void CountVolume_CountParallelepipedVolume_GetParallelepiped()
        {
            //Arange
            var height = 10;
            var widht = 10;
            var dept = 10;
            var density = 1;

            //Act
            var parallelepiped = new Parallelepiped( height, widht, dept, density );

            //Assert
            Assert.True( Math.Truncate( parallelepiped.GetVolume() ) == 1000 );
            Assert.True( Math.Truncate( parallelepiped.GetMass() ) == 1000 );
        }
    }
}
