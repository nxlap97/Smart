using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Log
{
    [Table("Loggings")]
    public class Logging
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        public string Error { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Entity { get; set; }
    }
}
