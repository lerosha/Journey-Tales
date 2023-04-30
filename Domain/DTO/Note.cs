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
        public string Title { get; set; }
        [Column("text")]
        public string? Text { get; set; }
        [Column("tags")]
        public string? Tags { get; set; }
        [Column("budget")]
        public decimal Budget { get; set; }

        //public Guid UserId { get; set; }
        [ForeignKey("listid")]
        public Guid ListId { get; set; }
    }
}
