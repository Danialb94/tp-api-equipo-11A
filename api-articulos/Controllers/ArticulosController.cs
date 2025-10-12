using api_articulos.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using dominio;
using negocio;
using System.Security.Cryptography.X509Certificates;

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
        public IHttpActionResult Get(int id)
        {
            if (id < 0) return BadRequest("El valor para ID es incorrecto.");
            try
            {
                ArticuloNegocio negArticulo = new ArticuloNegocio();
                if (!negArticulo.existeArticulo(id)) return BadRequest("No existe un artículo con ese ID");

                Articulo seleccionado = new Articulo();
                List<Articulo> lista = new List<Articulo>();
                lista = negArticulo.listar();
                seleccionado = lista.Find(x => x.IdArticulo == id);
                if (seleccionado == null) return NotFound();

                ArticuloDTO articulo = new ArticuloDTO();
                articulo.Id = seleccionado.IdArticulo;
                articulo.Nombre = seleccionado.Nombre;
                articulo.Descripcion = seleccionado.Descripcion;
                articulo.Marca = seleccionado.Marca.Descripcion;
                articulo.Categoria = seleccionado.Categoria.Descripcion;
                articulo.Precio = seleccionado.Precio;
                if (seleccionado.Imagenes != null)
                {
                    articulo.Imagenes = new List<string>();
                    for (int i = 0; i < seleccionado.Imagenes.Count; i++)
                    {
                        articulo.Imagenes.Add(seleccionado.Imagenes[i].urlImagen);
                    }
                }
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Articulos
        public IHttpActionResult Post([FromBody] ArticuloDTO nuevoArticulo)
        {
            try
            {
                // Valido que el cliente me haya mandado datos.
                // Si el objeto "nuevoArticulo" está vacío (null),
                // devuelvo un mensaje de error al cliente.
                if (nuevoArticulo == null)
                {
                    return BadRequest("No se enviaron datos del producto.");
                }

                // Creo un objeto del dominio(Articulo)
                Articulo articulo = new Articulo();
                articulo.Codigo = nuevoArticulo.Codigo;
                articulo.Nombre = nuevoArticulo.Nombre;
                articulo.Descripcion = nuevoArticulo.Descripcion;
                articulo.Precio = nuevoArticulo.Precio;

                //Obtengo el Id de la Marca desde la base de datos usando su descripción
                ArticuloNegocio negocio = new ArticuloNegocio();
                articulo.Marca = new Marca();
                articulo.Marca.IdMarca = negocio.ObtenerIdMarca(nuevoArticulo.Marca);

                //Hago lo mismo con la Categoría
                articulo.Categoria = new Categoria();
                articulo.Categoria.IDCategoria = negocio.ObtenerIdCategoria(nuevoArticulo.Categoria);

                //Creo la lista de imágenes
                List<Imagen> listaImg = new List<Imagen>();
                if (nuevoArticulo.Imagenes != null)
                {
                    foreach (var url in nuevoArticulo.Imagenes)
                    {
                        Imagen img = new Imagen();
                        img.urlImagen = url;
                        listaImg.Add(img);
                    }
                }
                negocio.agregar(articulo, listaImg);

                return Ok("Producto agregado correctamente.");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // PUT: api/Articulos/5
        public void Put(int id, [FromBody] ArticuloDTO art)
        {
            try
            {
                if (art == null)
                    throw new ArgumentNullException(nameof(art), "El cuerpo de la solicitud no puede estar vacío.");

                bool existiaImg = art.Imagenes != null && art.Imagenes.Any();

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevo = new Articulo();
                nuevo.Codigo = art.Codigo;
                nuevo.Nombre = art.Nombre;
                nuevo.Descripcion = art.Descripcion;
                nuevo.Marca = new Marca { IdMarca = negocio.ObtenerIdMarca(art.Marca) };
                nuevo.Categoria = new Categoria { IDCategoria = negocio.ObtenerIdCategoria(art.Categoria) };

                nuevo.Imagenes = new List<Imagen>();

                if (art.Imagenes != null)
                {
                    foreach (var url in art.Imagenes)
                    {
                        nuevo.Imagenes.Add(new Imagen { urlImagen = url });
                    }
                }

                nuevo.IdArticulo = id;

                negocio.modificarArticulo(nuevo, nuevo.Imagenes, existiaImg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en PUT: {ex.Message}");
            }
        }


        // DELETE: api/Articulos/5
        public void Delete(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminarArticulo(id);
        }
    }
}
