using api_articulos.Models;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace api_articulos.Controllers
{
    public class ImagenesController : ApiController
    {
        bool EsUrlValida(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        // POST: api/Imagenes
        public IHttpActionResult Post([FromBody] ImagenDTO imagenes)
        {
            if (imagenes == null ||(imagenes.IdArticulo==0 && imagenes.urlImagenes==null)) return BadRequest("No se enviaron datos.");
            if (imagenes.IdArticulo == 0) return BadRequest("Id de artículo inválido");
            if (imagenes.urlImagenes.Count == 0) return BadRequest("No se enviaron imagenes.");
            if (imagenes.urlImagenes.Count == 1 && string.IsNullOrWhiteSpace(imagenes.urlImagenes[0])) BadRequest("No se enviaron imagenes.");
            try
            {
                ArticuloNegocio negArticulo = new ArticuloNegocio();
                if(!negArticulo.existeArticulo(imagenes.IdArticulo)) return BadRequest("El artículo no existe.");

                ImagenNegocio negocio = new ImagenNegocio();
                Imagen img = new Imagen();
                img.idArticulo = imagenes.IdArticulo;

                bool carga = false;
                for (int i = 0; i < imagenes.urlImagenes.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(imagenes.urlImagenes[i]) || !EsUrlValida(imagenes.urlImagenes[i]))
                    {
                        img.urlImagen = imagenes.urlImagenes[i];
                        negocio.agregar(img);
                        if (!carga) carga = true;
                    }
                }
                if (!carga) return BadRequest("No se enviaron imagenes.");
                
                return Ok("Se cargaron las imagenes");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
