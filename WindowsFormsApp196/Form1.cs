using System;
using System.Windows.Forms;

namespace WindowsFormsApp196
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
