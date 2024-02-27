using System;
using System.Collections.Generic;

namespace SearchTransportApi.Models.DataAccessModels;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
