using Smart.Core.Enums;
using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Categories")]
    public class Category : ParentEntity<string>
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public CategoryType Type { get; set; }
    }
}
