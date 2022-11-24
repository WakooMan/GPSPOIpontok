using GPSPOIpontok.Models.Domain;
namespace GPSPOIpontok.Models.Service.Commands
{
    public class ChooseMapCommand : ICommand
    {
        public string Name => "ChooseMap";
        private readonly ViewMapViewModel ViewModel;
        public ChooseMapCommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            ViewModel.SelectedMap =DataStore.Instance.GetMap(ViewModel.SelectedIndex);
        }
    }
}