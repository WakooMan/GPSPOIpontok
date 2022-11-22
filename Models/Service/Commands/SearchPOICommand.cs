using GPSPOIpontok.Models.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class SearchPOICommand : ICommand
    {
        public string Name => "SearchPOI";
        private readonly ViewMapViewModel ViewModel;
        public SearchPOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Execute()
        {
            if (ViewModel.SelectedMap is not null)
            {
                ViewModel.POISearchResult = DataStore.Instance.SearchPOI(ViewModel.SelectedMap, ViewModel.SearchInputText);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}