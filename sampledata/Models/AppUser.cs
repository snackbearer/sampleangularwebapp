using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sampledata.Models
{
    [Table("User", Schema = "dbo")]
    public partial class AppUser
    {
        [Required()]
        [Key()]
        public int UserId { get; set; }

        [Required()]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required()]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
