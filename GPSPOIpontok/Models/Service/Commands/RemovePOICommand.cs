using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class RemovePOICommand : Command
    {
        public override string Name => "RemovePOI";
        private readonly ViewMapViewModel ViewModel;
        public RemovePOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null)
            {
                Data.RemovePOI(ViewModel.SelectedMap, ViewModel.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}