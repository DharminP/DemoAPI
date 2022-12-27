using MongoDB.Bson;

namespace DemoAPI.Models;
public class FormulaItemModel
{
    public ObjectId _id { get; set; }
    public int fi_id { get; set; }
    public int fi_i_id { get; set; }
    public int fi_s_id { get; set; }
    public string? fi_status { get; set; }
}
