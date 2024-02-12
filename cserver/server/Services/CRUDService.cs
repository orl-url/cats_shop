using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Models;

namespace server.Services;

public class CRUDService<T> where T : IEntity
{
    protected readonly IMongoCollection<T> Collection;

    protected CRUDService(IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings,
        string collectionName)
    {
        var mongoClient = new MongoClient(
            catsStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            catsStoreDatabaseSettings.Value.DatabaseName);

        Collection = mongoDatabase.GetCollection<T>(collectionName);
    }


    public async Task<List<T>> GetAsync()
    {
        return await Collection.Find(_ => true).ToListAsync();
    }

    
    public async Task<T?> GetByIdAsync(string? id)
    {
        if (id == null)
        {
            return default(T);
        }
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    } 
    
   
    
    
    public async Task<T?> GetByUserIdAsync(string? userId)
    {
        if (userId == null)
        {
            return default(T);
        }
        return await Collection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
    }


    protected async Task<T?> CreateAsync(T? newEntity)
    {
        if (newEntity == null)
        {
            return default(T);
        }
        await Collection.InsertOneAsync(newEntity);

        return newEntity;
    }

    
    public async Task UpdateAsync(T? newEntity, string userId)
    {
        var oldEntity = await GetByUserIdAsync(userId);
        
        if (newEntity == null  || oldEntity == null) 
        {
            return;
        }
        await Collection.ReplaceOneAsync(x => x.UserId == newEntity.UserId, newEntity);
    }


    public async Task DeleteByIdAsync(string id)
    {
        await Collection.DeleteOneAsync(x => x.Id == id);
    }
}