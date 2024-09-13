using System.ComponentModel.DataAnnotations;

namespace BWBE.Models;

public class User
{ 
    public int Id { get; set; }

    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(50)] public string LastName { get; set; } = null!;
    [MaxLength(64)] public string PassHash { get; set; } = null!;
    
    public byte Perms { get; set; }
}