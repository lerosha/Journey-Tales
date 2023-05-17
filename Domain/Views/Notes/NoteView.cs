using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Notes
{
    public class NoteView
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; } = null!;
    }
}
