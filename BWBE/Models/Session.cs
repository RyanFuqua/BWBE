using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BWBE.Models;

public class Session
{
    [MaxLength(36)] public string Id { get; set; } = null!;
    [MaxLength(36)] public string UserId { get; set; } = null!;

    public DateTime CreationDate { get; set; }
    public DateTime LastActiveDate { get; set; }
}