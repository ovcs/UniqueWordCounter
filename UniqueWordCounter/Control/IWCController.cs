namespace UniqueWordCounter.Control
{
    internal interface IWCController
    {
        public void Calc();
        public void Execute();
        public bool Quit();
        public void SaveResultAs(string path, string fileFormat);
        public void LoadFile(string path);
    }
}
