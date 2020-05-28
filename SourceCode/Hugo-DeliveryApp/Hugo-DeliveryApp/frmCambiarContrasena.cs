using System;
using System.Windows.Forms;

namespace Hugo_DeliveryApp
{
    public partial class frmCambiarContrasena : Form
    {
        private Usuario usuario;

        public frmCambiarContrasena(Usuario u)
        {
            InitializeComponent();
            usuario = u;

        }
        
        private void frmCambiarContrasena_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Usuario: " + usuario.username + " (" +
                                 (usuario.userType ? "Administrador" : "Usuario") + ")";
        }


        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            if (usuario.password == textBox1.Text && textBox2.Text.Length > 0 && textBox2.Text.Equals(textBox3.Text))
            {
                try
                {
                    UsuarioDAO.actualizarContra(usuario.username, textBox3.Text);
                    
                    MessageBox.Show("Contraseña actualizada", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: vuelva a intentarlo", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}