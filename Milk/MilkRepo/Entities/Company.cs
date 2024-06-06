using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual ICollection<BrandMilk> BrandMilks { get; set; } = new List<BrandMilk>();

    public virtual Country? Country { get; set; }
}
