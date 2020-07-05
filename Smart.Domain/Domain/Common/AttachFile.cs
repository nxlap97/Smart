using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Common
{
    [Table("AttachFiles")]
    public class AttachFile
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string ObjectId { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string DocId { get; set; }
    }
}
