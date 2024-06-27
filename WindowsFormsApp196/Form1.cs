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
                var _usuario = new BusinessLogic.Metodos.Usuarios().ObtenerUsuario(System.Security.Principal.WindowsIdentity.GetCurrent().Name, "51390396E3FE636190FEE7C6A203E8B904C86E01");
                if(_usuario.HasValue)
                    switch (_usuario)
                    {//puedo quitar y poner permisos y accesos a mi gusto, basandome en el tipo de usuario
                        case (int)eTiposUsuario.CAJERO:
                            //si es un cajero, le quito el acceso a los catalogos (las reglas de negocio tambien se pueden hacer a nivel de base de datos)
                            catalogosToolStripMenuItem.Enabled = false;
                            break;

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

        }
    }
}
