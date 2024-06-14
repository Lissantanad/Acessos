using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class Usuario : Form
    {
 
        public Usuario()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txt_usuario.Text;
            decimal contraseña;


            if (!decimal.TryParse(txt_contraseña.Text, out contraseña))
            {
                MessageBox.Show("Por favor, ingrese una contraseña válida.");
                return;
            }

            try
            {
                bool inicioSesionExitoso = N_usuario.VerificarUsuario(nombreUsuario, contraseña);

                if (inicioSesionExitoso)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");

                   Productos  formularioDi = new Productos();
                    formularioDi.Show();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Se produjo un error al iniciar sesión: " + ex.Message);
            }
        }
    }
}
