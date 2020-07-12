using Smart.Core.Domain.Enums;
using Smart.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Customers")]
    public class Customer :  ParentEntity<string>
    {
        [StringLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string Key { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(128)]
        public string Token { get; set; }

        public DateTime? TExpired { get; set; }

        public string IPAddress { get; set; }

        public CustomerType Type { get; set; }

        public CustomerStatus Status { get; set; }
    }
}
