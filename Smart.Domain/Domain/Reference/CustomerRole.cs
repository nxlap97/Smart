using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Reference
{
    [Table("CustomerRoles")]
    public class CustomerRole
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string RoleId { get; set; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string CustomerId { get; set; }


    }
}
