using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Controllers.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? ean { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; } = default;
        public string? sku { get; set; }
        public CategoryAttribute? category { get; set; }
        public bool deleted { get; set; }
        public DateTime? createdAt { get; set; }
        public Guid created_by { get; set; }
        public DateTime? updatedAt { get; set; }
        public Guid updated_by { get; set; }

    }
}
