
public class FormulaItemRepository : iFormulaItemRepository
{
    private readonly IConfiguration _configuration;
    public FormulaItemRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IMongoDatabase GetMongoDatabase(string dbName)
    {
        var connString = _configuration.GetConnectionString("Con_MongoDB");
        var client = new MongoClient(connString);
        var db = client.GetDatabase(dbName);
        return db;
    }
    private IMongoCollection<T> GetCollection<T>(string dbName, string collectionName)
    {
        return GetMongoDatabase(dbName).GetCollection<T>(collectionName);
    }

    public async Task AddNewFormula_Item<T>(string dbName, string collectionName, FormulaItemModel _Formula_Item)
    {
        var col = GetCollection<FormulaItemModel>(dbName, collectionName);
        var count = col.Find(x => true).CountDocuments();
        _Formula_Item.fi_id = Convert.ToInt32(count) + 1;
        await GetCollection<FormulaItemModel>(dbName, collectionName).InsertOneAsync(_Formula_Item);
    }

    public bool DeleteFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter)
    {
         var count = GetCollection<T>(dbName, collectionName).Find(filter).CountDocuments();
        if (count > 0)
        {
            GetCollection<T>(dbName, collectionName).DeleteOneAsync(filter);
            return true;
        }
        return false;
    }

    public Task<List<T>> GetAllFormula_Item<T>(string dbName, string collectionName)
    {
        var col = GetCollection<T>(dbName, collectionName);
        return col.Find(x => true).ToListAsync();
    }

    public async Task<List<T>> GetFilteredFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter)
    {
        return await GetCollection<T>(dbName, collectionName).Find(filter).ToListAsync();
    }

    public async Task UpdateFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> _Formula_Item)
    {
        await GetCollection<T>(dbName, collectionName).UpdateOneAsync(filter, _Formula_Item);
    }
}
