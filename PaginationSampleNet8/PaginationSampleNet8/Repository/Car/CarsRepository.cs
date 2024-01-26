using Bogus;
using PaginationSampleNet8.Models.Pagination;

namespace PaginationSampleNet8.Repository.Car
{
    public class CarsRepository
    {

        private IQueryable<Cars> GenerateSampleData()
        {
            int carId = 0;
            var fakeCars = new Faker<Cars>()
                .RuleFor(c => c.Id, f => ++carId)
                .RuleFor(c => c.Model, f => "Model_" + carId)
                .RuleFor(c => c.Brand, f => "Brand_" + carId)
                .RuleFor(c => c.Price, f => carId * 1000);

            var data = fakeCars.Generate(100).AsQueryable();

            return data;
        }

        public PagedList<Cars> GetCars(PagingParameters pagingParameters)
        {
            var cars = new  PagedList<Cars>(GenerateSampleData().OrderBy(c => c.Id), pagingParameters.PageNumber, pagingParameters.PageSize);

            return cars;
        }

    }
}
