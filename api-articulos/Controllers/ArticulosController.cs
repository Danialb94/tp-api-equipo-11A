using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dominio;
using negocio;
using api_articulos.Models;

namespace api_articulos.Controllers
{
    public class ArticulosController : ApiController
    {
        // GET: api/Articulos
        public IEnumerable<ArticuloDTO> Get()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = negocio.listar();

                List<ArticuloDTO> listaDTO = listaArticulos.Select(a => new ArticuloDTO
                {
                    Id = a.IdArticulo,
                    Nombre = a.Nombre,
                    Codigo = a.Codigo,
                    Descripcion = a.Descripcion,
                    Marca = a.Marca != null ? a.Marca.Descripcion : "",
                    Categoria = a.Categoria != null ? a.Categoria.Descripcion : "",
                    Precio = a.Precio,
                    Imagenes = a.Imagenes != null ? a.Imagenes.Select(img => img.urlImagen).ToList() : new List<string>()
                }).ToList();

                return listaDTO;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(
                    System.Net.HttpStatusCode.InternalServerError
                );
            }

        }
        // GET: api/Articulos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articulos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
        }
    }
}
