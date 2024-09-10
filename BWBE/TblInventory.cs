using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblInventory
{
    public string EntryId { get; set; } = null!;

    public float Quantity { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public float Cost { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime ExpireDateTime { get; set; }

    public int Ponumber { get; set; }

    public string RecipeId { get; set; } = null!;

    public virtual TblUser Employee { get; set; } = null!;
}
