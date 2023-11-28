using _19070006008_midterm.Data.Abstract;
using _19070006008_midterm.Logic.Abstract;
using _19070006008_midterm.Models;
using _19070006008_midterm.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _19070006008_midterm.Data.EntityFramework
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public async Task<List<House>> GetAvailableHouses(QueryHouseModel model)
        {
            using (var context = new DataContext())
            {
                var filter = new PaginationService(model.PageNumber, model.PageSize);

                var pagedData = await context.Houses
                    .Where(house => house.AvailableFromDate <= model.DateFrom && house.AvailableToDate >= model.DateTo && house.Location == model.Location && house.MaxOccupancy >= model.PeopleCount)
                    .Skip((filter.MinPageSize - 1) * filter.MaxPageSize)
                    .Take(filter.MaxPageSize)
                    .ToListAsync();

                return pagedData;
            }
        }

        public async Task<House> UpdateHouseAvailability(int houseId, bool isBooked)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var house = await context.Houses.FindAsync(houseId);
                    if (house != null)
                    {
                       
                        await context.SaveChangesAsync();
                    }
                    return house;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public House GetHouseFromHouseCode(string houseCode)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var house = context.Houses.FirstOrDefault(h => h.HouseCode == houseCode);
                    return house;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
