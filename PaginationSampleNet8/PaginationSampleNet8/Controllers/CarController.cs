using Microsoft.AspNetCore.Mvc;
using PaginationSampleNet8.Adapter.Pagination;
using PaginationSampleNet8.Model.Cars;
using PaginationSampleNet8.Services.Cars;

namespace PaginationSampleNet8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarService _carsRepository;

        public CarController(CarService carsRepository)
        {
            this._carsRepository = carsRepository;
        }
        [HttpGet]
        public void GenerateSampleData()
        {
            _carsRepository.GenerateSampleData();
        }

        [HttpGet]
        public IQueryable<Car> Get([FromQuery] Car car)
        {
            return _carsRepository.Get(car);
        }

        [HttpGet]
        public PagedAdapter<Car> GetAll([FromQuery] PagingParameters pagingParameters)
        {
            var data = _carsRepository.GetAll();
            return new PagedAdapter<Car>(data, pagingParameters);
        }

        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _carsRepository.Insert(car);
        }

        [HttpDelete]
        public void Delete([FromBody] Car car)
        {
            _carsRepository.Delete(car);
        }

    }
}
