using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Commands
{
    public class AddPOICommand : Command
    {
        public override string Name => "AddPOI";
        private readonly ViewMapViewModel ViewModel;
        public AddPOICommand(ViewMapViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute()
        {
            if (ViewModel.SelectedMap is not null && ViewModel.SelectedPOI is not null)
            {
                Data.AddPOI(ViewModel.SelectedMap, ViewModel.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}