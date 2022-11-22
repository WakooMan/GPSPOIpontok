using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class CreateMapCommand : ICommand
    {
        private readonly Func<Map> GetMap;
        public string Name => "CreateMap";

        public CreateMapCommand(Func<Map> getMap)
        {
            GetMap = getMap;
        }

        public void Execute()
        {
            DataStore.Instance.AddMap(GetMap());
        }
    }
}