using CrudAPI.Data;
using CrudAPI.Models;
using CrudAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameDBContext _dBContext;
        public GamesRepository(GameDBContext gameDBContext)
        {
            _dBContext = gameDBContext;
        }
         async Task<List<GamesModel>> IGamesRepository.SearchAllGames()
        {
            return await _dBContext.Games.ToListAsync();
        }

         async Task<GamesModel> IGamesRepository.SearchById(int id)
        {
            return await _dBContext.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

         async Task<GamesModel> IGamesRepository.ToAdd(GamesModel games)
        {
           await _dBContext.Games.AddAsync(games);
           await _dBContext.SaveChangesAsync();

            return games;

        }

            async Task<GamesModel> IGamesRepository.ToUpdate(GamesModel games, int id)
        {
            GamesModel gamesById = await ((IGamesRepository)this).SearchById(id);

            if (gamesById == null)
            {
                throw new Exception($"Games Id {id} do not found in data base");
            }
            gamesById.Name = games.Name;
            gamesById.Company = games.Company;

            _dBContext.Games.Update(gamesById);
            await _dBContext.SaveChangesAsync();
            return gamesById;
        }

        async Task<bool> IGamesRepository.ToDelete(int id)
        {
            GamesModel gamesById = await ((IGamesRepository)this).SearchById(id);

            if(gamesById == null)
            {
                throw new Exception($"Games Id {id} do not found in data base");
            }

            _dBContext.Games.Remove(gamesById);
            await _dBContext.SaveChangesAsync();
            return true;
        }
    }
}
