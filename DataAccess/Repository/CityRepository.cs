using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CityRepository : ICityRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            City cityToDelete = context.Cities.SingleOrDefault(c => c.Id == id);
            context.Cities.Remove(cityToDelete);

            return context.SaveChanges();
        }

        public City Get(int id)
        {
            return context.Cities.SingleOrDefault(c => c.Id == id);
        }

        public List<City> GetAll()
        {
            return context.Cities.ToList();
        }

        public int Insert(City city)
        {
            context.Cities.Add(city);

            return context.SaveChanges();
        }

        public int Update(City city)
        {
            City cityToUpdate = context.Cities.SingleOrDefault(c => c.Id == city.Id);
            cityToUpdate.Name = city.Name;

            return context.SaveChanges();
        }
    }
}
