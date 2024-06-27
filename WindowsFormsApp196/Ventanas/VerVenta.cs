using Microsoft.Reporting.WinForms;
using Reportes;
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

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtVentas.SelectedRows.Count == 0)
                    return;

                VisorReportes _forma = new VisorReportes();
                ReportViewer _reportviewer = _forma.reportViewer1;
                _reportviewer.LocalReport.DataSources.Clear();

                Reportes.DataSets.DataSetReporteDetalleVenta dataSet = new Reportes.DataSets.DataSetReporteDetalleVenta();
                var _detalle = new BusinessLogic.Metodos.Ventas().ObtenerDetalleVenta(dtVentas.SelectedRows[0].Cells[0].Value.ToString());
                if (_detalle != null && _detalle.Any())
                    foreach (var item in _detalle)
                        dataSet.DETALLE.Rows.Add(item.PRODUCTO, item.CANTIDAD,item.PRECIO);

                _reportviewer.LocalReport.DataSources.Add(new ReportDataSource("DETALLE", dataSet.DETALLE.Rows));
                _reportviewer.LocalReport.ReportPath = "C:\\Users\\USER\\source\\repos\\WindowsFormsApp196\\Reportes\\Formatos\\ReporteDetalleVenta.rdlc";
                _reportviewer.SetDisplayMode(DisplayMode.PrintLayout);
                _reportviewer.Refresh();
                _reportviewer.RefreshReport();
                _forma.Show();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
