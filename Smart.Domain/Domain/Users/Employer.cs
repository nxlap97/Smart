
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Users
{
    [Table("Employers")]
    public class Employer
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Phone { get; set; }

        public DateTime  BirthDay { get; set; }

        public string  Address { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string  IdentityCard { get; set; }
    }
}
