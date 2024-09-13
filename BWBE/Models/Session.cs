using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BWBE.Models;

[PrimaryKey(nameof(Id), nameof(UserId))]
public class Session
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [MaxLength(100)] public string CreationDate { get; set; } = null!;
    [MaxLength(100)] public string LastActiveDate { get; set; } = null!;
}