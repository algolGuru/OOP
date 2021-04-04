using car;
using Xunit;

namespace CarTests
{
    public class CarTest
    {
        [Fact]
        public void EngineOn_EngineIsOff_EngineIsOn()
        {
            //Arrange
            Car car = new Car();
            var engineState = car.GetStateOfEngine();

            //Act
            car.TurnOnEngine();
            var newEngineState = car.GetStateOfEngine();

            //Assert
            Assert.NotEqual( engineState, newEngineState );
        }

        [Fact]
        public void EngineOff_EngineIsOn_EngineIsOff()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            var engineState = car.GetStateOfEngine();

            //Act
            car.TurnOffEngine();
            var newEngineState = car.GetStateOfEngine();

            //Assert
            Assert.NotEqual( engineState, newEngineState );
        }

        [Fact]
        public void EngineOff_EngineIsOnAndSpeedNotNull_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            var engineState = car.GetStateOfEngine();
            car.SetGear( 1 );
            car.SetSpeed( 25 );
            car.SetGear( 0 );

            //Act
            car.TurnOffEngine();
            var newEngineState = car.GetStateOfEngine();

            //Assert
            Assert.Equal( engineState, newEngineState );
        }


        [Fact]
        public void SetSpeed_FirstGearGetSpeed20_CarWillGetSpeed20()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            var speed = car.GetSpeedOfCar();

            //Act
            car.SetSpeed( 20 );
            var newSpeed = car.GetSpeedOfCar();

            //Assert
            Assert.Equal( 0, speed );
            Assert.Equal( 20, newSpeed );
        }

        [Fact]
        public void SetSpeed_FirstGearGetSpeed50_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );

            //Act
            car.SetSpeed( 50 );
            var newSpeed = car.GetSpeedOfCar();

            //Assert
            Assert.Equal( 0, newSpeed );
        }

        [Fact]
        public void SetSpeed_ZeroGearSpeed10TryToGetMoreSpeed_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 10 );
            car.SetGear( 0 );

            //Act
            car.SetSpeed( 20 );
            var newSpeed = car.GetSpeedOfCar();

            //Assert
            Assert.NotEqual( 20, newSpeed );
        }

        [Fact]
        public void SetSpeed_FiftGearGetSpeed150_CarGetSped150()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 30 );
            car.SetGear( 3 );
            car.SetSpeed( 50 );
            car.SetGear( 5 );

            //Act
            car.SetSpeed( 150 );
            var speed = car.GetSpeedOfCar();

            //Assert
            Assert.Equal( 150, speed );
        }

        [Fact]
        public void SetSpeed_FiftGearGetSpeed151_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 30 );
            car.SetGear( 3 );
            car.SetSpeed( 50 );
            car.SetGear( 5 );

            //Act
            car.SetSpeed( 151 );
            var speed = car.GetSpeedOfCar();

            //Assert
            Assert.NotEqual( 151, speed );
        }

        [Fact]
        public void SetGear_FiftGearSpeed150GetZeroGear_CarGetZeroGear()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 30 );
            car.SetGear( 3 );
            car.SetSpeed( 50 );
            car.SetGear( 5 );
            car.SetSpeed( 150 );

            //Act
            car.SetGear( 0 );
            var gear = car.GetGearOfCar();

            //Assert
            Assert.Equal( 0, gear );
        }

        [Fact]
        public void SetGear_FiftGearSpeed150GetFourGear_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 30 );
            car.SetGear( 3 );
            car.SetSpeed( 50 );
            car.SetGear( 5 );
            car.SetSpeed( 150 );

            //Act
            car.SetGear( 4 );
            var gear = car.GetGearOfCar();

            //Assert
            Assert.NotEqual( 4, gear );
        }

        [Fact]
        public void SetGear_ZeroGearCarHasSpeed5TryToGetReverseGear_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( 1 );
            car.SetSpeed( 5 );
            car.SetGear( 0 );

            //Act
            car.SetGear( -1 );
            var gear = car.GetGearOfCar();

            //Assert
            Assert.NotEqual( -1, gear );
        }

        [Fact]
        public void SetGear_CarHaveSpeed5AndReverseGearTryToGet1Gear_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( -1 );
            car.SetSpeed( 5 );
            car.SetGear( 0 );

            //Act
            car.SetGear( 1 );
            var gear = car.GetGearOfCar();

            //Assert
            Assert.NotEqual( 1, gear );
        }

        [Fact]
        public void SetGear_CarHaveSpeed5AndGoBackOnZeroGearTryToGetReverseGear_Error()
        {
            //Arrange
            Car car = new Car();
            car.TurnOnEngine();
            car.SetGear( -1 );
            car.SetSpeed( 5 );
            car.SetGear( 0 );

            //Act
            car.SetGear( -1 );
            var gear = car.GetGearOfCar();

            //Assert
            Assert.NotEqual( -1, gear );
        }
    }
}
