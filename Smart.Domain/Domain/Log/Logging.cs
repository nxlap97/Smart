using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Loggings")]
    public class Logging : ParentEntity<string>
    {
        public string Error { get; set; }

        [StringLength(128)]
        public string Entity { get; set; }
    }
}
