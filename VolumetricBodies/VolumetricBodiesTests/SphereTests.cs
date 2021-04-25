using System;
using VolumetricBodies.Bodies;
using Xunit;

namespace VolumetricBodiesTests
{
    public class SphereTests
    {
        [Fact]
        public void CreateSphere_CreateSphereWihZeroParams_Error()
        {
            //Arange
            var radius = 0;
            var density = 10;

            //Act
            var sphere = new Sphere( radius, density );

            //Assert
            Assert.True( sphere.GetRadius() < 0 );
        }

        [Fact]
        public void CreateSphere_CreateSphereWithValidParams_GetSphere()
        {
            //Arange
            var baseRadius = 10;
            var density = 1;

            //Act
            var sphere = new Sphere( baseRadius, density );

            //Assert
            Assert.True( Math.Truncate( sphere.GetVolume() ) == 4188 );
            Assert.True( Math.Truncate( sphere.GetMass() ) == 4188 );
        }
    }
}
