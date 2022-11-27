using GPSPOIpontok.Domain;
namespace GPSPOIpontok.Models.Service.Commands
{
    public class ChooseMapCommand : Command
    {
        public override string Name => "ChooseMap";
        private readonly HomeViewModel ViewModel;
        public ChooseMapCommand(HomeViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            if (ViewModel.SelectedIndex is not null)
            {
                ViewModel.SelectedMap = Data.GetMap((int)ViewModel.SelectedIndex);
            }
        }
    }
}