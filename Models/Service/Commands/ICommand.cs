using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace GPSPOIpontok.Models.Service.Commands
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();

    }
}
