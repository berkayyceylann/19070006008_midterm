using Microsoft.AspNetCore.Mvc;
using System;

namespace _19070006008_midterm.Models
{
    public class BookHouseModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Location { get; set; }
        public string HouseCode { get; set; }
        public string FullName { get; set; }
    }
}
