using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TBashaShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@".*\.(png|jpg|jpeg)$", ErrorMessage = "Only PNG, JPG or JPEG images are allowed.")]
        public string? Image { get; set; }
        [ValidateNever]
        public List<Product> Products { get; set; }

    }
}
