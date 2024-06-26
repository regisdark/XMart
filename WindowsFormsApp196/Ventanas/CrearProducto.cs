using System;
using System.Windows.Forms;

namespace WindowsFormsApp196.Ventanas
{
    public partial class CrearProducto : Form
    {
        public CrearProducto()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void Limpiar()
        {
            try
            {
                txtDesc.Text = string.Empty;
                cmbDpto.SelectedIndex = 0;
                nmPrecio.Value = 0;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDesc.Text))
                    return;


            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
