using Smart.Core.Domain.Enums;
using Smart.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Core.Domain
{
    [Table("Documents")]
    public class Document : ParentEntity<string>
    {
        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public long Size { get; set; }

        public DocumentType Type { get; set; }
    }
}
