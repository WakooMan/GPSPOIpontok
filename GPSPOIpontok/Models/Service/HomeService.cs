using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GPSPOIpontok.Models.Service
{
    public class HomeService: Domain.Service
    {
        public IReadOnlyList<Map> GetMaps() => Data.Maps;
        public HomeService(HomeViewModel ViewModel) 
        {
            commands.Add(new ChooseMapCommand(ViewModel));
        }
    }
}
