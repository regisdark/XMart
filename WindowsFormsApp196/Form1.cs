using System;
using System.Windows.Forms;
using static BusinessLogic.Clases_Personalizadas.Enumeradores;

namespace WindowsFormsApp196
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ValidarUsuario();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ventanas.CrearProducto _x = new Ventanas.CrearProducto();
                _x.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ValidarUsuario()
        {
            try
            {
                catalogosToolStripMenuItem.Enabled = false;
                var _usuario = new BusinessLogic.Metodos.Usuarios().ObtenerUsuario(System.Security.Principal.WindowsIdentity.GetCurrent().Name, "51390396E3FE636190FEE7C6A203E8B904C86E01");
                if(_usuario.HasValue)
                    switch (_usuario)
                    {//puedo quitar y poner permisos y accesos a mi gusto, basandome en el tipo de usuario
                        case (int)eTiposUsuario.SUPERVISOR:
                            //si es un supervisor, le doy el acceso a los catalogos
                            catalogosToolStripMenuItem.Enabled = true;
                            break;
                    }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ventanas.EditarProducto _x = new Ventanas.EditarProducto();
                _x.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void crearVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ventanas.CrearVenta _x = new Ventanas.CrearVenta();
                _x.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ventanas.VerVenta _x = new Ventanas.VerVenta();
                _x.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
