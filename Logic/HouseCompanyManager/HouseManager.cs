using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Logic.Abstract;
using _19070006008_midterm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _19070006008_midterm.Logic._19070006008_midtermManagers
{
    public class HouseManager : IHouseManager
    {
        private IUserHouseManager _userHouseManager;
        private IUserManager _userManager;
        private IHouseRepository _houseRepository;

        public HouseManager(IHouseRepository houseRepository, IUserHouseManager userHouseManager, IUserManager userManager)
        {
            _houseRepository = houseRepository;
            _userHouseManager = userHouseManager;
            _userManager = userManager;
        }

        public async Task<LogicResponseDTO<List<House>>> GetAvailableHouses(QueryHouseModel model)
        {
            var houses = await _houseRepository.GetAvailableHouses(model);
            return new LogicResponseDTO<List<House>>
            {
                Data = houses,
                Success = houses.Count > 0,
                Message = houses.Count > 0 ? "There are available houses." : "No houses are available with the given criteria."
            };
        }

        public async Task<LogicResponseDTO<string>> BookHouse(BookHouseModel model, string token)
        {
            var house = _houseRepository.GetHouseFromHouseCode(model.HouseCode);
            var user = _userManager.GetUserFromToken(token);
            if (house != null && user != null)
            {
                if (_userHouseManager.IsBookingExist(user.Id, house.Id))
                {
                    return new LogicResponseDTO<string> { Data = null, Message = "User has already booked this house!", Success = false };
                }
                else
                {
                    var createdBooking = await _userHouseManager.BookHouse(new Booking { HouseId = house.Id, UserId = user.Id, CheckInDate = model.CheckInDate, CheckOutDate = model.CheckOutDate });
                    if (createdBooking != null && createdBooking.Id > 0)
                    {
                        return new LogicResponseDTO<string> { Data = null, Message = "House booked successfully.", Success = true };
                    }
                    else
                    {
                        return new LogicResponseDTO<string> { Data = null, Message = "Booking could not be completed.", Success = false };
                    }
                }
            }
            else if (house == null)
            {
                return new LogicResponseDTO<string> { Data = null, Message = "House not found!", Success = false };
            }
            else
            {
                return new LogicResponseDTO<string> { Data = null, Message = "User not found!", Success = false };
            }
        }
    }
}
