using Domain.DTO;
using Domain.Views.Notes;
using Domain.Views.Users;

namespace Domain.Extensions
{
    public static class NoteExtensions
    {
        public static NoteView ConvertToView(this Note entity)
        {
            return new NoteView()
            {
                Id = entity.Id,
                ListId = entity.ListId,
                Title = entity.Title,
            };
        }
        public static Note ConvertToEntity(this CreateNoteView view)
        {
            return new Note()
            {
                ListId = view.ListId,
                Title = view.Title,
            };
        }
        public static Note ConvertToEntity(this UpdateNoteView view)
        {
            return new Note()
            {

            };
        }
    }
}
