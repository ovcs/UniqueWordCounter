namespace UniqueWordCounter.Models.Repo
{
    internal class HashWordRep : IWordRepository
    {
        readonly Dictionary<string, Word> wordsCacheTable;

        public HashWordRep(Dictionary<string, Word> wordsCacheTable)
        {
            this.wordsCacheTable = wordsCacheTable;
        }

        public HashWordRep() : this(new())
        {
        }

        public int Count { get { return wordsCacheTable.Count; } }

        public void Create(Word word, out Word newWord)
        {
            if (!string.IsNullOrEmpty(word.Value) && !wordsCacheTable.ContainsKey(word.Value))
            {
                wordsCacheTable.Add(word.Value, word);

                // We create new word in input method
                newWord = word;
            }
            else
            {
                newWord = new();
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

        public void Update(Word word, Word updatedWord)
        {
            if ((word != null && updatedWord != null)
                && wordsCacheTable.ContainsKey(word.Value)
                && !word.Equals(updatedWord))
            {
                wordsCacheTable[word.Value] = new(updatedWord);
            }
        }
    }
}
