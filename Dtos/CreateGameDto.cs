using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Dtos;

public class CreateGameDto
{
    [Required]
    [MinLength(1, ErrorMessage = "GameName cannot be empty.")]
    public string GameName { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "HoursSpent cannot be negative.")]
    public decimal HoursSpent { get; set; }
}
