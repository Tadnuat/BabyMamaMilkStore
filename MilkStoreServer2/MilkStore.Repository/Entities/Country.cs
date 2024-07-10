using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;
    public string Delete { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
