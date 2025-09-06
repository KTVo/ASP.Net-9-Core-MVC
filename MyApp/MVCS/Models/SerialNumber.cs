using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.MVCS.Models;

public class SerialNumber
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ItemId { get; set; }
    // [ForeignKey("ItemId")] MEANS YOU'RE USING THE ItemId ABOVE 
    // TO SET IT AS A FOREIGN KEY FOR TO THE Item PROPERTY BELOW
    [ForeignKey("ItemId")]
    public Item? Item { get; set; }
}
