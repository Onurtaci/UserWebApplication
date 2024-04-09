using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    [Required]
    [MaxLength(250)]
    [DisplayName("Email")]
    public string Email { get; set; }
    [Required]
    [MaxLength(25)]
    [DisplayName("Phone")]
    public string Phone { get; set; }
    [Required]
    [MaxLength(50)]
    [DisplayName("Password")]
    public string Password { get; set; }
    [DisplayName("Profile Image")]
    public byte[]? ProfileImage { get; set; }
}
