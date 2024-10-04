namespace Interface.Config;

public readonly struct DbConf(string connectionString)
{
    public string ConnectionString { get; } = connectionString;
}