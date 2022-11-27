namespace GPSPOIpontok.Domain
{
    public abstract class Service
    {
        protected List<ICommand> commands;
        protected Service()
        {
            commands = new List<ICommand>();
        }

        protected DataStore Data => DataStore.Instance;

        public void ExecuteCommand(string command)
        {
            ICommand? cmd = commands.FirstOrDefault(c => c.Name == command);
            if (cmd is not null)
            {
                cmd.Execute();
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
        
    }
}
