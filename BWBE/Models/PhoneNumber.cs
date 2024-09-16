using System.ComponentModel.DataAnnotations;

namespace BWBE.Models;

public class PhoneNumber
{
    [MaxLength(36)] public string Id { get; set; } = null!;
    [MaxLength(36)] public string UserId { get; set; } = null!;
    
    public int CountryCode { get; set; }
    [MaxLength(36)] public string Number { get; set; } = null!;
    
    public bool Verified  { get; set; }
}