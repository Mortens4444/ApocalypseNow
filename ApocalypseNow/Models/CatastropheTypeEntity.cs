using SQLite;

namespace ApocalypseNow.Models;

[Table("CatastropheTypes")]
public class CatastropheTypeEntity
{
    [PrimaryKey]
    public int Id { get; set; } // matches CatastropheType enum values
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}