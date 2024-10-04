namespace Interface.Config;

public struct DbConf
{
    public DbConf(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }
}