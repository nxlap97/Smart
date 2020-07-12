using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Blogs")]
    public class Blog : ParentEntity<string>
    {
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }
    }
}
