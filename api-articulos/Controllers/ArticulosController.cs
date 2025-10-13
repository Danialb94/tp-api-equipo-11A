using api_articulos.Models;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace api_articulos.Controllers
{
    public class ArticulosController : ApiController
    {
        private bool ExistenLetras(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter))
                    return true;
            }
            return false;
        }
        bool EsUrlValida(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

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
        public IHttpActionResult Post([FromBody] ArticuloDTOPost nuevoArticulo)
        {
            try
            {
                // Valido que el cliente me haya mandado datos.
                // Si el objeto "nuevoArticulo" está vacío (null),
                // devuelvo un mensaje de error al cliente.
                if (nuevoArticulo == null) return BadRequest("No se enviaron datos del producto.");
                if (string.IsNullOrWhiteSpace(nuevoArticulo.Nombre) || string.IsNullOrWhiteSpace(nuevoArticulo.Codigo)) return BadRequest("Hay datos vacíos.");
                if (!ExistenLetras(nuevoArticulo.Nombre)) return BadRequest("El nombre no pueden ser solo números.");
                if (!string.IsNullOrWhiteSpace(nuevoArticulo.Descripcion))
                {
                    if (!ExistenLetras(nuevoArticulo.Descripcion)) return BadRequest("La descripcion no pueden ser solo números.");
                }
                if (nuevoArticulo.Precio < 1) return BadRequest("El precio no puede ser menor a un peso >:c");

                // Creo un objeto del dominio(Articulo)
                Articulo articulo = new Articulo();
                articulo.Codigo = nuevoArticulo.Codigo;
                articulo.Nombre = nuevoArticulo.Nombre;
                articulo.Descripcion = nuevoArticulo.Descripcion;
                articulo.Precio = nuevoArticulo.Precio;

                //Obtengo el Id de la Marca desde la base de datos usando su descripción
                ArticuloNegocio negocio = new ArticuloNegocio();
                MarcaNegocio marcaNeg = new MarcaNegocio();


                //Marca
                articulo.Marca = new Marca();
                if (string.IsNullOrWhiteSpace(nuevoArticulo.Marca)) return BadRequest("La marca no puede estar vacía.");
                MarcaNegocio negMarca = new MarcaNegocio();
                int idMarca;
                if (int.TryParse(nuevoArticulo.Marca, out idMarca))
                {
                    bool marcaExistente = negMarca.ExisteIdMarca(idMarca.ToString());
                    if (!marcaExistente)
                        return BadRequest("La marca especificada no existe.");
                    articulo.Marca = new Marca { IdMarca = idMarca };
                }
                else
                {
                    bool marcaExistente = negMarca.ExisteMarca(nuevoArticulo.Marca);
                    if (!marcaExistente)
                        return BadRequest("La marca especificada no existe");
                    articulo.Marca = new Marca { IdMarca = negocio.ObtenerIdMarca(nuevoArticulo.Marca) };
                }

                //Hago lo mismo con la Categoría
                CategoriaNegocio cartegNeg = new CategoriaNegocio();
                articulo.Categoria = new Categoria();
                if (string.IsNullOrWhiteSpace(nuevoArticulo.Categoria)) return BadRequest("La categoría no puede estar vacía");
                CategoriaNegocio catNeg = new CategoriaNegocio();
                int idCategoria;
                if (int.TryParse(nuevoArticulo.Categoria, out idCategoria))
                {
                    bool existeCat = catNeg.ExisteIdCategoria(idCategoria.ToString());
                    if (!existeCat)
                        return BadRequest("La categoría especificada no existe");
                    articulo.Categoria = new Categoria { IDCategoria = idCategoria };

                }
                else
                {
                    bool existeCat = catNeg.ExisteCategoria(nuevoArticulo.Categoria);
                    if (!existeCat)
                        return BadRequest("La categoría especificada no existe");
                    articulo.Categoria = new Categoria { IDCategoria = negocio.ObtenerIdCategoria(nuevoArticulo.Categoria) };
                }

                //Creo la lista de imágenes
                List<Imagen> listaImg = new List<Imagen>();
                if (nuevoArticulo.Imagenes != null)
                {
                    foreach (var url in nuevoArticulo.Imagenes)
                    {
                        if (EsUrlValida(url))
                        {
                            Imagen img = new Imagen();
                            img.urlImagen = url;
                            listaImg.Add(img);
                        }
                        else if (!string.IsNullOrWhiteSpace(url)) return BadRequest("La imagen no tiene el formato requerido.");

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
        [HttpPut]

        public IHttpActionResult Put(int id, [FromBody] ArticuloDTOPost art)
        {
            try
            {
                if (art == null) return BadRequest("El ID del artículo no es válido.");
                if (id <= 0) return BadRequest("El ID del artículo no es válido.");
                if (string.IsNullOrWhiteSpace(art.Nombre) || string.IsNullOrWhiteSpace(art.Codigo)) return BadRequest("Hay datos vacíos");
                if (!ExistenLetras(art.Nombre)) return BadRequest("El nombre no pueden ser solo números.");
                if (!string.IsNullOrWhiteSpace(art.Descripcion))
                {
                    if (!ExistenLetras(art.Descripcion)) return BadRequest("La descripcion no pueden ser solo números.");
                }
                if (art.Precio < 1) return BadRequest("El precio no puede ser menor a un peso >:c");

                ArticuloNegocio negocio = new ArticuloNegocio();
                if (!negocio.existeArticulo(id)) return BadRequest("El artículo no existe");

                bool existiaImg = art.Imagenes != null && art.Imagenes.Any();

                Articulo nuevo = new Articulo();
                nuevo.Imagenes = new List<Imagen>();

                nuevo.Codigo = art.Codigo;
                nuevo.Nombre = art.Nombre;
                nuevo.Descripcion = art.Descripcion;
                nuevo.Precio = art.Precio;


                //Marca
                if (string.IsNullOrWhiteSpace(art.Marca)) return BadRequest("La marca no puede estar vacía.");
                MarcaNegocio negMarca = new MarcaNegocio();
                int idMarca;
                if (int.TryParse(art.Marca, out idMarca))
                {
                    bool marcaExistente = negMarca.ExisteIdMarca(idMarca.ToString());
                    if (!marcaExistente)
                        return BadRequest("La marca especificada no existe.");
                    nuevo.Marca = new Marca { IdMarca = idMarca };
                }
                else
                {
                    bool marcaExistente = negMarca.ExisteMarca(art.Marca);
                    if (!marcaExistente)
                        return BadRequest("La marca especificada no existe");
                    nuevo.Marca = new Marca { IdMarca = negocio.ObtenerIdMarca(art.Marca) };
                }


                //Categoría
                if (string.IsNullOrWhiteSpace(art.Categoria)) return BadRequest("La categoría no puede estar vacía");
                CategoriaNegocio catNeg = new CategoriaNegocio();
                int idCategoria;
                if (int.TryParse(art.Categoria, out idCategoria))
                {
                    bool existeCat = catNeg.ExisteIdCategoria(idCategoria.ToString());
                    if (!existeCat)
                        return BadRequest("La categoría especificada no existe");
                    nuevo.Categoria = new Categoria { IDCategoria = idCategoria };

                }
                else
                {
                    bool existeCat = catNeg.ExisteCategoria(art.Categoria);
                    if (!existeCat)
                        return BadRequest("La categoría especificada no existe");
                    nuevo.Categoria = new Categoria { IDCategoria = negocio.ObtenerIdCategoria(art.Categoria) };
                }

                if (art.Imagenes != null)
                {
                    foreach (var url in art.Imagenes)
                    {
                        if (EsUrlValida(url))
                        {
                            nuevo.Imagenes.Add(new Imagen { urlImagen = url });
                        }
                        else if (!string.IsNullOrWhiteSpace(url)) return BadRequest("La imagen no tiene el formato requerido.");
                    }
                }

                nuevo.IdArticulo = id;

                negocio.modificarArticulo(nuevo, nuevo.Imagenes, existiaImg);

                return Ok("Artículo modificado correctamente.");
            }

            catch (Exception ex)
            {
                return BadRequest("No se pudo realizar la petición");
            }
        }


        // DELETE: api/Articulos/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("El ID del artículo no es válido.");

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                bool existeArt = negocio.existeArticulo(id);
                if (existeArt == false)
                {
                    return BadRequest("No existe ese artículo");
                }
                negocio.eliminarArticulo(id);
                return Ok("Artículo eliminado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
