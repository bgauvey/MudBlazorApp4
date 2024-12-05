using System.Net.Http.Json;
using TLC.Registry.Client.Contracts;

namespace TLC.Registry.Client.Services
{
    internal class RegistryService : IRegistryService
    {
        private readonly HttpClient _httpClient;
        public RegistryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Models.Registry> CreateRegistry(Models.Registry registry)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRegistry(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Registry[]?> GetRegistries()
        {
            return await _httpClient.GetFromJsonAsync<Models.Registry[]>("/api/registry");
        }

        public async Task<Models.Registry> GetRegistry(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRegistry(int id, Models.Registry registry)
        {
            throw new NotImplementedException();
        }
    }
}
