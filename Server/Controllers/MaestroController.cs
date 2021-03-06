using BlazorPablito.Server.Models;
using BlazorPablito.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPablito.Server.Controllers
{
    
    [ApiController]

    public class MaestroController : ControllerBase
    {

        [HttpGet]
        [Route("api/Maestro/Get")]
        public List<MaestroModel> Get()
        {
            List<MaestroModel> miLista = new List<MaestroModel>();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                miLista = (from tabla in db.Maestro
                           select new MaestroModel
                           {
                               IdMaestro = tabla.IdMaestro,
                               NombreMaestro = tabla.NombreMaestro
                           }).ToList();
            }

            return miLista;
        }


        [HttpGet]
        [Route("api/Maestro/Filtrar/{data}")]
        public List<MaestroModel> Filtrar(string data)
        {
            List<MaestroModel> miLista = new List<MaestroModel>();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                miLista = (from tabla in db.Maestro
                           where tabla.NombreMaestro.Contains(data)
                           select new MaestroModel
                           
                           {
                               IdMaestro = tabla.IdMaestro,
                               NombreMaestro = tabla.NombreMaestro
                           }).ToList();
            }

            return miLista;
        }



        [HttpGet]
        [Route("api/Maestro/obtenerMaestro/{idMaestro}")]
        public MaestroModel obtenerMaestro(int idMaestro)
        {
            MaestroModel modelo = new MaestroModel();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                modelo = (from tabla in db.Maestro
                          where tabla.IdMaestro == idMaestro
                          select new MaestroModel
                          {
                              IdMaestro = tabla.IdMaestro,
                              NombreMaestro = tabla.NombreMaestro

                          }).First();

            }
            return modelo;
        }



        [HttpPost]
        [Route("api/Maestro/Guardar")]
        public async Task<ActionResult<int>> Guardar(MaestroModel oMaestro)
        {

            int rpta = 0;
            try
            {

                using (nuevoRegistroContext db = new nuevoRegistroContext())
                {
                    Maestro objeto = new Maestro();
                    if (oMaestro.IdMaestro == 0)
                    {
                        objeto.NombreMaestro = oMaestro.NombreMaestro;
                        db.Maestro.Add(objeto);
                    }
                    else
                    {
                        Maestro c = db.Maestro.Where(c => c.IdMaestro == oMaestro.IdMaestro).FirstOrDefault();
                        c.NombreMaestro = oMaestro.NombreMaestro;
                        
                    }
                    await db.SaveChangesAsync();
                    rpta = 1;
                }


            }
            catch (Exception)
            {
                rpta = 0;
            }
            return rpta;
        }

        [HttpGet]
        [Route("api/Maestro/EliminarMaestro/{data?}")]
        public int EliminarMaestro(string data)
        {
            int rpta = 0;
            try
            {
                using (nuevoRegistroContext db = new nuevoRegistroContext())
                {
                    int idMaestro = int.Parse(data);
                    Maestro modelo = db.Maestro.Where(c => c.IdMaestro == idMaestro).First();
                    db.Attach(modelo);
                    db.Remove(modelo);
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }

    }
}
