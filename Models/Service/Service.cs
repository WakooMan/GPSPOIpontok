using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public abstract class Service : IService
    {
        protected List<ICommand> commands;
        protected Service()
        {
            commands = new List<ICommand>();
        }
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
