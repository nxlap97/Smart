using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Domain.Entity
{
    public class ParentEntity<T>
    {
        [Key]
        [Required]
        public T Id { get; set; }
    }
}
