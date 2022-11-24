using System;
using System.Collections.Generic;

namespace GPSPOIpontok.Models;

public partial class Dbmap
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Lesser { get; set; }

    public int Greater { get; set; }

    public string Direction { get; set; } = null!;

    public double MaxCoordinateLongitude { get; set; }

    public double MaxCoordinateLatitude { get; set; }

    public double MinCoordinateLongitude { get; set; }

    public double MinCoordinateLatitude { get; set; }

    public byte[] Image { get; set; } = null!;
}
