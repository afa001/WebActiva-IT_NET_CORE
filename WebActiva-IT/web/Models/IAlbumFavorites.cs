using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public interface IAlbumFavorites
    {
        List<AlbumFavorites> ConsultarAlbumFavorites();
        AlbumFavorites ConsultarAlbumFavoritesId(int id);
        AlbumFavorites Agregar(int id, string title, int albumId);
        AlbumFavorites Eliminar(int id);
    }
}
