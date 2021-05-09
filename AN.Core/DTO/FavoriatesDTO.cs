using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class FavoriatesDTO
    {
        public List<FavoriteItem> Favorites { get; set; }
    }

    public class FavoriteItem
    {
        public int ServiceSupplyId { get; set; }
        public int? CenterServiceId { get; set; }
    }
}
