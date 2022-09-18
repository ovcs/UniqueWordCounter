using UniqueWordCounter.Models;
using UniqueWordCounter.Models.Repo;

namespace UniqueWordCounter.Service
{
    internal class Adder : IService
    {
        Queue<string> qfindstr;
        Queue<Word> qwords;
        IWordRepoManager repMng;

        public Adder(Queue<string> qfindstr, Queue<Word> qwords, IWordRepoManager repMng)
        {
            this.qfindstr = qfindstr;
            this.qwords = qwords;
            this.repMng = repMng;
        }

        public void Run()
        {
            while (qfindstr.Count != 0)
            {
                qwords.Enqueue(AddIfNotExist(qfindstr.Dequeue()));
            }
        }

        private Word AddIfNotExist(string str)
        {
            return repMng.GetWordBy(str);
        }
    }
}
