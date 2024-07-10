using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class Company
{
    public int CompanyID { get; set; }

    public string CompanyName { get; set; } = null!;

    public int? CountryID { get; set; }

    public virtual ICollection<BrandMilk> BrandMilks { get; set; } = new List<BrandMilk>();

    public virtual Country? Country { get; set; }
}
