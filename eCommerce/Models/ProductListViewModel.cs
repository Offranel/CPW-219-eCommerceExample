namespace eCommerce.Models;

public class ProductListViewModel
{
    public required IEnumerable<Product> Products { get; set; }

    public string? SearchTerm { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public int TotalItems { get; set; }
}
