using System;
using System.Collections.Generic;

namespace _19070006008_midterm.Model;

public partial class House
{
    public int HouseId { get; set; }

    public string? HouseName { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public int? MaxOccupancy { get; set; }

    public string? Amenities { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
