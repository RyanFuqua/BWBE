using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblPhoneNumber
{
    public string PhoneNumberId { get; set; } = null!;

    public string AreaCode { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Type { get; set; } = null!;

    public ulong Valid { get; set; }

    public string UserId { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
