using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;
/// <summary>
/// Represents an individual product for sale
/// </summary>
public class Product
{
    /// <summary>
    /// The unique identifier for the product
    /// </summary>
    [Key]
   
    public int ProductId { get; set; }
    /// <summary>
    /// The user facing title of the product
    /// </summary>

    [StringLength(50, ErrorMessage = "Title must be at most 50 characters long.")]
    public required string Title { get; set; }
    /// <summary>
    /// The current sales price of the product
    /// </summary>

    [Range(0, 10_000 )]
    public double Price { get; set; }
}
