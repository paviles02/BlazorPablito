using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPablito.Client.Repositorio
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
