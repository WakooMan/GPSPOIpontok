namespace GPSPOIpontok.Models
{
    public abstract class ViewModelBase
    {
        public Domain.Service? ModelService { get; protected set; } = null;
    }
}
