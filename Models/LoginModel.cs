namespace DemoAPI.Models;

public class LoginModel
{
    public ObjectId _id { get; set; }
    public int lg_id { get; set; }
    public string? lg_username { get; set; }
    public string? lg_password { get; set; }
    public string? lg_role { get; set; }
    public string? lg_status { get; set; }
}
