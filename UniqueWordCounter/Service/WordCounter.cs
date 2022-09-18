using UniqueWordCounter.Models;
using UniqueWordCounter.Models.Data;
using UniqueWordCounter.Models.Repo;

namespace UniqueWordCounter.Service
{
    internal class WordCounter : IService
    {
        string FIND_PATTERN = @"([^\W_]+[^\s.,?!:;""^&*><\|]*)";
        bool running = false;

        InnerData texts;
        Queue<string> qstrings;
        Queue<Word> qwords;
        IWordRepoManager repManager;

        public WordCounter(InnerData texts,
                           Queue<string> qstrings,
                           Queue<Word> qwords,
                           IWordRepoManager repManager)
        {
            this.texts = texts;
            this.qstrings = qstrings;
            this.qwords = qwords;
            this.repManager = repManager;
        }

        public WordCounter(InnerData data, IWordRepoManager repManager)
            : this(data, new(), new(), repManager)
        {
        }

        public void Run()
        {
            running = true;
            TextHandler textHandler = new(texts.queueData, qstrings, FIND_PATTERN);
            Adder adder = new(qstrings, qwords, repManager);
            Counter counter = new(qwords, repManager);

            textHandler.Run();
            adder.Run();
            counter.Run();
            running = false;
        }
    }
}
