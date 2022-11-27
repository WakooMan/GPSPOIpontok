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
            Data.AddMap(new Map(ViewModel.MapName,(Direction)ViewModel.Direction,new Ratio((int)ViewModel.Lesser,(int)ViewModel.Greater),new Coordinate((double)ViewModel.MinCoordinateLatitude, (double)ViewModel.MinCoordinateLatitude), new Coordinate((double)ViewModel.MaxCoordinateLatitude, (double)ViewModel.MaxCoordinateLatitude), stream.ToArray()));
        }
    }
}