using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace store2.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "Id")]
        public int? Id { get; set; }
        [Display(Name = "Prodect Name")]
        [Column(TypeName = "varchar(200)")]
        public string? ProdectName { get; set; }
        [Display(Name = "Image Prodect")]
        [Column(TypeName = "varchar(200)")]
        public string? ProdectImage { get; set; }
        [Display(Name = "Prodect Description")]
        [Column(TypeName = "varchar(200)")]
        public string ProdectDescription { get; set; } 
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
