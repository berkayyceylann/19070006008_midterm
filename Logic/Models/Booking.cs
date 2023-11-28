using System;
using System.Collections.Generic;

namespace _19070006008_midterm.Model;

public partial class Booking
{
    public int Id { get; set; }

    public int? BookingId { get; set; }

    public int? UserId { get; set; }

    public int? HouseId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Status { get; set; }

    public virtual House? House { get; set; }

    public virtual User? User { get; set; }
}
