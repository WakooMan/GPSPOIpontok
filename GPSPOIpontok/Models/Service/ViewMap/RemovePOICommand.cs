using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class RemovePOICommand : Command
    {
        public override string Name => "RemovePOI";
        public RemovePOICommand()
        {
        }

        public override void Execute()
        {
            if (ViewMapData.Instance.SelectedMap is not null && ViewMapData.Instance.SelectedPOI is not null)
            {
                Data.RemovePOI(ViewMapData.Instance.SelectedMap, ViewMapData.Instance.SelectedPOI);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}