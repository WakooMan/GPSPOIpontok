using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Home
{
    public class ChooseMapCommand : Command
    {
        public override string Name => "ChooseMap";
        public ChooseMapCommand()
        {
        }

        public override void Execute()
        {
            if (HomeData.Instance.SelectedIndex is not null)
            {
                HomeData.Instance.SelectedMap = Data.GetMap((int)HomeData.Instance.SelectedIndex);
            }
        }
    }
}