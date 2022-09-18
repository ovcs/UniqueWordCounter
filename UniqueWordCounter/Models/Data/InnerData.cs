namespace UniqueWordCounter.Models.Data
{
    internal class InnerData : IHandlerData
    {
        List<string> strBuffer;

        public Queue<string> queueData { get => new(strBuffer); }

        public InnerData()
        {
        }

        public void Take(object? obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj.GetType() == typeof(List<string>))
            {
                strBuffer = (List<string>) obj;
            }
            else if (obj.GetType() == typeof(string))
            {
                List<string> strings = new() { (string)obj };
                strBuffer = strings;
            }
            else
            {
                throw new InvalidCastException($"Invalid Load objects {nameof(obj)}");
            }
        }
    }
}
