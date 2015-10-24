namespace songbook
{
    class Song
    {
        public readonly string Name;

        private string _text;
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    _text = null;
                }
                return _text;
            }
        }

        public Song(string name)
        {
            Name = name;
        }
    }
}
