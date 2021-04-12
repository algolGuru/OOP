using System;

namespace car
{
    class Program
    {
        static void Main( string[] args )
        {
            Car car = new Car();
            string command = "";

            Console.WriteLine( "Добро пожаловать в автомобиль" );
            while( command != "Close" )
            {
                Console.WriteLine( "Ожидание команды..." );
                Console.WriteLine( "Close, чтобы закрыть программу" );
                command = Console.ReadLine();

                if( command.Split( ' ' )[ 0 ] == "SetSpeed" )
                {
                    SetSpeed( car, command );
                }
                else if( command.Split( ' ' )[ 0 ] == "SetGear" )
                {
                    SetGear( car, command );
                }
                else if( command == "Info" )
                {
                    Info( car );
                }
                else if( command == "EngineOn" )
                {
                    EngineOn( car );
                }
                else if( command == "EngineOff" )
                {
                    EngineOff( car );
                }
                else
                {
                    Console.WriteLine( "Неизвестная команда" );
                }
            }
        }

        static void EngineOn( Car car )
        {
            car.TurnOnEngine();
            Console.WriteLine( "Мотор заведен!" );
        }

        static void EngineOff( Car car )
        {
            var isOk = car.TurnOffEngine();
            if( isOk == false )
            {
                Console.WriteLine( "Невозможно заглушить мотор!" );
            }
            else
            {
                Console.WriteLine( "Мотор заглушен!" );
            }
        }

        static void Info( Car car )
        {
            string engineState;
            string directionState;
            if( car.GetState() == true )
            {
                engineState = "Мотор заведен";
            }
            else
            {
                engineState = "Мотор загулшен";
            }

            if( car.GetDirection() == Direction.forward )
            {
                directionState = "Автомобиль едет вперед";
            }
            else if( car.GetDirection() == Direction.back )
            {
                directionState = "Автомобиль едет назад";
            }
            else
            {
                directionState = "Автомобиль не двигается";
            }

            Console.WriteLine( $"Состояние автомобиля: \n" +
                $" {engineState},\n" +
                $" {directionState},\n" +
                $" Скорость автомобиля: {car.GetSpeed()},\n" +
                $" Передача : {car.GetGear()} " );
        }

        static void SetSpeed( Car car, string command )
        {
            if( command.Split( ' ' )[ 0 ] == "SetSpeed" )
            {
                var speed = 0;
                bool isOk = true;
                try
                {
                    speed = int.Parse( command.Split( ' ' )[ 1 ] );
                }
                catch
                {
                    isOk = false;
                }

                if( speed >= 0 && speed <= 150 && isOk)
                {
                    isOk = car.SetSpeed( speed );
                } else
                {
                    isOk = false;
                }

                if( isOk == true )
                {
                    Console.WriteLine( "Скорость установлена!" );
                }
                else
                {
                    Console.WriteLine( "Ошибка при изменении скорости!" );
                }
            }
        }

        static void SetGear( Car car, string command )
        {
            var gear = 0;
            var isOk = true;
            try
            {
                gear = int.Parse( command.Split( ' ' )[ 1 ] );
            }
            catch
            {
                isOk = false;
            }

            if( gear >= -1 && gear <= 5 && isOk )
            {
                isOk = car.SetGear( gear );
            }
            else
            {
                isOk = false;
            }

            if( isOk == true )
            {
                Console.WriteLine( "Передача установлена!" );
            }
            else
            {
                Console.WriteLine( "Ошибка при изменении передачи!" );
            }
        }
    }
}