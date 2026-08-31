using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// Represents the information required to register a member
/// </summary>
public class RegistrationViewModel
{
    /// <summary>
    /// The username of the member
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Username { get; set; }

    /// <summary>
    /// The email address of the member
    /// </summary>
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    /// <summary>
    /// The password of the member
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6)]
    public required string Password { get; set; }

    /// <summary>
    /// Confirms the member's password
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
