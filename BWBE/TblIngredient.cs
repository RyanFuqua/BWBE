using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblIngredient
{
    public string IngredientId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Measurement { get; set; } = null!;

    public float MaximumAmount { get; set; }

    public float ReorderAmount { get; set; }

    public float MinimumAmount { get; set; }
}
