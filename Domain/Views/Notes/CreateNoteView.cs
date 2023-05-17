using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Notes
{
    public class CreateNoteView
    {
        public Guid ListId {get; set;}

        public string Title { get; set; } = null!;
    }
}
