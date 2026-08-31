using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// Represents an individual website user
/// </summary>
public class Member
{
    [Key]
    public int MemberId { get; set; }

    public required string Username { get; set; }

    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}

public class RegistrationViewModel
{
    /// <summary>
    /// Public facing username for the member. Alphanumeric characteres only
    /// </summary>
    [RegularExpression("^[a-zA-Z0-9]+$",
        ErrorMessage = "Username must be alphanumeric only")]
    [StringLength(25)]
    public required string Username { get; set; }
    /// <summary>
    /// Email for the member
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    /// <summary>
    /// The member's password
    /// </summary>
    [StringLength(50, MinimumLength = 6,
        ErrorMessage = "Your password must be between 6 and 50 characters")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
    /// <summary>
    /// The date of birth of the member
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
public class LoginViewModel
{
    [Required]
    public required string UsernameOrEmail { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}