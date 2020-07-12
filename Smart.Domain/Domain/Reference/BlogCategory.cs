using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("BlogCategories")]
    public class BlogCategory : ParentEntity<string>
    {
        [Required]
        [StringLength(128)]
        public string BlogId { get; set; }

        [Required]
        [StringLength(128)]
        public string CategoryId { get; set; }
    }
}
