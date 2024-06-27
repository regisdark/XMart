using BusinessLogic.Clases_Personalizadas;
using System;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp196.Ventanas
{
    public partial class CrearVenta : Form
    {
        public CrearVenta()
        {
            InitializeComponent();
            CargaInicial();
        }

        private void CargaInicial()
        {
            try
            {
                cmbDpto.Items.Clear();
                var _dptos = new BusinessLogic.Metodos.Departamentos().ObtenerDeparamentosCombo();
                if (_dptos != null && _dptos.Any())
                {
                    foreach (var item in _dptos)
                        cmbDpto.Items.Add(new BusinessLogic.Clases_Personalizadas.Departamento() { DESCRIPCION = item.DESCRIPCION, ID = item.ID });
                }

                cmbDpto.DisplayMember = "DESCRIPCION";
                cmbDpto.ValueMember = "ID";
                cmbDpto.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void cmbDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProducto.Items.Clear();
                var _dpto = (BusinessLogic.Clases_Personalizadas.Departamento)cmbDpto.SelectedItem;
                var _pdto = new BusinessLogic.Metodos.Productos().ObtenerProductosCombo(_dpto.ID);
                if (_pdto != null && _pdto.Any())
                    foreach (var item in _pdto)
                        cmbProducto.Items.Add(new BusinessLogic.Clases_Personalizadas.Producto() { DESCRIPCION = item.DESCRIPCION, ID = item.ID });

                cmbProducto.DisplayMember = "DESCRIPCION";
                cmbProducto.ValueMember = "ID";
                cmbProducto.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void btnGuardarManual_Click(object sender, EventArgs e)
        {
            try
            {
                var _producto = (BusinessLogic.Clases_Personalizadas.Producto)cmbProducto.SelectedItem;
                dgArticulos.Rows.Add(_producto.ID, _producto.DESCRIPCION, nmCantidadManual.Value);
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
                nmCantidadManual.Value = 1;
                nmCantidadAuto.Value = 1;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void LimpiarListado()
        {
            try
            {
                dgArticulos.Rows.Clear();
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
                LimpiarListado();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgArticulos.Rows.Count == 0)
                    return;

                Venta venta = new Venta()
                {
                    ESTATUS = true,
                    FECHA = DateTime.Now,
                    SUB_VENTAS = new System.Collections.Generic.List<SubVenta>()
                };

                foreach (DataGridViewRow Datarow in dgArticulos.Rows)
                {
                    venta.SUB_VENTAS.Add(new SubVenta()
                    {
                        CANTIDAD = (decimal)Datarow.Cells[2].Value,
                        ESTATUS = true,
                        ID_PRODUCTO = Datarow.Cells[0].Value.ToString()
                    });
                }

                if (new BusinessLogic.Metodos.Ventas().GuardarVenta(venta, System.Security.Principal.WindowsIdentity.GetCurrent().Name))
                {
                    Limpiar();
                    LimpiarListado();
                    CargaInicial();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            try
            {
                var _datosAleatorios = new BusinessLogic.Metodos.Ventas().GenerarOperaciones((int)nmCantidadAuto.Value);
                if (_datosAleatorios != null && _datosAleatorios.Any())
                    foreach (var item in _datosAleatorios)
                        dgArticulos.Rows.Add(item.ID_PRODUCTO, item.PRODUCTO, item.CANTIDAD);

                Limpiar();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
