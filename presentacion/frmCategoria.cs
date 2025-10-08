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
    public partial class frmCategoria : Form
    {
        private List<Categoria> listaCategoria;
        private bool mostrarModificar;
        private bool mostrarEliminar;
        private bool mostrarAdvertencia;
        private bool esListado;
        
        


        public frmCategoria(bool esListado)
        {
            InitializeComponent();
            this.esListado = esListado;
            mostrarModificar = false;
            mostrarEliminar = false;
            lblTituloCategoria.Text = "Listado de Categoría";
        }
        public frmCategoria(bool mostrarModificar, bool mostrarEliminar, bool mostrarAdvertencia)
        {
            InitializeComponent();
            this.mostrarModificar = mostrarModificar;
            this.mostrarEliminar = mostrarEliminar;
            this.mostrarAdvertencia = mostrarAdvertencia;

            this.esListado = false;
            
            if (mostrarModificar && !mostrarEliminar)
            {
                lblTituloCategoria.Text = "Modificar Categoria";
            }
            else if (!mostrarModificar && mostrarEliminar)
            {
                lblTituloCategoria.Text = "Eliminar Categoria";
            }
            else
            {
                lblTituloCategoria.Text = "Listado de Categorías";
            }

            lblAdvertencia.Visible = mostrarAdvertencia;
            if (mostrarAdvertencia)
            {
                lblAdvertencia.Text = "Recuerde: seleccione una categoria para continuar.";
                lblAdvertencia.ForeColor = Color.DimGray;
            }

            txtFiltroCategoria.Visible = false;
            lblFiltroCategoria.Visible = false;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            btnModificar.Visible = mostrarModificar;
            btnEliminar.Visible = mostrarEliminar;
        }

        private void cargarCategoria()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                listaCategoria = negocio.Listar();
                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = listaCategoria;
                dgvCategoria.Columns["IDCategoria"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Categoria: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow != null)
            {
                Categoria seleccionado = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                frmAltaCategoria modificar = new frmAltaCategoria(seleccionado);
                modificar.ShowDialog();
                cargarCategoria();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow != null)
            {
                Categoria seleccionado = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                CategoriaNegocio negocio = new CategoriaNegocio();

                if (negocio.tieneArticulosAsociados(seleccionado.IDCategoria))
                {
                    MessageBox.Show(
                        "No se puede eliminar la categoría porque tiene artículos asociados.\n" +
                        "Primero elimine los artículos de esa categoría.",
                        "ATENCIÓN",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar la categoría: " + seleccionado.Descripcion + "?",
                    "Eliminar Categoría",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        negocio.eliminar(seleccionado.IDCategoria);
                        cargarCategoria();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una categoría primero.", "Seleccion requerida", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void txtFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> listaFiltrada;
            string filtro = txtFiltroCategoria.Text;

            if (filtro.Length >=1)
            {
                listaFiltrada = listaCategoria.FindAll(x => x.Descripcion.ToUpper().StartsWith(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaCategoria;
            }

            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = listaFiltrada;
            dgvCategoria.Columns["IDCategoria"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

