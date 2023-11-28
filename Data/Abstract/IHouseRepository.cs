using _19070006008_midterm.Models;

namespace _19070006008_midterm.Data.Abstract
{
    public interface IHouseRepository : IRepository<House>
    {
        public Task<List<House>> GetAvailableHouses(QueryHouseModel model);
        public Task<House> UpdateHouseAvailability(int houseId, bool isBooked);
        public House GetHouseFromHouseNo(string houseNo);
    }
}
