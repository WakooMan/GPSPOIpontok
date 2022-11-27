using GPSPOIpontok.Models.Service.Commands;

namespace GPSPOIpontok.Models.Service
{
    public class ViewMapService : Domain.Service
    {
        
        public ViewMapService(ViewMapViewModel ViewModel) : base()
        {
            commands.Add(new AddPOICommand(ViewModel));
            commands.Add(new ReplacePOICommand(ViewModel));
            commands.Add(new SearchPOICommand(ViewModel));
            commands.Add(new RemovePOICommand(ViewModel));
        }
    }
}
