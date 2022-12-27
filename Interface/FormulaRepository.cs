
public class FormulaRepository : iFormulaRepository
{
    private readonly IConfiguration _configuration;
    public FormulaRepository(IConfiguration configuration)
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

    public async Task AddNewFormula<T>(string dbName, string collectionName, FormulaModel _Formula)
    {
        var col = GetCollection<FormulaModel>(dbName, collectionName);
        var count = col.Find(x => true).CountDocuments();
        _Formula.f_id = Convert.ToInt32(count) + 1;
        await GetCollection<FormulaModel>(dbName, collectionName).InsertOneAsync(_Formula);
    }

    public bool DeleteFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter)
    {
         var count = GetCollection<T>(dbName, collectionName).Find(filter).CountDocuments();
        if (count > 0)
        {
            GetCollection<T>(dbName, collectionName).DeleteOneAsync(filter);
            return true;
        }
        return false;
    }

    public Task<List<T>> GetAllFormula<T>(string dbName, string collectionName)
    {
        var col = GetCollection<T>(dbName, collectionName);
        return col.Find(x => true).ToListAsync();
    }

    public async Task<List<T>> GetFilteredFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter)
    {
        return await GetCollection<T>(dbName, collectionName).Find(filter).ToListAsync();
    }

    public async Task UpdateFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> _Formula)
    {
        await GetCollection<T>(dbName, collectionName).UpdateOneAsync(filter, _Formula);
    }
}