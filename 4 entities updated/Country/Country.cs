using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int Delete { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
