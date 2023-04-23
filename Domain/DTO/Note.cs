using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Note : DataEntity
    {
        [Required]
        [Column("title")]
        public string? Title { get; set; }
        [Required]
        [Column("text")]
        public string? Text { get; set; }
        [Required]
        [Column("tags")]
        public string? Tags { get; set; }
        [Required]
        [Column("budget")]
        public decimal Budget { get; set; }
        [Required]
        [Column("userid")]
        public Guid UserId { get; set; }

        public int ListId { get; set; }
    }
}
