namespace UniqueWordCounter.Models
{
    internal class Word : IComparable<Word>, IEquatable<Word>
    {
        public int Id { get; }
        public string Value { get; }
        public int Count { get; set; }

        public Word(int id, string value, int count)
        {
            Id = id;
            Value = value;
            Count = count;
        }

        public Word(Word word)
        {
            if (word == null)
            {
                Id = 0;
                Value = string.Empty;
                Count = 0;
            }
            else
            {
                Id = word.Id;
                Value = word.Value;
                Count = word.Count;
            }
        }

        public Word() : this(null!) { }

        public int CompareTo(Word? word)
        {
            if (word != null) return Id.CompareTo(word.Id);
            else return 1;
        }

        public bool Equals(Word? other)
        {
            return other != null ? Value.Equals(other.Value) : false;
        }

        public override string ToString()
        {
            return $"{Id} {Value} {Count}";
        }

    }
}
