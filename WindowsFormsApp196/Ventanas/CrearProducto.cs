using BusinessLogic.Metodos;
using System;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp196.Ventanas
{
    public partial class CrearProducto : Form
    {
        public CrearProducto()
        {
            InitializeComponent();
            CargaInicial();
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

        private void Limpiar()
        {
            try
            {
                txtDesc.Text = string.Empty;
                cmbDpto.SelectedIndex = 0;
                nmPrecio.Value = (decimal)0.1;
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

                var _dptoElegido = (BusinessLogic.Clases_Personalizadas.Departamento)cmbDpto.SelectedItem;
                if (new BusinessLogic.Metodos.Productos().GuardarProducto(new BusinessLogic.Clases_Personalizadas.Producto()
                {
                    ESTATUS = true,
                    DESCRIPCION = txtDesc.Text,
                    ID_DEPARTAMENTO = _dptoElegido.ID,
                    PRECIO = nmPrecio.Value
                }))
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
