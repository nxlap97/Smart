using Smart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain
{
    [Table("Permisions")]
    public class Permision : ParentEntity<string>
    {
        public string Name { get; set; }
        public string ICon { get; set; }
        public string Link { get; set; }
        public bool IsNewTab { get; set; }
        public string ColorText { get; set; }
    }
}
