using Game.Common;
using Game.Models;
using Npgsql;


namespace Game.Services.GameService;
public class GameService(string connectionString) : IGameService
{
    public List<Games> GetGames()
    {
        try
        {
            List<Games> res = new();
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.Select;

            using NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Games games = new()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Genre = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        Company = reader.GetString(4),
                        Platform = reader.GetString(5)
                    };
                    res.Add(games);
                }
            }

            return res;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Games? GetGameById(int id)
    {
        try
        {
            Games? res = new();
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.SelectById(id);
            using NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Games
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Genre = reader.GetString(2),
                    Year = reader.GetInt32(3),
                    Company = reader.GetString(4),
                    Platform = reader.GetString(5)
                };
            }
            return null;

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public bool CreateGame(Games games)
    {
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.Insert(games);
            int res = command.ExecuteNonQuery();

            if (res == 0) return false;
            return true;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateGame(Games games)
    {
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.Update(games);
            int res = command.ExecuteNonQuery();

            if (res == 0) return false;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteGame(int id)
    {
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(connectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.Delete(id);
            int res = command.ExecuteNonQuery();

            if (res == 0) return false;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

file static class SqlCommands
{
    public static string Insert(Games games)
    {
        return $@"INSERT INTO games(name,genre,year,company,platform)
                values('{games.Name}', '{games.Genre}', '{games.Year}','{games.Company}', '{games.Platform}')";
    }

    public static string Update(Games games)
    {
        return $@"Update  games
                   set name='{games.Name}',
                        genre='{games.Genre}',
                        year='{games.Year}',
                        company='{games.Company}',
                        platform='{games.Platform}'
                        where id ={games.Id}";
    }

    public const string Select = "Select * from games";

    public static string SelectById(int id)
        => $"select * from games where id = {id} limit 1";

    public static string Delete(int id)
        => $"delete  from games where id = {id}";
}