using System;

namespace PaintStore.Models;

public class PaintProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public PaintProduct(int id, string name, decimal price, string description)
    {
        Id = id;
        Name = name;
        CreatedDate = DateTime.Now;
        Price = price;
        Description = description;
    }


}
