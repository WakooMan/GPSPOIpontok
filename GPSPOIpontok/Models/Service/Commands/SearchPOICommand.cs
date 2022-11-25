using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class SearchPOICommand : Command
    {
        public override string Name => "SearchPOI";
        private readonly ViewMapViewModel ViewModel;
        public SearchPOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            if (ViewModel.SelectedMap is not null)
            {
                ViewModel.POISearchResult = Data.SearchPOI(ViewModel.SelectedMap, ViewModel.SearchInputText);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}