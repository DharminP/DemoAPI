
public interface iFormulaItemRepository
{
    Task<List<T>> GetAllFormula_Item<T>(string dbName, string collectionName);
    Task AddNewFormula_Item<T>(string dbName, string collectionName, FormulaItemModel _Formula_Item);
    Task<List<T>> GetFilteredFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter);
    Boolean DeleteFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter);
    Task UpdateFormula_Item<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> _Formula_Item);

}