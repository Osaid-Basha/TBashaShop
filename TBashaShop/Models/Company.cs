using System.ComponentModel.DataAnnotations;

namespace TBashaShop.Models
{
    public class Company
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        
    }
}
