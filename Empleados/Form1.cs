using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Empleados
{
    public partial class Form1 : Form
    {     
        Empleados Empleado = new Empleados();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)


        {
            

           


            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Debe ingresar su nombre");
                txtNombre.Focus();
                return;
            }
            errorProvider1.SetError(txtNombre, "");

            if (txtDUI.Text == "")
            {
                errorProvider1.SetError(txtDUI, "No ingreso el DUI");
                txtNombre.Focus();
                return;
            }

            errorProvider1.SetError(txtNombre, "");

            double Salario;

            if (!double.TryParse(txtSalario.Text, out Salario))

            {
                errorProvider1.SetError(txtSalario, "No ingresó el salario de forma correcta");
                txtSalario.Focus();
                return;
            }
            errorProvider1.SetError(txtSalario, "");




            
            Empleado.Nombre = txtNombre.Text;
            Empleado.Dui = txtDUI.Text;
            Empleado.Salario = Convert.ToDouble(txtSalario.Text);
            txtAFP.Text = Empleado.AFP(Empleado.Salario).ToString();
            labelRegistro.Text = "Se ha guardo su registro";

        }

        private void btnAFP_Click(object sender, EventArgs e)
        {
            {
                txtAFP.Text = Empleado.AFP(Empleado.Salario).ToString();

            }


        }

        private void btnISSS_Click(object sender, EventArgs e)
        {
          

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBempleados.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();
            string nombre = txtNombre.Text;
            string dui = txtDUI.Text;
            string salario = txtSalario.Text;
            string afp = txtAFP.Text;
            string cadena = "insert into [Empleados] (Nombre, DUI, Salario, AFP) values ('" + nombre + "','" + dui + "','" + salario + "','" + afp + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");

            conexion.Close();

            



        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Planilla.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();
            string cod = textBox1.Text;
            string cadena = "select nombre, dui from Empleados where Id=" + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                lblNombre.Text = registro["Nombre"].ToString();
                lblDUI.Text = registro["DUI"].ToString();
            }
            else
                MessageBox.Show("No existe un Empleado con el código ingresado");
            conexion.Close();

        }
    }
}
