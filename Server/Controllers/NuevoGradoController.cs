using BlazorPablito.Server.Models;
using BlazorPablito.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPablito.Server.Controllers
{
    [ApiController]
    public class NuevoGradoController : Controller
    {
        [HttpGet]
        [Route("api/NuevoGrado/obtenerGrado/{idGrado}")]
        public GradoModel obtenerGrado(int idGrado)
        {
            GradoModel modelo = new GradoModel();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                modelo = (from tabla in db.Grado
                           where tabla.IdGrado == idGrado
                           select new GradoModel
                           {
                               IdGrado = tabla.IdGrado,
                               NombreGrado = tabla.NombreGrado,
                               IdSeccion = tabla.IdSeccion

                           }).First();

            }
            return modelo;
        }

        [HttpPost]
        [Route("api/NuevoGrado/Guardar")]
        public async Task<ActionResult<int>> Guardar(GradoModel oGrado)
        {

            int rpta = 0;
            try
            {

                using (nuevoRegistroContext db = new nuevoRegistroContext())
                {
                    Grado objeto = new Grado();
                    if (oGrado.IdGrado == 0)
                    {
                        objeto.NombreGrado = oGrado.NombreGrado;
                        objeto.IdSeccion = oGrado.IdSeccion;
                        db.Grado.Add(objeto);
                    }
                    else
                    {
                        Grado c = db.Grado.Where(c => c.IdGrado == oGrado.IdGrado).FirstOrDefault();
                        c.NombreGrado = oGrado.NombreGrado;
                        c.IdSeccion = oGrado.IdSeccion;
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
        [Route("api/NuevoGrado/EliminarGrado/{data?}")]
        public int EliminarGrado(string data)
        {
            int rpta = 0;
            try
            {
                using (nuevoRegistroContext db = new nuevoRegistroContext())
                {
                    int idGrado = int.Parse(data);
                    Grado modelo = db.Grado.Where(c => c.IdGrado == idGrado).First();
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

        [HttpGet]
        [Route("api/NuevoGrado/Get")]
        public List<GradoModel> Get()
        {
            List<GradoModel> lista = new List<GradoModel>();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                lista = (from tabla in db.Grado
                         select new GradoModel
                         {
                            IdGrado = tabla.IdGrado,
                            NombreGrado = tabla.NombreGrado,
                            IdSeccion = tabla.IdSeccion
                         }).ToList();
            }
            return lista;

        }

    }
}
