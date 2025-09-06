namespace MyApp.MVCS.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    // public string Description { get; set; } 
    public List<ItemClient>? ItemClients { get; set; }
}
