using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models;

public class Item
{
    public int Id { get; set; }
    // UNLIKE string?, = null!; tell the complier that you
    // do not want property Name to be null. Instead, you want
    // to see the Name property to null now but in the future,
    // you promise to change it later
    public string Name { get; set; } = null!;
    public string? Color { get; set; }
    public float Price { get; set; }
    // BELOW TWO PROPERTIES ARE NULL BECAUSE WE DO NOT 
    // HAVE TO SPECIFY THEM AS SOON AS CLASS INSTANCE
    // IS CREATED
    public int? SerialNumberId { get; set; }
    public SerialNumber? SerialNumber { get; set; }

    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    public List<ItemClient>? ItemClients { get; set; }


}
