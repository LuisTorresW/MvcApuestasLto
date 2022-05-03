using MvcApuestasLto.Data;
using MvcApuestasLto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasLto.Repositories
{
    public class RepositoryChampions
    {
        private ChampionsContext context;

        public RepositoryChampions(ChampionsContext context)
        {
            this.context = context;
        }

        public List<Apuestas> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }

        public List<Jugadores> GetJugadores()
        {
            return this.context.Jugadores.ToList();
        }

        public Jugadores GetJugadoresId(int id)
        {
            return this.context.Jugadores.SingleOrDefault(z => z.IdJugador == id);

        }

        public List<Equipos> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }

        public Equipos GetEquiposId(int id)
        {
            return this.context.Equipos.SingleOrDefault(z => z.IdEquipo == id);
        }

        public int IdMaxApuesta()
        {
            int maximo = this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            return maximo;
        }


        public int IdMaxJugador()
        {
            int maximo = this.context.Jugadores.Max(z => z.IdJugador) + 1;
            return maximo;
        }



        public void CreateApuesta(/*int idapuesta,*/ string usuario, int idequipolocal, int idequipovisitante, int goleslocal, int golesvisitante)
        {
            Apuestas apuestas = new Apuestas();
            apuestas.IdApuesta = this.IdMaxApuesta();
            apuestas.Usuario = usuario;
            apuestas.IdEquipolocal = idequipolocal;
            apuestas.IdEquipovisitante = idequipovisitante;
            apuestas.Golesequipolocal = goleslocal;
            apuestas.GolesEquipoVisitante = golesvisitante;
            this.context.Apuestas.Add(apuestas);
            this.context.SaveChanges();
        }

        public void CrearJugador(/*int idjugador,*/ string nombre, string posicion, string imagen, string nacimiento, string pais, int idequipo)
        {
            Jugadores jugadores = new Jugadores();
            jugadores.IdJugador = this.IdMaxJugador();
            jugadores.Nombre = nombre;
            jugadores.Posicion = posicion;
            jugadores.Imagen = imagen;
            jugadores.FechaNacimiento = nacimiento;
            jugadores.Pais = pais;
            jugadores.IdEquipo = idequipo;
            this.context.Jugadores.Add(jugadores);
            this.context.SaveChanges();
        }

    }
}
