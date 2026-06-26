using System;

namespace PaintStore.Models;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // A user can have multiple orders 1:N
    public List<Order> Orders { get; set; }

    public User(int id, string name, string email, string phone)
    {
        Id = id;
        CreatedDate = DateTime.Now;
        Name = name;
        Email = email;
        Phone = phone;
        Orders = new List<Order>();
    }

}
