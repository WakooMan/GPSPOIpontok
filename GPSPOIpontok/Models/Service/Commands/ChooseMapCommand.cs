using GPSPOIpontok.Domain;
namespace GPSPOIpontok.Models.Service.Commands
{
    public class ChooseMapCommand : Command
    {
        public override string Name => "ChooseMap";
        private readonly ViewMapViewModel ViewModel;
        public ChooseMapCommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            ViewModel.SelectedMap =Data.GetMap(ViewModel.SelectedIndex);
        }
    }
}