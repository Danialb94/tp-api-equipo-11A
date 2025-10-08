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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarca;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void cargarMarcas()
        {
            MarcaNegocio Negocio = new MarcaNegocio();
            listaMarca = Negocio.listar();
            dgvMarca.DataSource = listaMarca;
            dgvMarca.Columns["IdMarca"].Visible = false;
        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca alta = new frmAltaMarca();
            alta.ShowDialog();
            cargarMarcas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marca seleccionado;
            seleccionado = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            frmAltaMarca modificar = new frmAltaMarca(seleccionado);
            modificar.ShowDialog();
            cargarMarcas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMarca.CurrentRow != null)
                {
                    Marca seleccionado = (Marca)dgvMarca.CurrentRow.DataBoundItem;
                    MarcaNegocio negocio = new MarcaNegocio();

                    
                    if (negocio.tieneArticulosAsociados(seleccionado.IdMarca))
                    {
                        MessageBox.Show(
                            "No se puede eliminar la marca porque tiene artículos asociados.\n" +
                            "Primero elimine los artículos de esa marca.",
                            "ATENCIÓN",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                
                    DialogResult respuesta = MessageBox.Show(
                        "¿Está seguro de eliminar la marca: " + seleccionado.Descripcion + "?",
                        "Eliminando",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.eliminar(seleccionado.IdMarca);
                        cargarMarcas(); 
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una marca para eliminar.","Seleccion requerida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtFiltroMarca_TextChanged(object sender, EventArgs e)
        {
            List<Marca> listaFiltrada;
            string filtro = txtFiltroMarca.Text;

            if (filtro.Length >= 1) // muestra desde la primera letra
            {
                listaFiltrada = listaMarca.FindAll(x => x.Descripcion.ToUpper().StartsWith(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaMarca;
            }

            dgvMarca.DataSource = null;
            dgvMarca.DataSource = listaFiltrada;
            dgvMarca.Columns["IdMarca"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
