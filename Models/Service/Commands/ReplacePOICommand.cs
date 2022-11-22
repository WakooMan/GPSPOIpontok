using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class ReplacePOICommand : ICommand
    {
        public string Name => "ReplacePOI";
        private readonly ViewMapViewModel ViewModel;
        public ReplacePOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null && ViewModel.NewPOI is not null)
            {
                DataStore.Instance.ReplacePOI(ViewModel.SelectedMap, ViewModel.SelectedPOI, ViewModel.NewPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}