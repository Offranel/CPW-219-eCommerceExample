using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// Represents a registered member
/// </summary>
public class Member
{
    /// <summary>
    /// The unique identifier for the member
    /// </summary>
    [Key]
    public int MemberId { get; set; }

    /// <summary>
    /// The username of the member
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// The email address of the member
    /// </summary>
    [EmailAddress]
    public required string Email { get; set; }

    /// <summary>
    /// The password of the member
    /// </summary>
    public required string Password { get; set; }

    /// <summary>
    /// The member's date of birth
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
}
