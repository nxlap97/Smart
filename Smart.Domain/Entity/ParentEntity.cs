using System;
using System.ComponentModel.DataAnnotations;

namespace Smart.Domain.Entity
{
    public class ParentEntity<T>
    {
        public ParentEntity()
        {
            if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(Id?.ToString()))
                {
                    Id = (T)(object)(Guid.NewGuid().ToString());
                }
            }
                
        }

        [Key]
        [Required]
        [MaxLength(128)]
        public T Id { get; set; }
    }
}
