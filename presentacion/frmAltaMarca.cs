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
    public partial class frmAltaMarca : Form
    {
        private Marca marca = null;
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        public frmAltaMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            Text = "Modificar Marca";
            btnAgregarMarca.Text = "Aceptar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool SoloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter))
                    return false;
            }
            return true;
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            { 
                if (string.IsNullOrWhiteSpace(txtDescripcionMarca.Text))
                {
                    MessageBox.Show("¡¡ Debe ingresar una Descripción !!",
                                    "Campo vacío",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (SoloNumeros(txtDescripcionMarca.Text))
                {
                    MessageBox.Show("¡¡ La descripción no puede contener solo números !!",
                                    "Error de validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (negocio.ExisteMarca(txtDescripcionMarca.Text))
                {
                    MessageBox.Show("La marca '" + txtDescripcionMarca.Text + "' ya existe.",
                                    "Duplicado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (marca == null)
                marca = new Marca();
                marca.Descripcion = txtDescripcionMarca.Text;

                if(marca.IdMarca != 0)
                {
                    
                    negocio.modificar(marca);
                    MessageBox.Show("Modificado Exitosamente","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                else
                {

                    negocio.agregar(marca);
                    MessageBox.Show("Agregado Exitosamente","Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            if (marca != null)
            {
                txtDescripcionMarca.Text = marca.Descripcion;
            }
        }
    }
}
