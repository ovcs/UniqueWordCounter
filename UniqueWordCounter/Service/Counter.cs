using UniqueWordCounter.Models;
using UniqueWordCounter.Models.Repo;

namespace UniqueWordCounter.Service
{
    internal class Counter : IService
    {
        Queue<Word> qwords;
        IWordRepoManager repMng;

        public Counter(Queue<Word> qwords, IWordRepoManager repMng)
        {
            this.qwords = qwords;
            this.repMng = repMng;
        }

        public void Run()
        {
            while (qwords.Count != 0)
            {
                AppendCount(qwords.Dequeue());
            }
        }

        private void AppendCount(Word word)
        {
            // TODO get without manager
            repMng.IncreaseCount(word);
        }
    }
}
