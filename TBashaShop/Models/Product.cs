using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TBashaShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
        public string Description { get; set; }

        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000.")]
        public decimal Price { get; set; }

        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
        public double Rate { get; set; }

        [Range(0, 500, ErrorMessage = "Quantity must be between 0 and 500.")]
        public double Quantity { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100%.")]
        public int Discount { get; set; }

        [RegularExpression(@".*\.(png|jpg|jpeg)$", ErrorMessage = "Only PNG, JPG or JPEG images are allowed.")]
        public string ? Image { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        public int CompanyId {  get; set; }
        [ValidateNever]
        public Company Company { get; set; }
    }
}
