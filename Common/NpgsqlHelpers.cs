using Npgsql;

namespace Game.Common;

public static class NpgsqlHelpers
{
    public static NpgsqlConnection CreateConnection(string connectionString)
    {
        NpgsqlConnection connection = new(connectionString);
        connection.Open();
        return connection;
    }
}