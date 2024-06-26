using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp196.Ventanas
{
    public partial class EditarProducto : Form
    {
        public EditarProducto()
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
                    {
                        cmbDpto.Items.Add(new BusinessLogic.Clases_Personalizadas.Departamento() { DESCRIPCION = item.DESCRIPCION, ID = item.ID });
                        cmbEdicionDpto.Items.Add(new BusinessLogic.Clases_Personalizadas.Departamento() { DESCRIPCION = item.DESCRIPCION, ID = item.ID });
                    }
                }

                cmbDpto.DisplayMember = "DESCRIPCION";
                cmbDpto.ValueMember = "ID";
                cmbDpto.SelectedIndex = 0;

                cmbEdicionDpto.DisplayMember = "DESCRIPCION";
                cmbEdicionDpto.ValueMember = "ID";
                cmbEdicionDpto.SelectedIndex = 0;
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
                dgProductos.Rows.Clear();
                var _datos = new BusinessLogic.Metodos.Productos().ObtenerProductos(((BusinessLogic.Clases_Personalizadas.Departamento)((ComboBox)sender).SelectedItem).ID);
                if (_datos != null && _datos.Any())
                    foreach (var item in _datos)
                        dgProductos.Rows.Add(item.ID, item.PRECIO, item.DESCRIPCION, item.ESTATUS);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void dgProductos_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (e.StateChanged != DataGridViewElementStates.Selected)
                    return;

                LimpiarDetalle();
                var _id = e.Row.Cells[0].Value;
                var _registro = new BusinessLogic.Metodos.Productos().ObtenerProducto(_id.ToString());
                txtDesc.Text = _registro.DESCRIPCION;
                cmbEdicionDpto.SelectedValue = _registro.ID_DEPARTAMENTO;
                nmPrecio.Value = _registro.PRECIO;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void LimpiarDetalle()
        {
            try
            {
                txtDesc.Text = string.Empty;
                cmbEdicionDpto.SelectedIndex = 0;
                nmPrecio.Value = (decimal)0.1;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDetalle();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
