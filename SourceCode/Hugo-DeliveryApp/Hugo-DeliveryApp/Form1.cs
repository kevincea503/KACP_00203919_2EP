using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hugo_DeliveryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbUsuarioInicio.DataSource = null;
            cmbUsuarioInicio.ValueMember = "password";
            cmbUsuarioInicio.DisplayMember = "username";
            cmbUsuarioInicio.DataSource = UsuarioDAO.getLista();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            poblarControles();
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (cmbUsuarioInicio.SelectedValue.Equals(txtContrasenaInicio.Text))
            {
                Usuario u = (Usuario) cmbUsuarioInicio.SelectedItem;
                frmPrincipal ventana = new frmPrincipal(u);
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("¡Contraseña incorrecta!", "Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}