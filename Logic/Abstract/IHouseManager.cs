using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _19070006008_midterm.Logic.Abstract
{
    public interface IHouseManager
    {
        Task<LogicResponseDTO<List<House>>> GetAvailableHouses(QueryHouseModel model);
        Task<LogicResponseDTO<string>> BookHouse(BookHouseModel model, string token);
    }
}
