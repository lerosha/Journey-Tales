using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class List : DataEntity
    {
        [Required]
        [Column("destinationcountry")]
        public string? DestinationCountry { get; set; }
        [Required]
        [Column("destinationcity")]
        public string? DestinationCity { get; set; }
        [Required]
        [Column("notecount")]
        public int NoteCount { get; set; }
        [Required]
        [Column("userid")]
        public Guid UserId { get; set; }

        public List<Note>? Notes { get; set; } = new List<Note>();
    }
}
