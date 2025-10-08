using dominio;
using negocio;
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
    public partial class frmAltaImagenes : Form
    {
        private Articulo articulo = null;
        private int indiceIMG = -1;
        public frmAltaImagenes()
        {
            InitializeComponent();
        }
        public frmAltaImagenes(Articulo articulo, int indice)
        {
            InitializeComponent();
            this.articulo = articulo;
            if (indice != -1)
            {
                indiceIMG = indice;
                Text = "Modificar Imagen";
                lblTitulo.Text = "Modificar Imagen";
                btnAgregar.Text = "Aceptar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaImagenes_Load(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNeg = new CategoriaNegocio();
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtMarca.Text = articulo.Marca.Descripcion;
                txtCategoria.Text = articulo.Categoria.Descripcion;
                if(indiceIMG != -1)
                {
                    txtUrl.Text = articulo.Imagenes[indiceIMG].urlImagen;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Imagen img = new Imagen();
            img.idArticulo = articulo.IdArticulo;
            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                if (indiceIMG != -1)
                {
                    if (txtUrl.Text == articulo.Imagenes[indiceIMG].urlImagen)
                    {
                        MessageBox.Show("Ingrese una nueva URL para hacer la modificación.");
                    }
                    else
                    {
                        img.urlImagen = txtUrl.Text;
                        img.idImagen = articulo.Imagenes[indiceIMG].idImagen;
                        negocio.modificar(img);
                        MessageBox.Show("Modificado exitosamente");
                        this.Close();
                    }

                }
                else
                {
                    img.urlImagen = txtUrl.Text;
                    negocio.agregar(img);
                    MessageBox.Show("Agregada Exitosamente");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "";
        }
    }
}
