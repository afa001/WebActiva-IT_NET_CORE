using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AlbumFavorites
    {
        public int Id { get; set; } //idAlbumFavorites
        public string Title { get; set; }
        public int IdAlbum { get; set; }
    }
}
