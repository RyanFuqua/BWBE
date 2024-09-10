using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblPhoneType
{
    public string TypeId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ulong Active { get; set; }
}
