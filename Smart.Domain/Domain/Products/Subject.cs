using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Subjects")]
    public class Subject : ParentEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
