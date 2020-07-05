using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Reference
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string ProductId { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string CategoryId { get; set; }
    }
}
