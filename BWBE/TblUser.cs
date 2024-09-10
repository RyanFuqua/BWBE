using System;
using System.Collections.Generic;

namespace BWBE;

public partial class TblUser
{
    public string EmployeeId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TblEmail> TblEmails { get; set; } = new List<TblEmail>();

    public virtual ICollection<TblInventory> TblInventories { get; set; } = new List<TblInventory>();

    public virtual ICollection<TblPhoneNumber> TblPhoneNumbers { get; set; } = new List<TblPhoneNumber>();

    public virtual ICollection<TblSession> TblSessions { get; set; } = new List<TblSession>();
}
