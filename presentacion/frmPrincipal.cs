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
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        private int imagenAux;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        ///ARTICULOS
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            MessageBox.Show("¡Bienvenido! Gracias por utilizar nuestro sistema.",
                    "Bienvenida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            cargarArticulos();

            cboCampoArticulo.Items.Add("Código");
            cboCampoArticulo.Items.Add("Nombre");
            cboCampoArticulo.Items.Add("Descripción");
            cboCampoArticulo.Items.Add("Marca");
            cboCampoArticulo.Items.Add("Categoria");
            cboCampoArticulo.Items.Add("Precio");
            cboCampoArticulo.SelectedIndex = 0;


            cboCriterioArticulos.SelectedIndex = 0;
            btnNavegarAtras.Visible = false;
        }
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo artSeleccionado = null;
            imagenAux = 0;

            if (dgvArticulos.CurrentRow != null && dgvArticulos.CurrentRow.DataBoundItem != null)
            {
                artSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                if (artSeleccionado.Imagenes.Count == 0)
                {
                    noTieneImagenes();
                }
            }
            if (artSeleccionado != null && artSeleccionado.Imagenes != null && artSeleccionado.Imagenes.Count > 0)
            {
                cargarImagen(artSeleccionado.Imagenes[0].urlImagen);
                if (artSeleccionado.Imagenes.Count > 1)
                {
                    tieneImagenes(true);
                }
                else
                {
                    tieneImagenes(false);
                }

            }
            else
            {
                noTieneImagenes();
            }
        }
        private void cargarArticulos()
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            listaArticulo = Negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            ocultarColumnasArticulos();
            txtboxFiltroAvanzadoArticulos.Text = "";

            if (listaArticulo.Count > 0)
            {
                conArticulos();
                if (listaArticulo[0].Imagenes != null && listaArticulo[0].Imagenes.Count > 0)
                {
                    cargarImagen(listaArticulo[0].Imagenes[0].urlImagen);
                    conArticulos();
                }
                else
                    cargarImagen(null);
            }
            else
            {
                sinArticulos();
            }
        }

        /// VISTAS
        private void noTieneImagenes()
        {
            btnAgregarImg.Enabled = true;
            gbxNavegadorImg.Visible = false;
            btnModificarImg.Enabled = false;
            btnEliminarImg.Enabled = false;
            cargarImagen(null);
        }
        private void tieneImagenes(bool masDeUna)
        {
            btnAgregarImg.Enabled = true;
            btnModificarImg.Enabled = true;
            btnEliminarImg.Enabled = true;
            if (masDeUna)
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
        private void conArticulos()
        {
            btnDetalle.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void sinArticulos()
        {
            btnDetalle.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregarImg.Enabled = false;
            btnModificarImg.Enabled = false;
            btnEliminarImg.Enabled = false;
            gbxNavegadorImg.Visible = false;
            cargarImagen("");
        }

        private void ocultarColumnasArticulos()
        {
            dgvArticulos.Columns["IdArticulo"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }
        ///ABM - ARTICULOS
        private void agregarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargarArticulos();
        }

        private void modificarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado;
            if (dgvArticulos.CurrentRow != null)
            {
                articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo modificar = new frmAltaArticulo(articuloSeleccionado);
                modificar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo primero.", "Seleccion requerida",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            cargarArticulos();

        }
        
        private void eliminarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que quiere eliminar?", "Eliminar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        negocio.eliminarArticulo(seleccionado.IdArticulo);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un artículo primero.", "Selección requerida",
                                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                cargarArticulos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void verDetalleArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                frmDetalleArticulo detalle = new frmDetalleArticulo(seleccionado);
                detalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo primero.", "Selección requerida",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cargarArticulos();
        }


        ///FILTROS
        
        private void txtboxFiltroArticulos_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtboxFiltroArticulos.Text;
            if (filtro.Length >= 2)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }
            
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnasArticulos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampoArticulo.SelectedItem != null)
            {
                string opcion = cboCampoArticulo.SelectedItem.ToString();

                if (opcion == "Código" || opcion == "Nombre" || opcion == "Descripción" || opcion == "Marca" || opcion == "Categoria")
                {
                    cboCriterioArticulos.Items.Clear();
                    cboCriterioArticulos.Items.Add("Comienza con");
                    cboCriterioArticulos.Items.Add("Termina con");
                    cboCriterioArticulos.Items.Add("Contiene");
                }
                else if (opcion == "Precio")
                {
                    cboCriterioArticulos.Items.Clear();
                    cboCriterioArticulos.Items.Add("Mayor a");
                    cboCriterioArticulos.Items.Add("Menor a");
                    cboCriterioArticulos.Items.Add("Igual a");
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (validarFiltro())
                {
                    return;
                }


                string campo = cboCampoArticulo.SelectedItem.ToString();
                string criterio = cboCriterioArticulos.SelectedItem.ToString();
                string filtro = txtboxFiltroAvanzadoArticulos.Text;

                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool validarFiltro()
        {
            if (cboCampoArticulo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.","Filtro inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return true;
            }
            if (cboCriterioArticulos.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.","Filtro inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return true;
            }
            string campoSeleccionado = cboCampoArticulo.SelectedItem.ToString();

            if (campoSeleccionado == "Precio")
            {
                if (string.IsNullOrEmpty(txtboxFiltroAvanzadoArticulos.Text))
                {
                    MessageBox.Show("Por favor ingrese un valor para filtrar.","Dato requerido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return true;
                }

                if (!soloNumeros(txtboxFiltroAvanzadoArticulos.Text))
                {
                    MessageBox.Show("Solo se aceptan números para el precio.","Dato inválido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }


        ///MARCAS
        private void listadoDeMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.ShowDialog();
        }
        private void agregarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaMarca alta = new frmAltaMarca();
            alta.ShowDialog();
        }


        ///CATEGORIAS
        private void listadoDeCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria(true);
            categoria.ShowDialog();

        }

        private void agregarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaCategoria alta = new frmAltaCategoria();
            if (alta.ShowDialog() == DialogResult.OK) 
            {
                frmCategoria categoria = new frmCategoria(false);
                categoria.ShowDialog();
                cargarArticulos();
            }

        }

        private void modificarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria modificar = new frmCategoria(true, false, true);
            modificar.ShowDialog();
            cargarArticulos();
        }

        private void eliminarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria eliminar = new frmCategoria(false, true,true);
            eliminar.ShowDialog();
            cargarArticulos();
        }


        //IMAGENES
        private void btnNavegarAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un artículo para continuar","Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Articulo artActual = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagenAux++;
                cargarImagen(artActual.Imagenes[imagenAux].urlImagen);
                btnNavegarAtras.Visible = true;
                if (artActual.Imagenes.Count - 1 == imagenAux) btnNavegarAdelante.Visible = false;

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
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un artículo para continuar", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Articulo artActual = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagenAux--;
                cargarImagen(artActual.Imagenes[imagenAux].urlImagen);
                btnNavegarAdelante.Visible = true;
                if (0 == imagenAux) btnNavegarAtras.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un artículo para continuar", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Articulo artSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaImagenes agregar = new frmAltaImagenes(artSeleccionado, -1);
                agregar.ShowDialog();
                cargarArticulos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnModificarImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un artículo para continuar", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Articulo artSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaImagenes agregar = new frmAltaImagenes(artSeleccionado, imagenAux);
                agregar.ShowDialog();
                cargarArticulos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnEliminarImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un artículo para continuar", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Articulo artSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show(
                        "¿ Está seguro de eliminar la imagen esta imagen del artículo: " + artSeleccionado.Codigo + "/" + artSeleccionado.Nombre + " ? ",
                        "Eliminar Imagen",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        ImagenNegocio negocio = new ImagenNegocio();
                        negocio.eliminar(artSeleccionado.Imagenes[imagenAux].idImagen);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Eliminar: " + ex.Message);
                    }
                }
                cargarArticulos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void pbxArticulo_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea salir del sistema?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                MessageBox.Show("Gracias por utilizar nuestro sistema. ¡Hasta pronto!",
                    "Cerrar aplicación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}

