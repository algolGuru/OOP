namespace car
{
    public enum Direction
    {
        forward,
        back,
        inPlace
    }

    public class Car
    {
        private bool _engineIsRunning;
        private Direction _direction;
        private int _speed;
        private int _gear;

        public Car()
        {
            _engineIsRunning = false;
            _direction = Direction.inPlace;
            _speed = 0;
            _gear = 0;
        }

        public bool GetStateOfEngine()
        {
            return _engineIsRunning;
        }

        public Direction GetDirectionOfCar()
        {
            return _direction;
        }

        public int GetSpeedOfCar()
        {
            return _speed;
        }

        public int GetGearOfCar()
        {
            return _gear;
        }

        public bool TurnOnEngine()
        {
            _engineIsRunning = true;

            return _engineIsRunning;
        }

        public bool TurnOffEngine()
        {
            if( _engineIsRunning == true && _gear == 0 && _direction == Direction.inPlace )
            {
                _engineIsRunning = false;

                return true;
            }

            return false;
        }

        public bool SetGear( int gear )
        {
            if( _gear == gear )
            {
                return true;
            }

            return SwitchGear( gear );
        }

        public bool SetSpeed( int speed )
        {
            if( _gear == -1 && speed <= 20 && speed >= 0 )
            {
                _speed = speed;
                SwitchDirection( speed );
                return true;
            }
            if( _gear == 0 && _speed >= speed )
            {
                _speed = speed;
                SwitchDirection( speed );
                return true;
            }
            if( _gear == 1 && speed >= 0 && speed <= 30 )
            {
                _speed = speed;
                SwitchDirection( speed );
                return true;
            }
            if( _gear == 2 && speed >= 20 && speed <= 50 )
            {
                _speed = speed;
                return true;
            }
            if( _gear == 3 && speed >= 30 && speed <= 60 )
            {
                _speed = speed;
                return true;
            }
            if( _gear == 4 && speed >= 40 && speed <= 90 )
            {
                _speed = speed;
                return true;
            }
            if( _gear == 5 && speed >= 50 && speed <= 150 )
            {
                _speed = speed;
                return true;
            }

            return false;
        }

        private void SwitchDirection( int speed )
        {
            if( speed > 0 && _gear != -1 )
            {
                _direction = Direction.forward;
            }
            if( speed > 0 && _gear == -1 )
            {
                _direction = Direction.back;
            }
            if( speed == 0 )
            {
                _direction = Direction.inPlace;
            }
        }

        private bool SwitchGear( int gear )
        {
            switch( gear )
            {
                case -1:
                {
                    return SetReverseGear();
                }
                case 0:
                {
                    return SetZeroGear();
                }
                case 1:
                {
                    return SetFirstGear();
                }
                case 2:
                {
                    return SetSecondGear();
                }
                case 3:
                {
                    return SetThirdGear();
                }
                case 4:
                {
                    return SetFourthGear();
                }
                case 5:
                {
                    return SetFifthGear();
                }
            }
            return false;
        }

        private bool SetReverseGear()
        {
            if( _speed == 0 && _engineIsRunning == true )
            {
                _gear = -1;
                return true;
            }

            return false;
        }

        private bool SetZeroGear()
        {
            _gear = 0;

            return true;
        }

        private bool SetFirstGear()
        {
            if( _speed <= 30 && _speed >= 0 && _gear != -1 && ( _direction == Direction.inPlace || _direction == Direction.forward ) && _engineIsRunning == true )
            {
                _gear = 1;
                return true;
            }

            return false;
        }

        private bool SetSecondGear()
        {
            if( _speed <= 50 && _speed >= 20 && _direction == Direction.forward && _engineIsRunning == true )
            {
                _gear = 2;
                return true;
            }

            return false;
        }

        private bool SetThirdGear()
        {
            if( _speed <= 60 && _speed >= 30 && _direction == Direction.forward && _engineIsRunning == true )
            {
                _gear = 3;
                return true;
            }

            return false;
        }

        private bool SetFourthGear()
        {
            if( _speed <= 90 && _speed >= 40 && _direction == Direction.forward && _engineIsRunning == true )
            {
                _gear = 4;
                return true;
            }

            return false;
        }

        private bool SetFifthGear()
        {
            if( _speed <= 150 && _speed >= 50 && _direction == Direction.forward && _engineIsRunning == true )
            {
                _gear = 5;
                return true;
            }

            return false;
        }
    }
}
