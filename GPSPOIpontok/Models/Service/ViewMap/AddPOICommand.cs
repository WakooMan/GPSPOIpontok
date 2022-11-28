using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class AddPOICommand : Command
    {
        public override string Name => "AddPOI";
        public AddPOICommand()
        {
        }

        public override void Execute()
        {
            if (ViewMapData.Instance.SelectedMap is not null && ViewMapData.Instance.SelectedPOI is not null)
            {
                Data.AddPOI(ViewMapData.Instance.SelectedMap, ViewMapData.Instance.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}