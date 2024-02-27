using System;
using System.Collections.Generic;

namespace SearchTransportApi.Models.DataAccessModels;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string VehicleName { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual Location Location { get; set; } = null!;
}
