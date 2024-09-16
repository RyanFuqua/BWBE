using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BWBE.Models;

public class User
{ 
    [MaxLength(36)] public string Id { get; set; } = null!;

    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(50)] public string LastName { get; set; } = null!;
    [MaxLength(50)] public string Username { get; set; } = null!;
    [MaxLength(64)] public string PassHash { get; set; } = null!;
    [MaxLength(50)] public string PassSalt { get; set; } = null!;
    
    public byte Perms { get; set; }
}