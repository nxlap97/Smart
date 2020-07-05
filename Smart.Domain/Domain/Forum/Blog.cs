using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Forum
{
    [Table("Blogs")]
    public class Blog
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }


        public string Description { get; set; }

        public string ShortDescription { get; set; }
    }
}
