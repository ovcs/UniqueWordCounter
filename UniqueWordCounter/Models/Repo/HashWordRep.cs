namespace UniqueWordCounter.Models.Repo
{
    internal class HashWordRep : IWordRepository
    {
        Dictionary<string, Word> wordsCacheTable;
        public int Count { get { return wordsCacheTable.Count; } }

        public HashWordRep(Dictionary<string, Word> wordsCacheTable)
        {
            this.wordsCacheTable = wordsCacheTable;
        }
        public HashWordRep(List<Word> wordsTable)
        {
            wordsCacheTable = wordsTable.Distinct().ToDictionary(i => i.Value, i => i); ;
        }

        public HashWordRep() : this(new Dictionary<string, Word>())
        {
        }

        public void Create(int id, string value, int count, out Word word)
        {
            if (!string.IsNullOrEmpty(value) && !wordsCacheTable.ContainsKey(value))
            {
                word = new Word(id, value, count);
                wordsCacheTable.Add(value, word);
            }
            else
            {
                word = new();
            }
        }

        public void Delete(Word word)
        {
            if (word != null && wordsCacheTable.ContainsKey(word.Value))
                wordsCacheTable.Remove(word.Value);
        }
        public List<Word> GetAll()
        {
            return new(wordsCacheTable.Values);
        }

        public bool TryRead(string value, out Word word)
        {
            if (wordsCacheTable.ContainsKey(value))
            {
                word = wordsCacheTable[value];
                return true;
            }
            else
            {
                word = new Word();
                return false;
            }
        }

        public void Update(Word word, string value)
        {
            if (word != null
                && String.IsNullOrEmpty(value)
                && wordsCacheTable.ContainsKey(value))
            {
                wordsCacheTable[value] = word!;
            }
        }
    }
}
