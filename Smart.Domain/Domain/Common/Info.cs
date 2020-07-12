using Smart.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Infos")]
    public class Info : ParentEntity<string>
    {
        [StringLength(128)]
        [Required]
        public string ObjectId { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool Published { get; set; }
    }
}
