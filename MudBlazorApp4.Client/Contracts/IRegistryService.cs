using static System.Runtime.InteropServices.JavaScript.JSType;
using TLC.Registry.Client.Models;

namespace TLC.Registry.Client.Contracts
{
    public interface IRegistryService
    {
        Task<Models.Registry[]?> GetRegistries();
        Task<Models.Registry> GetRegistry(int id);
        Task UpdateRegistry(int id, Models.Registry breeder);
        Task<Models.Registry> CreateRegistry(Models.Registry breeder);
        Task DeleteRegistry(int id);
    }
}
