using Smart.Core.Domain.Enums;
using Smart.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Settings")]
    public class Setting : ParentEntity<string>
    {
        [Required]
        [StringLength(128)]
        public string CustomerId {get;set;}

        [Required]
        [StringLength(128)]
        public string ObjectId {get;set;}

        public PageType PageType { get; set; }

        public SettingUI UI { get; set; }

        public SettingType Type { get; set; }

        public DateTime? Expired { get; set; }
    }
}
