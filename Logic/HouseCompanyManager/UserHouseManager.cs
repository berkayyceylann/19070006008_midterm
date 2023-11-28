using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Models;
using System.Threading.Tasks;
using _19070006008_midterm.Logic.Abstract;

namespace _19070006008_midterm.Logic._19070006008_midtermManagers
{
    public class UserHouseManager : IUserHouseManager
    {
        private IUserHouseRepository _repository;

        public UserHouseManager(IUserHouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Booking> BookHouse(Booking booking)
        {
           
            var createdBooking = await _repository.Create(booking);
            return createdBooking;
        }

        public bool IsBookingExist(int userId, int houseId)
        {
            
            return _repository.IsUserAssignedToHouse(userId, houseId);
        }
    }
}
