namespace Bookly.Persistence.Options;

public sealed class DatabaseOptions
{
    public const string SectionName = "ConnectionStrings";
    public string SqlServer { get; init; } = string.Empty;
}
