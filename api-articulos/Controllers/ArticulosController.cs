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
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT Id FROM MARCAS WHERE Descripcion = @descripcion");
                datos.setearParametro("@descripcion", nuevoArticulo.Marca);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    articulo.Marca = new Marca();
                    articulo.Marca.IdMarca = (int)datos.Lector["Id"];
                    articulo.Marca.Descripcion = nuevoArticulo.Marca;
                }
                else
                {
                    return BadRequest("La marca indicada no existe en la base de datos. ");
                }
                datos.cerrarConexion();

                //Hago lo mismo con la Categoría
                datos = new AccesoDatos();
                datos.setearConsulta("SELECT Id FROM CATEGORIAS WHERE Descripcion = @descripcion");
                datos.setearParametro("@descripcion", nuevoArticulo.Categoria);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.IDCategoria = (int)datos.Lector["Id"];
                    articulo.Categoria.Descripcion = nuevoArticulo.Categoria;
                }
                else
                {
                    return BadRequest("La categoría indicada no existe en la base de datos.");
                }
                datos.cerrarConexion();

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

                ArticuloNegocio negocio = new ArticuloNegocio();
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
