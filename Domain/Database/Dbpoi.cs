using System;
using System.Collections.Generic;

namespace Domain.Database;

public partial class Dbpoi
{
    public int Poiid { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? Category { get; set; }

    public byte[]? Image { get; set; }

    public int MapId { get; set; }

    public virtual Dbmap Map { get; set; } = null!;
}
