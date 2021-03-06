﻿using MyListLib;
using System;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main( string[] args )
        {
            var l = new List<int>();

            var list = new MyList<int>();
            list.Add( 4 );
            list.Add( 6 );
            list.Add( 2 );
            list.AddInHead( 12 );

            var d = new MyList<int>( list );


            for( int i = 0; i < list.GetCount(); i++ )
            {
                Console.WriteLine( list[ i ].GetData() );
            }

            foreach( var item in list.GetStdEnumerator() )
            {
                if( item.GetData() == 6 )
                {
                    list.InsertAfter( item, 5 );
                }

                Console.WriteLine( item );
            }

            foreach( var item in list.GetReverseEnumerator() )
            {
                if( item.GetData() == 6 )
                {
                    list.Delete( item );
                }

                Console.WriteLine( item );
            }

            var listList = new MyList<MyList<int>>();
            var intsList = new MyList<int>();
            intsList.Add( 1 );
            intsList.Add( 2 );

            listList.Add( intsList );


            Console.WriteLine( list.GetCount() );
        }
    }
}
