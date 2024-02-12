namespace server.Models;

public class CatsStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CardsCollectionName { get; set; } = null!;
    
    public string UsersCollectionName { get; set; } = null!;
    
    public string UserPurchasesCollectionName { get; set; } = null!;
    
    public string UserBalanceCollectionName { get; set; } = null!;
    
    public string UserCartCollectionName { get; set; } = null!;

}