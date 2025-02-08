namespace ProductJudgeAPI.Entities;

public class StoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;

    public string UsersCollectionName { get; set; } = null!;

    public string ProductsCollectionName { get; set; } = null!;

    public string JudgeCollectionName { get; set; } = null!;

    public string CategoryCollectionName { get; set; } = null!;

    public string BarcodeCollectionName { get; set; } = null!;
}
