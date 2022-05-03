using Microsoft.AspNetCore.Mvc;
using MvcApuestasLto.Models;
using MvcApuestasLto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Controllers
{
    public class ApuestasController : Controller
    {

        private RepositoryChampions repo; 

        public ApuestasController(RepositoryChampions repo)
        {
            this.repo = repo;
        }


        public IActionResult Apuestas()
        {
            List<Apuestas> apues = this.repo.GetApuestas();
            return View(apues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Apuestas apues)
        {
            this.repo.CreateApuesta(apues.Usuario, apues.IdEquipolocal, apues.IdEquipovisitante, apues.Golesequipolocal, apues.GolesEquipoVisitante);
            return View("Apuestas");
        }


    }
}
