using Smart.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain.Configs
{
    [Table("Settings")]
    public class Setting
    {
        [Key]
        [Required]
        [StringLength(128)]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string CustomerId {get;set;}

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string ObjectId {get;set;}

        public PageType PageType { get; set; }

        public SettingUI UI { get; set; }

        public SettingType Type { get; set; }

        public DateTime? Expired { get; set; }
    }
}
