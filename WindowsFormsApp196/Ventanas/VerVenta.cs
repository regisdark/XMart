using System;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp196.Ventanas
{
    public partial class VerVenta : Form
    {
        public VerVenta()
        {
            InitializeComponent();
            dtFecha.MaxDate = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dtVentas.Rows.Clear();
                var _datos = new BusinessLogic.Metodos.Ventas().ObtenerVenta(dtFecha.Value);
                if (_datos.Any())
                    foreach (var item in _datos)
                        dtVentas.Rows.Add(item.ID, item.NOMBRE_USUARIO, item.CANT_PRODUCTOS, item.IMPORTE_TOTAL.ToString("C"));
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
                dtVentas.Rows.Clear();
            }
            catch (Exception exc)
            {
                throw exc;
            }
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
    }
}
