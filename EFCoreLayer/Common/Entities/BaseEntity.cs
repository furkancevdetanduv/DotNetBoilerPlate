

using System.ComponentModel.DataAnnotations;

namespace EFCoreLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
