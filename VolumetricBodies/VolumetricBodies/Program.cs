using System;
using System.Collections.Generic;
using VolumetricBodies.Bodies;

namespace VolumetricBodies
{
    class Program
    {
        static void Main( string[] args )
        {
            var listOfInputBodies = new List<Body>();
            var command = 0;

            while( command != 10 )
            {
                Console.WriteLine(
                    "Выбирите команду \n" +
                    "Создать сферу: 1 \n" +
                    "Создать параллелепипед: 2 \n" +
                    "Создать конус: 3 \n" +
                    "Создать цилиндр: 4 \n" +
                    "Создать составное тело: 5 \n" +
                    "Вывести информацию о телах: 6 \n" +
                    "Завершить: 10" );

                command = ParseToInt();
                if( command == 10 )
                    break;

                var isOk = false;

                switch( command )
                {
                    case 1:
                    {
                        isOk = AddSphere( listOfInputBodies );
                        break;
                    }
                    case 2:
                    {
                        isOk = AddParallelepiped( listOfInputBodies );
                        break;
                    }
                    case 3:
                    {
                        isOk = AddCone( listOfInputBodies );
                        break;
                    }
                    case 4:
                    {
                        isOk = AddCylinder( listOfInputBodies );
                        break;
                    }
                    case 5:
                    {
                        isOk = AddCompoundBody( listOfInputBodies, false );
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine();
                        Console.WriteLine( "Список тел:" );
                        isOk = true;
                        PrintInfo( listOfInputBodies );
                        break;
                    }
                }

                if( isOk )
                {
                    Console.WriteLine( "Успешно!" );
                }
                else
                {
                    Console.WriteLine( "Ошибка" );
                }

                Console.WriteLine();
            }


            Console.WriteLine();
        }

        //Compound
        public static bool AddCompoundBody( List<Body> bodies, bool parentIsCompaund )
        {
            var listOfInputBodies = new List<Body>();
            var command = 0;
            var isOk = false;

            while( command != 10 )
            {

                Console.WriteLine();
                Console.WriteLine(
                    "Выбирите тело, которое хотите добавить \n" +
                    "Добавить сферу: 1 \n" +
                    "Добавить параллелепипед: 2 \n" +
                    "Добавить конус: 3 \n" +
                    "Добавить цилиндр: 4 \n" +
                    "Добавить составное тело: 5 \n" +
                    "Информация о составном теле: 6 \n" +
                    "Завершить: 10" );

                command = ParseToInt();
                if( command == 10 )
                    break;
                //Вынести в функцию
                switch( command )
                {
                    case 1:
                    {
                        isOk = AddSphere( listOfInputBodies );
                        break;
                    }
                    case 2:
                    {
                        isOk = AddParallelepiped( listOfInputBodies );
                        break;
                    }
                    case 3:
                    {
                        isOk = AddCone( listOfInputBodies );
                        break;
                    }
                    case 4:
                    {
                        isOk = AddCylinder( listOfInputBodies );
                        break;
                    }
                    case 5:
                    {
                        isOk = AddCompoundBody( listOfInputBodies, true );
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine();
                        Console.WriteLine( "Список тел в составном теле:" );
                        isOk = true;
                        PrintInfo( listOfInputBodies );
                        break;
                    }
                }

                if( listOfInputBodies.Count == 0 )
                {
                    isOk = false;
                }
            }
            if( isOk )
            {
                Console.WriteLine( "Тело добавлено!" );
                Console.WriteLine();
                CompoundBody newCompaundBody;
                if (parentIsCompaund)
                {
                    CompoundBody body = ( CompoundBody ) bodies[ ^1 ];
                    newCompaundBody = new CompoundBody( body );
                }
                else
                {
                    newCompaundBody = new CompoundBody();
                }

                foreach(var inputBody in listOfInputBodies )
                {
                    newCompaundBody.AddChildBody( inputBody );
                }
                bodies.Add( newCompaundBody );
            }
            else
            {
                Console.WriteLine( "Ошибка" );
            }

            return true;
        }

        public static bool AddSphere( List<Body> bodies )
        {
            Console.WriteLine();
            Console.WriteLine( "Введите радиус" );
            double radius = ParseToDouble();
            if( radius == -1 )
                return false;

            Console.WriteLine( "Введите плотность" );
            double density = ParseToDouble();
            if( density == -1 )
                return false;

            if( radius > 0 && density > 0 )
            {
                var sphere = new Sphere( radius, density );
                bodies.Add( sphere );
                return true;
            }

            return false;
        }

        public static bool AddParallelepiped( List<Body> bodies )
        {
            Console.WriteLine();
            Console.WriteLine( "Введите ширину" );
            double width = ParseToDouble();
            if( width == -1 )
                return false;

            Console.WriteLine( "Введите высоту" );
            double height = ParseToDouble();
            if( height == -1 )
                return false;

            Console.WriteLine( "Введите глубину" );
            double depth = ParseToDouble();
            if( depth == -1 )
                return false;

            Console.WriteLine( "Введите плотность" );
            double density = ParseToDouble();
            if( density == -1 )
                return false;

            if( width > 0 && height > 0 && depth > 0 && density > 0 )
            {
                var parallelepiped = new Parallelepiped( width, height, depth, density );
                bodies.Add( parallelepiped );
                return true;
            }

            return false;
        }

        public static bool AddCylinder( List<Body> bodies )
        {
            Console.WriteLine();
            Console.WriteLine( "Введите радиус" );
            double radius = ParseToDouble();
            if( radius == -1 )
                return false;

            Console.WriteLine( "Введите высоту" );
            double height = ParseToDouble();
            if( height == -1 )
                return false;

            Console.WriteLine( "Введите плотность" );
            double density = ParseToDouble();
            if( density == -1 )
                return false;

            if( radius > 0 && height > 0 && density > 0 )
            {
                var cylinder = new Cylinder( radius, height, density );
                bodies.Add( cylinder );
                return true;
            }

            return false;
        }

        public static bool AddCone( List<Body> bodies )
        {
            Console.WriteLine();
            Console.WriteLine( "Введите радиус" );
            double radius = ParseToDouble();
            if( radius == -1 )
                return false;

            Console.WriteLine( "Введите высоту" );
            double height = ParseToDouble();
            if( height == -1 )
                return false;

            Console.WriteLine( "Введите плотность" );
            double density = ParseToDouble();
            if( density == -1 )
                return false;

            if( radius > 0 && height > 0 && density > 0 )
            {
                var cone = new Cone( radius, height, density );
                bodies.Add( cone );
                return true;
            }

            return false;
        }

        public static void PrintInfo( List<Body> bodies )
        {
            if( bodies.Count == 0 )
            {
                Console.WriteLine( "Список тел пуст" );
            }
            else
            {
                foreach( var body in bodies )
                {
                    if( body.GetType() == typeof( CompoundBody ) )
                    {
                        Console.WriteLine( "Составное тело:" );
                    }
                    Console.WriteLine( body.ToString() );
                    Console.WriteLine();
                }
            }
        }

        private static double ParseToDouble()
        {
            double doubleNumber;
            try
            {
                doubleNumber = double.Parse( Console.ReadLine() );
            }
            catch
            {
                doubleNumber = -1;
                Console.WriteLine( "Invalid data" );
            }
            if( doubleNumber == 0 )
            {
                doubleNumber = -1;
            }

            return doubleNumber;
        }


        private static int ParseToInt()
        {
            int number = 0;

            try
            {
                number = int.Parse( Console.ReadLine() );
            }
            catch
            {
                Console.WriteLine( "Invalid data" );
            }

            return number;
        }
    }
}
