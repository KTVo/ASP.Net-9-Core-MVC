namespace MyApp.Models;

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Color { get; set; }
    public float? Price { get; set; }
}
