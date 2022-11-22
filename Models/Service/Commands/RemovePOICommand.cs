using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class RemovePOICommand : ICommand
    {
        public string Name => "RemovePOI";
        private readonly ViewMapViewModel ViewModel;
        public RemovePOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null)
            {
                DataStore.Instance.RemovePOI(ViewModel.SelectedMap, ViewModel.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}