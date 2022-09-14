namespace UniqueWordCounter.IO
{
    internal interface ISaver
    {
        public void Save(string filename, ISerializator format);
    }
}
