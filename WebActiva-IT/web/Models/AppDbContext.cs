using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class AppDbContext:DbContext
    {
        //ct, pasamos la cadena de conexion 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AlbumFavorites> AlbumFavorites { get; set; }   

        //damo a conocer que existe una tabla llamada Amigo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlbumFavorites>().ToTable("AlbumFavorites");
        }
    }
}
