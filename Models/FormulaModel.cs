global using MongoDB.Bson;

namespace DemoAPI.Models;
public class FormulaModel
{
    public ObjectId _id { get; set; }
    public int f_id { get; set; }
    public string? f_item { get; set; }
    public string? f_Shade { get; set; }
    public string? f_creation_date { get; set; }
}
