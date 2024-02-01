using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginationSampleNet8.Domain.Model.Pokemons;
using PaginationSampleNet8.Domain.Services.Pokemons;

namespace PaginationSampleNet8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        protected readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<Pokemon?> Get([FromQuery] string name)
        {
            return await _pokemonService.GetPokemonAsync(name);
        }
    }
}
