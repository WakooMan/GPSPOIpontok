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
            DataStore.Instance.AddMap(new Map(ViewModel.MapName,ViewModel.Direction,ViewModel.Ratio,ViewModel.MinCoordinate, ViewModel.MaxCoordinate));
        }
    }
}