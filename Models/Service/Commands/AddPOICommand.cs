using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class AddPOICommand : ICommand
    {
        public string Name => "AddPOI";

        public AddPOICommand()
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}