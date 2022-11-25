namespace GPSPOIpontok.Domain
{
    public abstract class Command: ICommand
    {
        protected DataStore Data => DataStore.Instance;
        public abstract string Name { get; }
        public abstract void Execute();

    }
}
