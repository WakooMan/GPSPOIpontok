using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class CreateMapCommand : Command
    {
        private readonly CreateMapViewModel ViewModel;
        public override string Name => "CreateMap";

        public CreateMapCommand(CreateMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            MemoryStream stream = new MemoryStream();
            ViewModel.Image.CopyTo(stream);
            Data.AddMap(new Map(ViewModel.MapName,ViewModel.Direction,ViewModel.Ratio,ViewModel.MinCoordinate, ViewModel.MaxCoordinate,stream.ToArray()));
        }
    }
}