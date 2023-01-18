using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetBoilerPlate.EF.Common.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime UpdatedTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
    }
}
