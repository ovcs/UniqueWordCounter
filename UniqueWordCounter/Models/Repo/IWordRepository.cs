namespace UniqueWordCounter.Models.Repo
{
    internal interface IWordRepository
    {
        public int Count { get; }
        public void Create(int id, string value, int count, out Word word);
        public void Delete(Word word);
        public List<Word> GetAll();
        public bool TryRead(string value, out Word word);
        public void Update(Word word, string value);
    }
}
