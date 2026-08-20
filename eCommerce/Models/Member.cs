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
    public required string UserName { get; set; }
    /// <summary>
    /// Email for the member
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// The member password 
    /// </summary>
    public required string Password { get; set; }
    /// <summary>
    /// The date of birth
    /// </summary>
    public DateOnly DateOfBirth { get; set; }
}
