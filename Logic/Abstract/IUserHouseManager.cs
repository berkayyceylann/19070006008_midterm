using _19070006008_midterm.Models;
using System.Threading.Tasks;

namespace _19070006008_midterm.Logic.Abstract
{
    public interface IUserHouseManager
    {
        Task<Booking> BookHouse(Booking booking);

        bool IsBookingExist(int userId, int houseId);
    }
}
