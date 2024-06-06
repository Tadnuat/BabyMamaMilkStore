using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class AgeRange
{
    public int AgeRangeId { get; set; }

    public string? Baby { get; set; }

    public string? Mama { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
