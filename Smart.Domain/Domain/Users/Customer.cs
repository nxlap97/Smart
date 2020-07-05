using Smart.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Users
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string UserName { get; set; }

        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string Key { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Token { get; set; }

        public DateTime? TExpired { get; set; }

        public string IPAddress { get; set; }

        public CustomerType Type { get; set; }

        public CustomerStatus Status { get; set; }
    }
}
