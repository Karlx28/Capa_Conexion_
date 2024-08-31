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

namespace Capa_Conexion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion =
        new SqlConnection
        ("Data Source=DESKTOP-L4680KA\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;");

            MessageBox.Show("Conexion creada");
            conexion.Open();
            string selectFrom = "SELECT * FROM [dbo].[Customers]";
            SqlCommand comando = new SqlCommand(selectFrom, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            conexion.Close();
            MessageBox.Show("Conexion cerrada");

        }
    }
}
