using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.Concrete;
using CarBook.DataAccessLayer.Repositories;
using CarBook.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.EntityFramework
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        public List<Car> GetAllCarsWithBrands()
        {
            var context= new CarBookContext();
            //include metodu ilişkisi olan tablolarda birden fazla veri çekmeye yarayan metoddur.
            var value= context.Cars.Include(x=>x.Brand).Include(y=> y.CarStatus).Include(z=>z.CarCategory).ToList();
            return value;
        }
    }
}
