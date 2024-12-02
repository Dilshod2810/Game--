using Game.Models;

namespace Game.Services.GameService;

public interface IGameService
{
    List<Games> GetGames ();
    Games? GetGameById(int id);
    bool CreateGame(Games games);
    bool UpdateGame(Games games);
    bool DeleteGame(int id);
}