using CrudAPI.Models;

namespace CrudAPI.Repositories.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<GamesModel>> SearchAllGames();
        Task<GamesModel> SearchById(int id);
        Task<GamesModel> ToAdd(GamesModel games);
        Task<GamesModel> ToUpdate(GamesModel games, int id);
        Task<bool> ToDelete(int id);
    }
}
