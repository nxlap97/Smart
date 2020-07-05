using Smart.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Media
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public long Size { get; set; }

        public DocumentType Type { get; set; }
    }
}
