using Microsoft.AspNetCore.Mvc;
using MvcApuestasLto.Models;
using MvcApuestasLto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Controllers
{
    public class EquiposController : Controller
    {
        private RepositoryChampions repo;

        public EquiposController(RepositoryChampions repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Equipos equipos = this.repo.GetEquiposId(id);
            return View(equipos);
        }

        public IActionResult Equipos()
        {
            List<Equipos> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
    }
}
