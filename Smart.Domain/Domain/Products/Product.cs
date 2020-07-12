using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Products")]
    public class Product : ParentEntity<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }
    }
}
