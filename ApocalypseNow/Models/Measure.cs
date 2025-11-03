using SQLite;

namespace ApocalypseNow.Models;

[Table("Measures")]
public class Measure
{
    [PrimaryKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int CatastropheTypeId { get; set; } // FK -> CatastropheTypes.Id
    public int Priority { get; set; } // numeric priority for measure
}
