using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class SqlRepositorio:IAlbumFavorites
    {
        //prop
        private readonly AppDbContext contexto;  //conexion bd

        //ct 
        public SqlRepositorio(AppDbContext _contexto)
        {
            this.contexto = _contexto;
        }

        public List<AlbumFavorites> ConsultarAlbumFavorites()
        {
            return contexto.AlbumFavorites.ToList<AlbumFavorites>();
        }

  
        public AlbumFavorites Agregar(int id, string title, int idAlbum)
        {
            AlbumFavorites af = new AlbumFavorites();
            af.Id = id;
            af.Title = title;
            af.IdAlbum = idAlbum;

            contexto.AlbumFavorites.Add(af);
            contexto.SaveChanges();

            return af;
        }

        public AlbumFavorites Eliminar(int id)
        {
            AlbumFavorites a = contexto.AlbumFavorites.Find(id);
            if (a != null)
            {
                contexto.AlbumFavorites.Remove(a);
                contexto.SaveChanges();
            }
            return a;
        }

        public AlbumFavorites ConsultarAlbumFavoritesId(int id)
        {
            return contexto.AlbumFavorites.Find(id);
        }
    }
}
