using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private List<Imagen> listaImagenes;
        private int imagenAux;
        private int flagModificado = 1;//para cuando se agrega durante una modificación
        private List<Marca> listaMar;
        private List<Categoria> listaCat;

        public frmAltaArticulo()
        {
            InitializeComponent();
            
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
            lblAltaArticulo.Text = "Modificar Articulo";
            btnAceptarNuevoArticulo.Text = "Guardar";
            btnAgregarImg.Text = "Modificar Imagen";
        }

        private void btnCancelarNuevoArticulo_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAceptarNuevoArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            btnAceptarNuevoArticulo.Enabled = false;

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtboxCodigoArticulo.Text;
                articulo.Nombre = txtboxNombreArticulo.Text;
                articulo.Descripcion = txtboxDescripcionArticulo.Text;
                articulo.Marca = (Marca)cmbMarcaArticulo.SelectedItem;
                articulo.Categoria = (Categoria)cmbCategoriaArticulo.SelectedItem;
                articulo.Precio = decimal.Parse(txtboxPrecioArticulo.Text);

                if ( negocio.existeArticulo(articulo.Codigo, articulo.Nombre))
                {
                    MessageBox.Show("Ya existe un artículo con este Código o Nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAceptarNuevoArticulo.Enabled = false;
                    
                }
                else
                {
                        if (articulo.IdArticulo != 0)
                        {
                            cmbMarcaArticulo.SelectedValue = articulo.Marca.IdMarca;
                            cmbCategoriaArticulo.SelectedValue = articulo.Categoria.IDCategoria;
                            if (flagModificado != -1)
                            {
                                negocio.modificarArticulo(articulo, articulo.Imagenes, true);
                            }
                            else
                            {

                                negocio.modificarArticulo(articulo, articulo.Imagenes, false);
                            }

                            MessageBox.Show("Modificado exitosamente");
                        }
                        else
                        {

                            negocio.agregar(articulo, listaImagenes);
                            MessageBox.Show("Articulo agregado exitosamente");
                        }

                }

                        Close();
            }
                   

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            listaImagenes = new List<Imagen>();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNeg = new CategoriaNegocio();


            try
            {
                listaMar = marcaNegocio.listar();
                listaCat = categoriaNeg.Listar();
                if (listaMar == null || listaMar.Count == 0)
                {
                    MessageBox.Show("No hay marcas cargadas en el sistema. No se puede dar de alta un artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                if (listaCat == null || listaCat.Count == 0)
                {
                    MessageBox.Show("No hay categorías cargadas en el sistema. No se puede dar de alta un artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                gbxNavegadorImg.Visible = false;
                cmbMarcaArticulo.DataSource = marcaNegocio.listar();
                cmbMarcaArticulo.ValueMember = "IdMarca";
                cmbMarcaArticulo.DisplayMember = "Descripcion";
                cmbCategoriaArticulo.DataSource = categoriaNeg.Listar();
                cmbCategoriaArticulo.ValueMember = "IdCategoria";
                cmbCategoriaArticulo.DisplayMember = "Descripcion";

                if (articulo != null)
                {

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        cargarImagen(articulo.Imagenes[0].urlImagen);
                        if (articulo.Imagenes.Count > 1)
                        {
                            gbxNavegadorImg.Visible = true;
                            btnNavegarAtras.Visible = false;
                            btnNavegarAdelante.Visible = true;
                        }
                        else
                        {
                            gbxNavegadorImg.Visible = false;
                        }
                    }
                    lblImgAgregadas.Visible = false;

                    txtboxCodigoArticulo.Text = articulo.Codigo;
                    txtboxNombreArticulo.Text = articulo.Nombre;
                    txtboxDescripcionArticulo.Text = articulo.Descripcion;
                    txtboxPrecioArticulo.Text = articulo.Precio.ToString();

                    cmbMarcaArticulo.SelectedValue = articulo.Marca.IdMarca;
                    cmbCategoriaArticulo.SelectedValue = articulo.Categoria.IDCategoria;

                    if (articulo.Imagenes != null)
                    {
                        if (articulo.Imagenes.Count == 0)
                        {
                            btnAgregarImg.Text = "Agregar Imagen";
                            txtboxUrlImagenArticulo.Text = "";
                        }
                        else
                        {
                            cargarImagen(articulo.Imagenes[0].urlImagen);
                            txtboxUrlImagenArticulo.Text = articulo.Imagenes[0].urlImagen;
                        }
                    }
                    else cargarImagen(null);
                    listaImagenes = articulo.Imagenes;
                }
                validarCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        private void validarCampos()
        {
            bool codigoOk = !string.IsNullOrWhiteSpace(txtboxCodigoArticulo.Text);
            bool nombreOk = !string.IsNullOrWhiteSpace(txtboxNombreArticulo.Text);
            bool precioOk = false;

            try
            {
                decimal precio = Convert.ToDecimal(txtboxPrecioArticulo.Text);
                if (precio > 0)
                    precioOk = true;
            }
            catch
            {
                precioOk = false;
            }

            btnAceptarNuevoArticulo.Enabled = codigoOk && nombreOk && precioOk;
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void txtboxUrlImagenArticulo_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtboxUrlImagenArticulo.Text);
        }


        private void cargarImagen(string imagen)
        {
            try
            {
                picbImagenArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                picbImagenArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }
        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            if (txtboxUrlImagenArticulo.Text == "")
            {
                MessageBox.Show("Por favor, complete el campo antes de intentar agregar una imagen.");
            }
            else
            {
                if (articulo == null)
                {
                    Imagen img = new Imagen();
                    img.urlImagen = txtboxUrlImagenArticulo.Text;
                    listaImagenes.Add(img);
                    lblImgAgregadas.Text = "Imagenes cargadas: " + listaImagenes.Count;
                    txtboxUrlImagenArticulo.Text = "";
                }
                else
                {
                    if (articulo.Imagenes.Count == 0)
                    {
                        Imagen img = new Imagen();
                        img.urlImagen = txtboxUrlImagenArticulo.Text;
                        articulo.Imagenes.Add(img);
                        cargarImagen(articulo.Imagenes[0].urlImagen);
                        MessageBox.Show("Se cargó la imagen, recuerde guardar los cambios.");
                        flagModificado = -1;
                        btnAgregarImg.Text = "Modificar Imagen";
                    }
                    else
                    {
                        if (txtboxUrlImagenArticulo.Text == articulo.Imagenes[imagenAux].urlImagen)
                        {
                            MessageBox.Show("Seleccione una imagen distinta a la actual para generar la modificación.");
                        }
                        else
                        {
                            articulo.Imagenes[imagenAux].urlImagen = txtboxUrlImagenArticulo.Text;
                            cargarImagen(articulo.Imagenes[imagenAux].urlImagen);
                            MessageBox.Show("Se modificó la imagen, recuerde guardar los cambios.");

                        }
                    }

                }

            }
        }



        ///NAVEGAR IMAGENES
        private void btnNavegarAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                imagenAux++;
                cargarImagen(articulo.Imagenes[imagenAux].urlImagen);
                btnNavegarAtras.Visible = true;
                txtboxUrlImagenArticulo.Text = articulo.Imagenes[imagenAux].urlImagen;
                if (articulo.Imagenes.Count - 1 == imagenAux) btnNavegarAdelante.Visible = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnNavegarAtras_Click(object sender, EventArgs e)
        {
            try
            {
                imagenAux--;
                cargarImagen(articulo.Imagenes[imagenAux].urlImagen);
                btnNavegarAdelante.Visible = true;
                txtboxUrlImagenArticulo.Text = articulo.Imagenes[imagenAux].urlImagen;
                if (0 == imagenAux) btnNavegarAtras.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            txtboxUrlImagenArticulo.Text = "";
        }

        
    }
}
