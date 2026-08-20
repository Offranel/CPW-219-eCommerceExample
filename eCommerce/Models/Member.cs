using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;
/// <summary>
/// Represents an individual website user
/// </summary>
public class Member
{
    [Key]
    public int MemberId { get; set; }
    /// <summary>
    /// Public facing username for the member
    /// Alphanumeric characteres only 
    /// </summary>
    [RegularExpression("^[a-zA-Z0-9]+$",
        ErrorMessage = "Username must be alphanumeric only")]
    [StringLength(25)]
    public required string UserName { get; set; }
    /// <summary>
    /// Email for the member
    /// </summary>
    /// 
    public required string Email { get; set; }
    /// <summary>
    /// The member password 
    /// </summary>
    /// 
    [StringLength(50, MinimumLength = 6,
        ErrorMessage = "Your password must be between 6 and 50 characteres")]
    public required string Password { get; set; }
    /// <summary>
    /// The date of birth
    /// </summary>
    public DateOnly DateOfBirth { get; set; }
}
