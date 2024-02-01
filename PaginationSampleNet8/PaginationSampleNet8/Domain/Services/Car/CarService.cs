using Bogus;
using PaginationSampleNet8.Model.Cars;
using PaginationSampleNet8.Helper.Pagination;
using PaginationSampleNet8.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace PaginationSampleNet8.Services.Cars
{
    public class CarService
    {
        protected readonly WebApiDbContext _webApiDbContext;
        public CarService(WebApiDbContext webApiDbContext)
        {
            _webApiDbContext = webApiDbContext;
        }

        public void GenerateSampleData()
        {
            DbSet<Car> dbSet = _webApiDbContext.Set<Car>();
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
                _webApiDbContext.SaveChanges();
            }

            int carId = 0;
            var fakeCars = new Faker<Car>()
                .RuleFor(c => c.Id, f => ++carId)
                .RuleFor(c => c.Model, f => "Models_" + carId)
                .RuleFor(c => c.Brand, f => "Brands_" + carId)
                .RuleFor(c => c.Price, f => carId * 1000);

            var data = fakeCars.Generate(500).AsQueryable();
            _webApiDbContext.Cars.AddRange(data);
            _webApiDbContext.SaveChanges();

        }

        public IQueryable<Car> Get(Car car)
        {
            return _webApiDbContext.Cars.Where(x => x.Id == car.Id).AsQueryable();
            
        }

        public IQueryable<Car> GetAll()
        {
            return _webApiDbContext.Cars.AsQueryable();
        }
        public void Insert(Car car) 
        {
            _webApiDbContext.Cars.Add(car);
            _webApiDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            _webApiDbContext.Cars.Remove(car);
            _webApiDbContext.SaveChanges();

        }


    }
}
