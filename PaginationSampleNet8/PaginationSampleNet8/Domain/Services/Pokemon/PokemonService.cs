using PaginationSampleNet8.Domain.Clients.Pokemons;
using PaginationSampleNet8.Domain.Model.Pokemons;

namespace PaginationSampleNet8.Domain.Services.Pokemons
{
    public class PokemonService
    {
        private protected PokemonClient _client;

        public PokemonService(PokemonClient client)
        {
            _client = client;
        }

        public async Task<Pokemon?> GetPokemonAsync(string name) {

            return await _client.GetPokemonAsync(name);
        
        
        
        }
    }
}
