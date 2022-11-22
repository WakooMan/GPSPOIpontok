using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public class ViewMapService : Service
    {
        
        public ViewMapService(ViewMapViewModel ViewModel) : base()
        {
            commands.Add(new ChooseMapCommand(ViewModel));
            commands.Add(new AddPOICommand(ViewModel));
            commands.Add(new ReplacePOICommand(ViewModel));
            commands.Add(new SearchPOICommand(ViewModel));
            commands.Add(new RemovePOICommand(ViewModel));
        }
    }
}
