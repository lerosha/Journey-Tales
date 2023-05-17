using Domain.DTO;
using Domain.Views.Lists;
using Domain.Views.Users;

namespace Domain.Extensions
{
    public static class ListExtensions
    {
        public static ListView ConvertToView(this List entity)
        {
            return new ListView()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                DestinationCity = entity.DestinationCity,
                DestinationCountry = entity.DestinationCountry,
            };
        }
        public static List ConvertToEntity(this CreateListView view)
        {
            return new List()
            {
                UserId = view.UserId,
                DestinationCity = view.DestinationCity,
                DestinationCountry = view.DestinationCountry,
            };
        }
        public static List ConvertToEntity(this UpdateListView view)
        {
            return new List()
            {
            };
        }
    }
}
