using MovieStore.DL.Interfaces;
using MovieStore.Models;

namespace MovieStore.DL.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private static readonly List<Actor> _actors = new();

        public Task<List<Actor>> GetAllAsync() => Task.FromResult(_actors);

        public Task<Actor?> GetByIdAsync(string id) =>
            Task.FromResult(_actors.FirstOrDefault(a => a.Id == id));

        public Task AddAsync(Actor actor)
        {
            _actors.Add(actor);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id)
        {
            var actor = _actors.FirstOrDefault(a => a.Id == id);
            if (actor != null) _actors.Remove(actor);
            return Task.CompletedTask;
        }
    }
}
