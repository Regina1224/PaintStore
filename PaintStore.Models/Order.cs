using System;

namespace PaintStore.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal TotalPrice { get; set; }

    // Foreign Key
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // A order can have multiple PaintProducts N:N
    public List<PaintProduct> PaintProducts { get; set; }

    public Order(int id, decimal totalPrice, int userId)
    {
        Id = id;
        CreatedDate = DateTime.Now;
        TotalPrice = totalPrice;
        PaintProducts = new List<PaintProduct>();
        UserId = userId;
    }

}
