namespace Core.Entities;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Make Make { get; set; } = null!;
    public int MakeId { get; set; }
}
