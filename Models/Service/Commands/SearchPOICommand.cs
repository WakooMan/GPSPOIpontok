using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class SearchPOICommand : ICommand
    {
        public string Name => "SearchPOI";

        public SearchPOICommand()
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}