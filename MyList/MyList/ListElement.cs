namespace MyList
{
    public class ListElement<T>
    {
        private ListElement<T> _previus;
        private int _index;
        private T _data;
        private ListElement<T> _next;

        public ListElement( T data, int index )
        {
            _data = data;
            _index = index;
        }

        public T GetData()
        {
            return _data;
        }

        public int GetIndex()
        {
            return _index;
        }

        public void IncIndex()
        {
            _index++;
        }

        public void DecIndex()
        {
            _index--;
        }

        public ListElement<T> GetNext()
        {
            return _next;
        }

        public ListElement<T> GetPrev()
        {
            return _previus;
        }

        public void SetNext( ListElement<T> element )
        {
            _next = element;
        }

        public void SetPrev( ListElement<T> element )
        {
            _previus = element;
        }
        
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
