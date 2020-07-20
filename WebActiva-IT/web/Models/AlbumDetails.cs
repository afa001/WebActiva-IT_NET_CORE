    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AlbumDetails
    {
        public int AlbumId { get; set; } //id album
        public int Id { get; set; } //id detalle album (cancion)
        public string Title { get; set; }
        public string Url { get; set; }
        public string thumbnailUrl { get; set; }

        List<Album> ListAlbums = new List<Album>();
    }
}
