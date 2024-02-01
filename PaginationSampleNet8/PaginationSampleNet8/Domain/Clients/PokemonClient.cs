using Newtonsoft.Json;
using PaginationSampleNet8.Domain.Adapter.Cache;
using PaginationSampleNet8.Domain.Model.Pokemons;


namespace PaginationSampleNet8.Domain.Clients.Pokemons
{
    public class PokemonClient
    {
        protected readonly CacheHelper _cacheAdapter;
        protected readonly IConfiguration _iConfiguration;

        public PokemonClient(CacheHelper cacheAdapter, IConfiguration iConfiguration)
        {
            _cacheAdapter = cacheAdapter;
            _iConfiguration = iConfiguration;
        }

        public async Task<Pokemon?> GetPokemonAsync(string Pokemon)
        {


            if (_cacheAdapter.Exists<Pokemon>(Pokemon))
            {

                return _cacheAdapter.GetValue<Pokemon>(Pokemon);

            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, _iConfiguration.GetValue<string>("PokemonAPI") + Pokemon);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                _cacheAdapter.SetValue<Pokemon>(Pokemon, JsonConvert.DeserializeObject<Pokemon>(content)!);

                return JsonConvert.DeserializeObject<Pokemon>(content);
            }



        }


    }
}
