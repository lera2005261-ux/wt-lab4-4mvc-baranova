using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_baranova.Models;

public class Product
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    [Required(ErrorMessage = "Укажите название товара.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Название должно содержать от 2 до 100 символов.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Категория")]
    [Required(ErrorMessage = "Укажите категорию товара.")]
    [StringLength(50, ErrorMessage = "Категория не должна превышать 50 символов.")]
    public string Category { get; set; } = string.Empty;

    [Display(Name = "Цена, руб.")]
    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть от 0.01 до 1 000 000.")]
    public decimal Price { get; set; }

    [Display(Name = "Товар в наличии")]
    public bool IsAvailable { get; set; }
}
