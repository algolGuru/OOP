using System.Collections;
using System.Collections.Generic;

namespace MyList
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

        public MyList( MyList<T> list )
        {
            _firstElement = list._firstElement;
            _lastElement = list._lastElement;
            _count = list._count;
        }

        public MyList( T data )
        {
            var listItem = new ListElement<T>( data, 0 );
            _firstElement = listItem;
            _lastElement = listItem;
            _count = 1;
        }

        public ListElement<T> this[ int i ]
        {
            get
            {
                if( _count >= i )
                {
                    var current = _firstElement;
                    while( current.GetIndex() != i)
                    {
                        current = current.GetNext();
                    }

                    return current;
                }
                else
                {
                    throw new System.IndexOutOfRangeException();
                }
            }
        }

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
                var listItem = new ListElement<T>( data, element.GetIndex() + 1 );
                var current = element.GetNext();
                while( current != null )
                {
                    current.IncIndex();
                    current = current.GetNext();
                }

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
                listItem = new ListElement<T>( data, _lastElement.GetIndex() + 1 );
                _lastElement.SetNext( listItem );
                listItem.SetPrev( _lastElement );
                _lastElement = listItem;
                _count++;
            }
            else
            {
                listItem = new ListElement<T>( data, 0 );
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
                listItem = new ListElement<T>( data, 0 );
                var current = _firstElement;
                while( current != null )
                {
                    current.IncIndex();
                    current = current.GetNext();
                }

                _firstElement.SetPrev( listItem );
                listItem.SetNext( _firstElement );
                _firstElement = listItem;
                _count++;
            }
            else
            {
                listItem = new ListElement<T>( data, 0 );
                _firstElement.SetPrev( listItem );
                listItem.SetNext( _firstElement );
                _firstElement = listItem;
                _count = 0;
            }
        }

        public void Delete( ListElement<T> element )
        {
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
                var current = element.GetNext();
                while( current != null )
                {
                    current.DecIndex();
                    current = current.GetNext();
                }

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
                var current = element.GetNext();
                while( current != null )
                {
                    current.DecIndex();
                    current = current.GetNext();
                }

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
            return GetEnumerator();
        }
    }
}