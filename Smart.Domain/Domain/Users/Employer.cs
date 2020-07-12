using Smart.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Employers")]
    public class Employer :  ParentEntity<string>
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime  BirthDay { get; set; }

        public string  Address { get; set; }

        [StringLength(50)]
        public string  IdentityCard { get; set; }
    }
}
