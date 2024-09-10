using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblEmail
{
    public string EmailId { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public ulong Valid { get; set; }

    public virtual TblUser User { get; set; } = null!;
}
