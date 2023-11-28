using System;
using System.Collections.Generic;

namespace _19070006008_midterm.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? UserPassword { get; set; }

    public string? Token { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
