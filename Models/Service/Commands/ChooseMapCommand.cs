using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class ChooseMapCommand : ICommand
    {
        public string Name => "ChooseMap";

        public ChooseMapCommand()
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}