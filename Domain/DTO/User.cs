using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class User : DataEntity
    {
        [Column("username")]
        public string? Username { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        public List<List>? Lists { get; set; } = new List<List>();

        //public List<Note>? Notes { get; set; } = new List<Note>();
    }
}
