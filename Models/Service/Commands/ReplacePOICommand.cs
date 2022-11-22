using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class ReplacePOICommand : ICommand
    {
        public string Name => "ReplacePOI";

        public ReplacePOICommand()
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}