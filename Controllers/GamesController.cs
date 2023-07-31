using CrudAPI.Models;
using CrudAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<GamesModel>>> SearchAllGames()
        {
            List<GamesModel> games = await _gamesRepository.SearchAllGames();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamesModel>> SearchById(int id)
        {
            GamesModel games = await _gamesRepository.SearchById(id);
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult<GamesModel>> ToAdd([FromBody]GamesModel GamesModel)
        {
            GamesModel games = await _gamesRepository.ToAdd(GamesModel);           
            return Ok(games);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GamesModel>> ToUpdate([FromBody] GamesModel GamesModel, int id)
        {
            GamesModel.Id = id;
            GamesModel games = await _gamesRepository.ToUpdate(GamesModel, id);
            return Ok(games);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GamesModel>> ToDelete(int id)
        {
            bool deleted = await _gamesRepository.ToDelete(id);
            return Ok(deleted);
        }
    }
}
