using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_articulos.Models
{
    public class ImagenDTO
    {
        public int IdArticulo { get; set; }
        public List<string> urlImagenes  { get; set; }
    }
}