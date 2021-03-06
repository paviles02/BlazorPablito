using BlazorPablito.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPablito.Server.Controllers
{

    [ApiController]

    public class HomeController : Controller
    {

        [HttpGet]
        [Route("api/Home/Ejemplo")]
        public String Ejemplo()
        {
            //Func<int, string> mayoriaEdad = EvaluarEdad;
            //string salida = mayoriaEdad(24);
            String salida = "Hola Pablito";
            return salida;
        }


        [HttpGet]
        [Route("api/Home/ResultadoMayuscula")]
        public String ResultadoMayuscula()
        {

            String salida = "Programacion Net Core";
            return salida.ToUpper();
        }

        [HttpGet]
        [Route("api/Home/ejecutarConsulta")]
        public int EjecutarConsulta()
        {
            int resultado = 0;
            using (nuevoRegistroContext db = new nuevoRegistroContext())
            {
                Facultad objeto = new Facultad();
                objeto.NombreFacultad = "Economia.";
                db.Facultad.Add(objeto);
                db.SaveChanges();

            }

            return resultado;
        }


    }
}
