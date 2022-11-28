using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class ReplacePOICommand : Command
    {
        public override string Name => "ReplacePOI";
        public ReplacePOICommand()
        {
        }

        public override void Execute()
        {
            if (ViewMapData.Instance.SelectedMap is not null && ViewMapData.Instance.SelectedPOI is not null && ViewMapData.Instance.NewPOI is not null)
            {
                Data.ReplacePOI(ViewMapData.Instance.SelectedMap, ViewMapData.Instance.SelectedPOI, ViewMapData.Instance.NewPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}