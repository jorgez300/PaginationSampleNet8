using Microsoft.AspNetCore.Mvc;
using PaginationSampleNet8.Models.Pagination;
using PaginationSampleNet8.Repository.Car;

namespace PaginationSampleNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarsRepository _carsRepository;

        public CarController(CarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }

        [HttpGet]
        public PagedList<Cars> Get([FromQuery ]PagingParameters pagingParameters)
        {
            return _carsRepository.GetCars(pagingParameters);
        }

    }
}
