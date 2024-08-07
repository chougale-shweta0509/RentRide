using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace RentRideProject.Web.Utility
   
{
    public class PageInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage => (int)Math.Ceiling ((double)TotalItems / ItemsPerPage);

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalItems;




    }
}
