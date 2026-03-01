namespace ProductsApi.Models;

public class Game
{
    public int Id { get; set; }
    public string GameName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal HoursSpent { get; set; }
}
