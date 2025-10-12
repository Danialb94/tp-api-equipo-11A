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
    public class ImagenesController : ApiController
    {
        // POST: api/Imagenes
        public IHttpActionResult Post([FromBody] ImagenDTO imagenes)
        {
            if (imagenes == null ||(imagenes.IdArticulo==0 && imagenes.urlImagenes==null)) return BadRequest("No se enviaron datos.");
            if (imagenes.IdArticulo == 0) return BadRequest("Id de artículo inválido");
            if (imagenes.urlImagenes.Count == 0) return BadRequest("No se enviaron imagenes.");
            try
            {
                ArticuloNegocio negArticulo = new ArticuloNegocio();
                if(!negArticulo.existeArticulo(imagenes.IdArticulo)) return BadRequest("El artículo no existe.");

                ImagenNegocio negocio = new ImagenNegocio();
                Imagen img = new Imagen();
                img.idArticulo = imagenes.IdArticulo;
                for (int i = 0; i < imagenes.urlImagenes.Count; i++)
                {
                    img.urlImagen = imagenes.urlImagenes[i];

                    negocio.agregar(img);
                }

                return Ok("Se cargaron las imagenes");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
