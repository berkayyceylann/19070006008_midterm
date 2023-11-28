using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _19070006008_midterm.Models
{
    [Table("User")]
    public class CompanyUser
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Username")]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("Surname")]
        [MaxLength(50)]
        public string Surname { get; set; }

        
        [Column("Token")]
        public string Token { get; set; }
    }
}
