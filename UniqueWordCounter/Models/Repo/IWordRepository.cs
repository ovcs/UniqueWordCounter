namespace UniqueWordCounter.Models.Repo
{
    internal interface IWordRepository
    {
        public int Count { get; }
        public void Create(Word create, out Word nWord);
        public void Delete(Word word);
        public List<Word> GetAll();
        public bool TryRead(string value, out Word word);
        public void Update(Word word, Word updatedWord);
    }
}
