namespace MyListLib
{
    public class ListElement<T>
    {
        private ListElement<T> _previus;
        private T _data;
        private ListElement<T> _next;

        public ListElement( T data )
        {
            _data = data;
        }

        public T GetData()
        {
            return _data;
        }

        public ListElement<T> GetNext()
        {
            return _next;
        }

        public ListElement<T> GetPrev()
        {
            return _previus;
        }

        internal void SetNext( ListElement<T> element )
        {
            _next = element;
        }

        internal void SetPrev( ListElement<T> element )
        {
            _previus = element;
        }
    }
}
