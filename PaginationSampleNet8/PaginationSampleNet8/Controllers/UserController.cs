using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginationSampleNet8.Adapter.Pagination;
using PaginationSampleNet8.Model.Users;
using PaginationSampleNet8.Repository.Users;

namespace PaginationSampleNet8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userRepository;

        public UserController(UserService userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public void GenerateSampleData()
        {
            _userRepository.GenerateSampleData();
        }

        [HttpGet]
        public IQueryable<User> Get([FromQuery] User user)
        {
            return _userRepository.Get(user);
        }

        [HttpGet]
        public PagedAdapter<User> GetAll([FromQuery] PagingParameters pagingParameters)
        {
            var data = _userRepository.GetAll();
            return new PagedAdapter<User>(data, pagingParameters);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userRepository.Insert(user);
        }

        [HttpDelete]
        public void Delete([FromBody] User user)
        {
            _userRepository.Delete(user);
        }
    }
}
