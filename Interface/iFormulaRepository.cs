global using DemoAPI.Models;
global using MongoDB.Driver;

public interface iFormulaRepository
{
    Task<List<T>> GetAllFormula<T>(string dbName, string collectionName);
    Task AddNewFormula<T>(string dbName, string collectionName, FormulaModel _Formula);
    Task<List<T>> GetFilteredFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter);
    Boolean DeleteFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter);
    Task UpdateFormula<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> _Formula);

}