using System.ComponentModel.DataAnnotations;

namespace Smart.Domain.Entity
{
    public class ParentEntity<T>
    {
        public ParentEntity()
        {
            var type = Id.GetType();

        }

        [Key]
        [Required]
        [MaxLength(128)]
        public T Id { get; set; }
    }
}
