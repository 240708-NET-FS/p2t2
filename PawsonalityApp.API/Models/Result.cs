using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Pawsonality.API.Models;

public class Result
{
    [Key]
    public int TestID { get; set; }

    public DateTime TimeStamp { get; set; }

    public string ResultValue { get; set; }

    // Foreign Key for ApplicationUser
    public string UserId { get; set; }


    // One-to-Many Relationship between User and Result
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; }
}