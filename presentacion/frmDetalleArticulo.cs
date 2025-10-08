using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulo dgvArticulos;

        public frmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();

            txtboxDetalleCodigo.Text = articulo.Codigo;
            txtboxDetalleNombre.Text = articulo.Nombre;
            txtboxDetalleDescripcion.Text = articulo.Descripcion;
            txtboxDetalleMarca.Text = articulo.Marca.Descripcion;
            txtboxDetalleCategoria.Text = articulo.Categoria.Descripcion;
            txtboxDetallePrecio.Text = articulo.Precio.ToString();
            if (articulo.Imagenes.Count > 0)
                cargarImagen(articulo.Imagenes[0].urlImagen);
            else cargarImagen(null);

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pboImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pboImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }

}
