using System;
using System.Collections.Generic;

namespace MilkStore.Repo.Entities;

public partial class BrandMilk
{
    public int BrandMilkID { get; set; }

    public string BrandName { get; set; } = null!;

    public int? CompanyID { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
}
