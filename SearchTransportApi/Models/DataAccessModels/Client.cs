using System;
using System.Collections.Generic;

namespace SearchTransportApi.Models.DataAccessModels;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual Location Location { get; set; } = null!;
}
