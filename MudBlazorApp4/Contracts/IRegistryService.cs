
namespace TLC.Registry.Contracts
{
    public interface IRegistryService
    {
        Task<Data.Registry[]> GetRegistries();
        Task<Data.Registry> GetRegistry(int id);
        Task UpdateRegistry(int id, Data.Registry registry);
        Task<Data.Registry> CreateRegistry(Data.Registry registry);
        Task DeleteRegistry(int id);
    }
}
