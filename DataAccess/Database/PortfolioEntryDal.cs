using System.Data.SqlClient;
using Interface.Dtos;
using Interface.Interfaces.Dal;
using Microsoft.Data.SqlClient;

namespace DataAccess.Database;

public class PortfolioEntryDal : IPortfolioEntryDal
{
    private readonly string _connectionString;

    public PortfolioEntryDal(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task CreatePortfolioEntry(PortfolioEntryDto portfolioEntryDto)
    {
        await using var connection = new SqlConnection(_connectionString);
        try
        {
            await using (connection)
            {
                await connection.OpenAsync();
                await using var command =
                    new SqlCommand(
                        "INSERT INTO PortfolioEntry (id, title, description, mediaUrl) VALUES (@id, @title, @description, @mediaUrl)",
                        connection);
                command.Parameters.AddWithValue("@id", portfolioEntryDto.Id);
                command.Parameters.AddWithValue("@title", portfolioEntryDto.Title);
                command.Parameters.AddWithValue("@description", portfolioEntryDto.Description);
                command.Parameters.AddWithValue("@mediaUrl", portfolioEntryDto.MediaUrl);
                await command.ExecuteNonQueryAsync();

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentException("Something went wrong while creating PortfolioEntry:" + e.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    public async Task<PortfolioEntryDto> GetPortfolioEntryById(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        try
        {
            await using (connection)
            {
                await connection.OpenAsync();
                await using var command = new SqlCommand("SELECT * FROM PortfolioEntry WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                await using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    return new PortfolioEntryDto()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        MediaUrl = reader.GetString(3),
                    };
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentException("Something went wrong while getting PortfolioEntry:" + e.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
        return null!;
    }

    public async Task<List<PortfolioEntryDto>> GetAllPortfolioEntries()
    {
        await using var connection = new SqlConnection(_connectionString);
        var portfolioEntries = new List<PortfolioEntryDto>();
        try
        {
            await using (connection)
            {
                await connection.OpenAsync();
                await using var command = new SqlCommand("SELECT * FROM PortfolioEntry", connection);
                await using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    portfolioEntries.Add(new PortfolioEntryDto()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        MediaUrl = reader.GetString(3),
                    });
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentException("Something went wrong while getting PortfolioEntries:" + e.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
        return portfolioEntries;
    }

    public async Task UpdatePortfolioEntry(PortfolioEntryDto portfolioEntryDto)
    {
        await using var connection = new SqlConnection(_connectionString);
        try
        {
            await using (connection)
            {
                await connection.OpenAsync();
                await using var command =
                    new SqlCommand(
                        "UPDATE PortfolioEntry SET title = @title, description = @description, mediaUrl = @mediaUrl WHERE id = @id",
                        connection);
                command.Parameters.AddWithValue("@id", portfolioEntryDto.Id);
                command.Parameters.AddWithValue("@title", portfolioEntryDto.Title);
                command.Parameters.AddWithValue("@description", portfolioEntryDto.Description);
                command.Parameters.AddWithValue("@mediaUrl", portfolioEntryDto.MediaUrl);
                await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentException("Something went wrong while updating PortfolioEntry:" + e.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
    
    public async Task DeletePortfolioEntry(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        try
        {
            await using (connection)
            {
                await connection.OpenAsync();
                await using var command = new SqlCommand("DELETE FROM PortfolioEntry WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentException("Something went wrong while deleting PortfolioEntry:" + e.Message);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}