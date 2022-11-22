using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public class ViewMapService : Service
    {
        public ViewMapService(): base()
        {
            commands.Add(new AddPOICommand());
            commands.Add(new ReplacePOICommand());
            commands.Add(new SearchPOICommand());
            commands.Add(new RemovePOICommand());
            commands.Add(new ChooseMapCommand());
        }
    }
}
