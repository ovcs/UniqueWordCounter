namespace UniqueWordCounter.Models.Repo
{
    internal class WRepManager : IWordRepoManager
    {
        protected const int START_COUNT = 1;
        IWordRepository wr;

        public WRepManager(IWordRepository wr)
        {
            this.wr = wr;
        }

        public WRepManager() : this(new HashWordRep())
        {
        }

        public Word CreateAndGetWord(string value)
        {
            wr.Create(new Word(wr.Count + 1, value, START_COUNT), out Word word);
            return word;
        }

        public Word GetWordBy(string str)
        {
            return wr.TryRead(str, out Word word) ? word : CreateAndGetWord(str);
        }

        public int MostCommon()
        {
            return wr.GetAll().Count != 0 ?
                                            wr.GetAll().OrderByDescending(e => e.Count).First().Count
                                            : 0;
        }

        public int CountWordsAll()
        {
            return wr.GetAll().Count;
        }

        public void IncreaseCount(Word word)
        {
            word.Count++;
        }

        public List<string> Query(string options)
        {
            return options switch
            {
                "desc value count" => wr.GetAll()
                                        .OrderByDescending(e => e.Count)
                                        .Select(e => String.Format("{0} {1}", e.Value, e.Count))
                                        .ToList(),
                _ => wr.GetAll().Select(e => e.ToString()).ToList(),
            };
        }
    }
}
