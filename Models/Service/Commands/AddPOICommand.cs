using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class AddPOICommand : ICommand
    {
        public string Name => "AddPOI";
        private readonly ViewMapViewModel ViewModel;
        public AddPOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null)
            {
                DataStore.Instance.AddPOI(ViewModel.SelectedMap, ViewModel.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}