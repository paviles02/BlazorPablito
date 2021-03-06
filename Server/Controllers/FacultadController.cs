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
    public class FacultadController : Controller
    {
        [HttpGet]
        [Route("api/Facultad/Get")]
        public List<FacultadModel> Get()
        {
            List<FacultadModel> miLista = new List<FacultadModel>();
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                miLista = (from tabla in db.Facultad
                           select new FacultadModel
                           {
                               IdFacultad = tabla.IdFacultad,
                               NombreFacultad = tabla.NombreFacultad
                           }).ToList();
            }

            return miLista;
        }
    }
}
