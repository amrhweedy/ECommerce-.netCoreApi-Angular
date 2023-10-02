using Microsoft.Identity.Client;

namespace E_Commerce.DAL.models;


public class BasketItem
{
    public int Id { get; set; }
    public string productName { get; set; } = string.Empty;

    public decimal price { get; set; }

    public int quantity { get; set; }

    public string pictureUrl { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty; 
}