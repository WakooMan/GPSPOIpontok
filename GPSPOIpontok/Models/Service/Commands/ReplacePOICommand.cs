using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class ReplacePOICommand : Command
    {
        public override string Name => "ReplacePOI";
        private readonly ViewMapViewModel ViewModel;
        public ReplacePOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null && ViewModel.NewPOI is not null)
            {
                Data.ReplacePOI(ViewModel.SelectedMap, ViewModel.SelectedPOI, ViewModel.NewPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}