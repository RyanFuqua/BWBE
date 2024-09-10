using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblOrder
{
    public string PurchaseId { get; set; } = null!;

    public string VendorId { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public virtual TblVendor Vendor { get; set; } = null!;
}
