using System.Collections;
using System.Collections.Generic;

namespace MyListLib
{
    public class MyList<T> : IEnumerable<T>
    {
        private ListElement<T> _firstElement;
        private ListElement<T> _lastElement;
        private int _count;

        public MyList()
        {
            _count = 0;
        }

        //ошибки с пустым списком, lastEl
        public MyList( MyList<T> list )
        {
            _firstElement = new ListElement<T>( list[ 0 ].GetData() );
            var curr = _firstElement;
            for( int i = 0; i < list._count; i++ )
            {
                if( i != 0 )
                {
                    var listEl = new ListElement<T>( list[ i ].GetData() );
                    curr.SetNext( listEl );
                    listEl.SetPrev( curr );
                    curr = curr.GetNext();
                }
            }

            _count = list.GetCount();
        }

        public MyList( T data )
        {
            var listItem = new ListElement<T>( data );
            _firstElement = listItem;
            _lastElement = listItem;
            _count = 1;
        }

        //i > 0 тест написать 
        public ListElement<T> this[ int i ]
        {
            get
            {
                if( _count >= i || i < 0 )
                {
                    var current = _firstElement;
                    var counter = 0;
                    while( counter != i )
                    {
                        current = current.GetNext();
                        counter++;
                    }

                    return current;
                }
                else
                {
                    throw new System.IndexOutOfRangeException();
                }
            }
        }

        //insert after и сделать insert before
        // А если элемент чужого списка?
        public void AddInCenter( ListElement<T> element, T data )
        {
            if( _firstElement == null )
            {
                AddInHead( data );
            }
            else if( element == _lastElement )
            {
                Add( data );
            }
            else
            {
                var listItem = new ListElement<T>( data );

                var next = element.GetNext();
                element.SetNext( listItem );
                next.SetPrev( listItem );
                listItem.SetPrev( element );
                listItem.SetNext( next );
                _count++;
            }
        }

        public void Add( T data )
        {
            ListElement<T> listItem;
            if( _lastElement != null )
            {
                listItem = new ListElement<T>( data );
                _lastElement.SetNext( listItem );
                listItem.SetPrev( _lastElement );
                _lastElement = listItem;
                _count++;
            }
            else
            {
                listItem = new ListElement<T>( data );
                _firstElement = listItem;
                _lastElement = listItem;
                _count = 1;
            }
        }

        public void AddInHead( T data )
        {
            ListElement<T> listItem;
            if( _firstElement != null )
            {
                listItem = new ListElement<T>( data );

                _firstElement.SetPrev( listItem );
                listItem.SetNext( _firstElement );
                _firstElement = listItem;
                _count++;
            }
            else
            {
                listItem = new ListElement<T>( data );
                _firstElement.SetPrev( listItem );
                listItem.SetNext( _firstElement );
                _firstElement = listItem;
                _count = 0;
            }
        }

        public void Delete( ListElement<T> element )
        {
            // Вспомогательные методы Delete выполняют лишь часть работы (не изменяют _count).

            if( _count == 0 )
            {
                return;
            }
            else
            {
                _count--;
            }
            if( element == _firstElement )
            {
                DeleteFromHead( element );
            }
            else if( element == _lastElement )
            {
                DeleteFromTail( element );
            }
            else
            {
                DeleteFromCenter( element );
            }
        }

        public int GetCount()
        {
            return _count;
        }

        public IEnumerable<ListElement<T>> GetStdEnumerator()
        {
            var current = _firstElement;
            while( current != null )
            {
                yield return current;
                current = current.GetNext();
            }
        }

        public IEnumerable<ListElement<T>> GetReverseEnumerator()
        {
            var current = _lastElement;
            while( current != null )
            {
                yield return current;
                current = current.GetPrev();
            }
        }

        private void DeleteFromCenter( ListElement<T> element )
        {
            if( element.GetPrev() != null && element.GetNext() != null )
            {
                var prev = element.GetPrev();
                var next = element.GetNext();
                prev.SetNext( next );
                next.SetPrev( prev );
            }
        }

        private void DeleteFromHead( ListElement<T> element )
        {
            if( element == _firstElement )
            {
                _firstElement.GetNext().SetPrev( null );
                _firstElement = _firstElement.GetNext();
            }
        }

        private void DeleteFromTail( ListElement<T> element )
        {
            if( element == _lastElement )
            {
                _lastElement.GetPrev().SetNext( null );
                _lastElement = _lastElement.GetPrev();
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ( IEnumerator<T> ) GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            var current = _firstElement;
            while( current != null )
            {
                yield return current;
                current = current.GetNext();
            };
        }
    }
}