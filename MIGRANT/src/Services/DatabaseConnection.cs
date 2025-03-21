using System;
using System.Data;
using Npgsql; 

public class DatabaseConnection
{
    private string _connectionString;
    private NpgsqlConnection? _connection;

    public DatabaseConnection(string host, string database, string username, string password)
    {
        _connectionString = $"Host={host};Database={database};Username={username};Password={password}";
    }

    public void OpenConnection()
    {
        if (_connection == null)
        {
            _connection = new NpgsqlConnection(_connectionString);
        }

        try
        {
            _connection.Open();
            Console.WriteLine("Connection successfully opened.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening connection: {ex.Message}");
        }
    }

    public void CloseConnection()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
            Console.WriteLine("Connection closed.");
        }
    }

    public void ExecuteQuery(string query)
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            Console.WriteLine("Connection is not open.");
            return;
        }

        try
        {
            using (var cmd = new NpgsqlCommand(query, _connection))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Query executed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing query: {ex.Message}");
        }
    }

    public DataTable ExecuteSelectQuery(string query)
    {
        if (_connection == null || _connection.State != ConnectionState.Open)
        {
            Console.WriteLine("Connection is not open.");
            return null;
        }

        try
        {
            using (var cmd = new NpgsqlCommand(query, _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing select query: {ex.Message}");
            return null;
        }
    }
}
