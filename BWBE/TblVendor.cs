using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblVendor
{
    public string VendorId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
