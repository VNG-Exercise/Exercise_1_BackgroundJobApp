using System.ComponentModel.DataAnnotations;

namespace Exercise_1_BackgroundJobApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Status { get; set; }
        public DateTime LastUpdatePwd { get; set; }
    }
}
