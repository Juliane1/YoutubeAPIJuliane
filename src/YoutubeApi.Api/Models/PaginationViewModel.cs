using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeApi.Api.Models
{
    public class PaginationViewModel
    {
        public string Search { get; set; }

        public bool IsFavorite => false;

        public string NextPage { get; set; }

        public List<SearchViewModel> Searches { get; set; }
    }
}
