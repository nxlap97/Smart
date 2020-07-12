using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("AttachFiles")]
    public class AttachFile :  ParentEntity<string>
    {
        [Required]
        [StringLength(128)]   
        public string ObjectId { get; set; }

        [Required]
        [StringLength(128)] 
        public string DocId { get; set; }
    }
}
