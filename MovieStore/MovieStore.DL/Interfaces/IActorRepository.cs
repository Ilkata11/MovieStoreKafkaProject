using MovieStore.Models;

namespace MovieStore.DL.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllAsync();
        Task<Actor?> GetByIdAsync(string id);
        Task AddAsync(Actor actor);
        Task DeleteAsync(string id);
    }
}
