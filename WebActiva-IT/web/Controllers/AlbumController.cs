using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using web.Models;

namespace web.Controllers
{
    public class AlbumController : Controller
    {
        Servicio s = new Servicio(); //instancia conexion api servicio
        //private SqlRepositorio repositorio;  //instancia db conexion 
        private IAlbumFavorites albumFavorites;


        public AlbumController(IAlbumFavorites iAlbumFavorites)
        {
            albumFavorites = iAlbumFavorites;
        }

        // GET: AlbumController
        public async Task<IActionResult> Index()
        {
            List<Album> albums = new List<Album>();
            HttpClient client = s.Initial();
            HttpResponseMessage res = await client.GetAsync("/albums");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                albums = JsonConvert.DeserializeObject<List<Album>>(results);
            }

            return View(albums);
        }

        // GET: AlbumController/Details/5
        public async Task<IActionResult> Details (int id)
        {
            List<AlbumDetails> albumsDetails = new List<AlbumDetails>();
            HttpClient client = s.Initial();
            HttpResponseMessage res = await client.GetAsync("/albums/"+id+"/photos");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                albumsDetails = JsonConvert.DeserializeObject<List<AlbumDetails>>(results);
            }

            return View(albumsDetails);
        }

        //GET: AlbumController/Agregate/5
        public ActionResult Agregate(int id,string title,int albumId)
        {
            if (ModelState.IsValid)
            {
                AlbumFavorites a = new AlbumFavorites();
                a.Id = id;
                a.Title = title;
                a.IdAlbum = albumId;

                return View(a);
            }
            return View();
        }
        AlbumFavorites af = new AlbumFavorites();
        // POST: AlbumController/Agregate/5/title/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregate(int id,string title,int idAlbum, AlbumFavorites album)
        {
            try
            {
               
                //af.Id = id;
                //af.Title = title;
                //af.IdAlbum = albumId;

                albumFavorites.Agregar( id,  title, idAlbum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/ConsultarAlbumsFavorites
        public ActionResult ConsultarAlbumsFavorites()
        {
            try
            {
                List<AlbumFavorites> list = albumFavorites.ConsultarAlbumFavorites();
                return View(list);
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            AlbumFavorites a = albumFavorites.ConsultarAlbumFavoritesId(id);
            return View(a);
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlbumFavorites a)
        {
            try
            {
                albumFavorites.Eliminar(a.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
