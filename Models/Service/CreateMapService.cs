using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public class CreateMapService : Service
    {
        private readonly Func<Map> GetMap;
        public CreateMapService(Func<Map> getMap) : base()
        {
            GetMap = getMap;
            commands.Add(new CreateMapCommand(GetMap));
        }
    }
}
