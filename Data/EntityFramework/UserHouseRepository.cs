using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Models;
using System;
using System.Linq;

namespace _19070006008_midterm.Data.EntityFramework
{
    public class UserHouseRepository : Repository<Booking>, IUserHouseRepository
    {
        public bool IsUserAssignedToHouse(int userId, int houseId)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var booking = context.Bookings.FirstOrDefault(b => b.UserId == userId && b.HouseId == houseId);
                    return booking != null;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
