using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain
{
    [Table("CustomerRoles")]
    public class CustomerRole
    {
        [Key]
        [Required]
        [StringLength(128)]
        
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        
        public string RoleId { get; set; }

        [Required]
        [StringLength(128)]
        
        public string CustomerId { get; set; }


    }
}
