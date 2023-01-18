using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetBoilerPlate.EF.Common.Entities
{
    public class User : BaseEntity
    {
        
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
