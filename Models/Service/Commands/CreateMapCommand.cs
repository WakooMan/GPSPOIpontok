using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class CreateMapCommand : ICommand
    {
        private readonly CreateMapViewModel ViewModel;
        public string Name => "CreateMap";

        public CreateMapCommand(CreateMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            MemoryStream stream = new MemoryStream();
            ViewModel.Image.CopyTo(stream);
            DataStore.Instance.AddMap(new Map(ViewModel.MapName,ViewModel.Direction,ViewModel.Ratio,ViewModel.MinCoordinate, ViewModel.MaxCoordinate,stream.ToArray()));
        }
    }
}