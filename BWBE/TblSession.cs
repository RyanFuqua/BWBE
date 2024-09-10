using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblSession
{
    public string SessionId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime LastActivityDateTime { get; set; }

    public virtual TblUser Employee { get; set; } = null!;
}
