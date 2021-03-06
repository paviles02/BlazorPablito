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
    public class GradoController : Controller
    {
        [HttpGet]
        [Route("api/Grado/Get")]
        public List<GradoModel> Get()
        {
            List<GradoModel> miLista = new List<GradoModel>();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                miLista = (from tabla in db.Grado
                           select new GradoModel
                           {
                               IdGrado = tabla.IdGrado,
                               NombreGrado = tabla.NombreGrado
                           }).ToList();
            }

            return miLista;
        }
    }
}
