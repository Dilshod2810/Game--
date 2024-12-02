using Game.Common;
using Npgsql;

namespace Game.Services;

public static class NpgsqlService
{
    public static void CreateDatabase()
    {
        const string baseConnectionString =
            @"Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=2810;";
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(baseConnectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "Create database gamedev_db";
            command.ExecuteNonQuery();
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


    public static void DropDatabase()
    {
        const string baseConnectionString =
            @"Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=2810;";
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(baseConnectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "drop database gamedev_db";
            command.ExecuteNonQuery();
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

    public static void CreateTable()
    {
        const string baseConnectionString =
            @"Server=127.0.0.1;Port=5432;Database=company_db;User Id=postgres;Password=2810;";
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(baseConnectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"CREATE  TABLE games
                                    (
                                        id  serial primary key ,
                                        name varchar(50) unique ,
                                        genre varchar(50) unique,
                                        year int,
                                        company varchar(50),
                                        platform text
                                    );";
            command.ExecuteNonQuery();
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

    public static void DropTable()
    {
        const string baseConnectionString =
            @"Server=127.0.0.1;Port=5432;Database=company_db;User Id=postgres;Password=2810;";
        try
        {
            using NpgsqlConnection connection = NpgsqlHelpers.CreateConnection(baseConnectionString);
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "drop table games";
            command.ExecuteNonQuery();
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
}