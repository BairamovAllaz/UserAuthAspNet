namespace FirstAPI.App.Models;
public class User : ICloneable
{
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public int Age { get; set; }
    public string Adress{ get; set; }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}