using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hugo_DeliveryApp
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario;

        public frmPrincipal(Usuario Puser)
        {
            InitializeComponent();
            usuario = Puser;
        }

        private void actualizarUsuarios()
        {
            List<Usuario> lista = UsuarioDAO.getLista();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;

            cmbEliminar.DataSource = null;
            cmbEliminar.ValueMember = "password";
            cmbEliminar.DisplayMember = "username";
            cmbEliminar.DataSource = lista;

        }


        private void actualizarNegocios()
        {
            List<Business> lista = BusinessDAO.getLista();
            dgvNegocios.DataSource = null;
            dgvNegocios.DataSource = lista;
            cmbNegocio.DataSource = null;
            cmbNegocio.ValueMember = "id_Business";
            cmbNegocio.DisplayMember = "name";
            cmbNegocio.DataSource = lista;

            cmbProducto.DataSource = null;
            cmbProducto.ValueMember = "id_product";
            cmbProducto.DisplayMember = "name";
            cmbProducto.DataSource = lista;

        }

        private void actualizarProducto()
        {
            List<Product> lista = ProductDAO.getLista();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;
            cmbProducto.DataSource = null;
            cmbProducto.ValueMember = "id_product";
            cmbProducto.DisplayMember = "name";
            cmbProducto.DataSource = lista;

            cmbEliminarP.DataSource = null;
            cmbEliminarP.ValueMember = "id_product";
            cmbEliminarP.DisplayMember = "name";
            cmbEliminarP.DataSource = lista;

            cmbPedidoProd.DataSource = null;
            cmbPedidoProd.ValueMember = "id_product";
            cmbPedidoProd.DisplayMember = "name";
            cmbPedidoProd.DataSource = lista;

        }

        private void actualizarDirecciones()
        {
            List<Direccion> lista = DireccionDAO.getLista();
            dgvDirecciones.DataSource = null;
            dgvDirecciones.DataSource = lista;
            cmbNuevaDir.DataSource = null;
            cmbNuevaDir.ValueMember = "idaddres";
            cmbNuevaDir.DisplayMember = "addres";
            cmbNuevaDir.DataSource = lista;

            cmbPedidoDir.DataSource = null;
            cmbPedidoDir.ValueMember = "idaddres";
            cmbPedidoDir.DisplayMember = "addres";
            cmbPedidoDir.DataSource = lista;

        }

        private void actualizarPedidos()
        {
            List<Orden> lista = OrdenDAO.getLista();
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = lista;
            
            dgvPedidosAdmin.DataSource = null;
            dgvPedidosAdmin.DataSource = lista;
            
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = "Bienvenido " + usuario.username + " (" +
                                 (usuario.userType ? "Administrador" : "Usuario") + ")";
            if (usuario.userType)
            {
                tabControl1.TabPages[6].Parent = null;
                tabControl1.TabPages[6].Parent = null; 
                tabControl1.TabPages[6].Parent = null; 
                tabControl1.TabPages[6].Parent = null;
            }
            else
            {
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[4].Parent = null;

                actualizarProducto();

            }

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir, " + usuario.fullname + "?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void btnAnadirUusario_Click(object sender, EventArgs e)
        {
            if (txtNombreRgister.Text.Equals("") || txtUserNameR.Text.Equals(""))
            {
                MessageBox.Show("No se pueden deajar campos vacios");
            }
            else
            {
                try
                {
                    //VALIDAR USUARIOS NO REPETIDOS

                    UsuarioDAO.Nuevo(txtNombreRgister.Text, txtUserNameR.Text, txtUserNameR.Text, rdbAdmin.Checked);
                    MessageBox.Show("Usuario agregado exitosamente",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) // actualizar usuarios
        {
            actualizarUsuarios();
        }

        private void btnEliminarU_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar al usuario " + cmbEliminar.Text + "?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioDAO.eliminar(cmbEliminar.Text);

                MessageBox.Show("Usuario eliminado",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarUsuarios();

            }
        }


        private void btnAgregarN_Click(object sender, EventArgs e)
        {
            if (txtNombreN.Text.Equals("") || txtDescrpN.Text.Equals(""))
            {
                MessageBox.Show("No se pueden deajar campos vacios");
            }
            else
            {
                try
                {
                    BusinessDAO.Nuevo(txtNombreN.Text, txtDescrpN.Text);
                    MessageBox.Show("Negocio agregado exitosamente",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarNegocios();

        }

        private void btnEliminarN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "¿Seguro que desea eliminar el nogocio " + cmbNegocio.Text +
                " con todos los producto que contiene?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BusinessDAO.eliminar(cmbNegocio.Text);

                MessageBox.Show("Negocio eliminado",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarNegocios();
            }
        }


        private void btnAgregarProduc_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Equals(""))
            {
                MessageBox.Show("No se pueden deajar campos vacios");
            }
            else
            {
                try
                {
                    var cp = (Business) cmbProducto.SelectedItem;

                    ProductDAO.Nuevo(cp.id_Business, txtProducto.Text);
                    MessageBox.Show("producto agregado exitosamente",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnActualizarProd_Click(object sender, EventArgs e)
        {
            actualizarProducto();
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "¿Seguro que desea eliminar el producto " + cmbEliminarP.Text + " de todos los negocios?",
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductDAO.eliminar(cmbEliminarP.Text);

                MessageBox.Show("producto eliminado",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarProducto();
                actualizarNegocios();
            }

        }
        
        private void btnAgregarDir_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Equals(""))
            {
                MessageBox.Show("No se pueden deajar campos vacios");
            }
            else
            {
                try
                {
                    //var cp = (Business) cmbProducto.SelectedItem;

                    DireccionDAO.Nuevo(usuario.id_user, txtDireccion.Text);
                    MessageBox.Show("dirección agregado exitosamente",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnActualizarDir_Click(object sender, EventArgs e)
        {
            actualizarDirecciones();
        }


        private void btnEliminarDir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la dirección " + cmbNuevaDir.Text + "?", 
                "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DireccionDAO.eliminar(cmbNuevaDir.Text);
                
                MessageBox.Show("Dirección eliminado exitosamente", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarDirecciones();
            }
        }


        private void btnAgragarDir_Click(object sender, EventArgs e) // actualizar direccion
        {
            DireccionDAO.actualizar(txtDireccion.Text, usuario.id_user);

            MessageBox.Show("Dirección actualizada",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarDirecciones();
            actualizarProducto();

        }


        private void button1_Click_1(object sender, EventArgs e) // Agregar pedodos
        {
            
            var cp = (Product) cmbPedidoProd.SelectedItem;
            var cd = (Direccion) cmbPedidoDir.SelectedItem;

            OrdenDAO.Nuevo(dtpFechaPedido.Value, cp.id_product, cd.idaddres);
            MessageBox.Show("pedido agregado exitosamente",
                "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            actualizarPedidos();
        }

        private void btnEliminarPed_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtPedidoDelete.Text) > 0)
                {
                    if (MessageBox.Show("¿Seguro que desea eliminar el pedido con id " + txtPedidoDelete.Text + "?", 
                        "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OrdenDAO.eliminar(Convert.ToInt32(txtPedidoDelete.Text));
                
                        MessageBox.Show("Pedido eliminado exitosamente", 
                            "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                        actualizarPedidos();
                    }
                
                }
                else
                {
                    throw new InvalidFormatException("Error: Por favor verifique que los datos a ingresar sean validos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }


        private void btnVerPedidos_Click(object sender, EventArgs e)
        {
            actualizarPedidos();
        }
    }
}