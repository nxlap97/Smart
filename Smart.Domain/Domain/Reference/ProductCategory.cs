using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("ProductCategories")]
    public class ProductCategory : ParentEntity<string>
    {
        [Required]
        [StringLength(128)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(128)]
        public string CategoryId { get; set; }
    }
}
