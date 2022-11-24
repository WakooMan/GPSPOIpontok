using System;
using System.Collections.Generic;

namespace GPSPOIpontok.Models;

public partial class Dbpoi
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? Category { get; set; }

    public byte[]? Image { get; set; }
}
