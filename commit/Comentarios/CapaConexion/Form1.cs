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
using DatosLayer;

namespace CapaConexion
{
    public partial class Form1 : Form
    {
        // Instancia del repositorio para acceder a los datos de los clientes
        CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario al cargar
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes y los muestra en el DataGridView
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers; // Asigna los datos obtenidos a la tabla
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Comentado: Filtro para buscar clientes por el nombre de la empresa
            // var filtro = customers.FindAll(X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configura la aplicación y parámetros de conexión
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnetionTimeout = 30;

            // Obtiene y guarda la cadena de conexión
            string cadenaConexion = DatosLayer.DataBase.ConnectionString;

            // Establece la conexión con la base de datos al cargar el formulario
            var conxion = DatosLayer.DataBase.GetSql();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente por su ID
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);

            // Si se encuentra un cliente, muestra su nombre; si no, muestra un mensaje de error
            if (cliente != null)
            {
                txtBuscar.Text = cliente.CompanyName;
                MessageBox.Show(cliente.CompanyName);
            }
            else
            {
                MessageBox.Show("Id no encontrado");
            }
        }
    }
}
