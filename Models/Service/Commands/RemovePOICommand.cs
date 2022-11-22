using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class RemovePOICommand : ICommand
    {
        public string Name => "RemovePOI";

        public RemovePOICommand()
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}