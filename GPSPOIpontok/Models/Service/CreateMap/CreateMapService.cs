namespace GPSPOIpontok.Models.Service.CreateMap
{
    public class CreateMapService : Domain.Service
    {
        public CreateMapService(CreateMapViewModel ViewModel) : base()
        {
            commands.Add(new CreateMapCommand(ViewModel));
        }
    }
}
