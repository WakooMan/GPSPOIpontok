using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public class CreateMapService : Domain.Service
    {
        public CreateMapService(CreateMapViewModel ViewModel) : base()
        {
            commands.Add(new CreateMapCommand(ViewModel));
        }
    }
}
