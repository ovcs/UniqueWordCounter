namespace UniqueWordCounter.IO
{
    internal interface ILoader
    {
        public void Load(string path, IDeserializator format);
        public IDeserializator GetDeserializator(string format);
    }
}
