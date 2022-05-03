using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcApuestasLto.Models;
using MvcApuestasLto.Repositories;
using MvcApuestasLto.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoryChampions repo;
        private ServiceS3 services;

        public JugadoresController(RepositoryChampions repo,ServiceS3 services)
        {
            this.services = services;
            this.repo = repo;
        }


        public IActionResult Jugadoress()
        {
            List<Jugadores> jugad = this.repo.GetJugadores();
            return View(jugad);
        }

        public IActionResult Details(int id)
        {
            Jugadores juga = this.repo.GetJugadoresId(id);
            return View(juga);
        }
        /*
                public IActionResult Create()
                {
                    return View();
                }

                [HttpPost]

                public IActionResult Create(Jugadores juga)
                {
                    this.repo.CrearJugador(juga.Nombre, juga.Posicion, juga.Imagen, juga.FechaNacimiento, juga.Pais, juga.IdEquipo);
                    return View("Jugadoress");
                }*/


        public IActionResult Createjuga()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Createjuga(Jugadores jugadores, IFormFile ImagenBBDD)
        {
            string extension = ImagenBBDD.FileName.Split(".")[1];
            string fileName = jugadores.Nombre.Trim() + "." + extension;
            using (Stream stream = ImagenBBDD.OpenReadStream())
            {
                await this.services.UploadFileAsync(stream, fileName);
            }
            jugadores.Imagen = fileName;

           this.repo.CrearJugador(jugadores.Nombre,jugadores.Posicion,jugadores.Imagen,jugadores.FechaNacimiento,jugadores.Pais,jugadores.IdEquipo);
            
            return RedirectToAction("Jugadoress");
        }

    }
}
