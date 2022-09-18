using System.Text.RegularExpressions;

namespace UniqueWordCounter.Service
{
    internal class TextHandler : IService
    {
        Queue<string> text;
        Queue<string> words;
        string searchPattern;

        public TextHandler(Queue<string> text, Queue<string> words, string searchPattern)
        {
            this.text = text;
            this.words = words;
            this.searchPattern = searchPattern;
        }

        public void Run()
        {
            while (text.Count != 0)
            {
                Find(text.Dequeue(), searchPattern, RegexOptions.IgnoreCase).ForEach(e => words.Enqueue(e.ToLower()));
            }
        }

        private List<string> Find(string text, string pattern, RegexOptions options)
        {
            var reg = new Regex(pattern, RegexOptions.CultureInvariant);
            return Regex.Matches(text, pattern, options).Select(e => e.ToString()).ToList();
        }
    }
}
