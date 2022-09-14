namespace UniqueWordCounter.Control
{
    internal interface IWCController
    {
        public void Calc();
        public string GetInputString();
        public bool Quit();
        public void SaveResultAs(string path);
        public void LoadFile(string path);
    }
}
