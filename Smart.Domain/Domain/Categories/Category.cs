using Smart.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Categories
{

    [Table("Categories")]
    public class Category
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public CategoryType Type { get; set; }
    }
}
