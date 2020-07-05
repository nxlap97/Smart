﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Products
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
