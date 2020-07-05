using Smart.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smart.Core.Domain
{
    public class Product : ParentEntity<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }
    }
}
