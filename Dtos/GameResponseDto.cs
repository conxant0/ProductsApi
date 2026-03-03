namespace ProductsApi.Dtos;

public class GameResponseDto
{
    public int Id { get; set; }
    public string GameName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal HoursSpent { get; set; }
    public decimal ValueScore => HoursSpent == 0 ? 0 : Math.Round(Price / HoursSpent, 2);
}
