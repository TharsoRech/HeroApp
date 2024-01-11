using HeroApp.Models.Response;

namespace HeroApp.Repository
{
    public interface IHeroeRepository
    {
        Task<ResultHeroResponse> GetHeroes(int limit, int offset, string filteredName = null);
    }
}
