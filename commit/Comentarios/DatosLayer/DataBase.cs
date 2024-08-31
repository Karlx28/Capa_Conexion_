using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DatosLayer
{
    // Clase encargada de manejar la conexión a la base de datos
    public class DataBase
    {
        // Propiedad estática para definir el tiempo de espera en la conexión
        public static int ConnetionTimeout { get; set; }

        // Propiedad estática que representa el nombre de la aplicación conectada
        public static string ApplicationName { get; set; }

        // Propiedad que devuelve la cadena de conexión a la base de datos
        public static String ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión del archivo de configuración (app.config)
                String CadenaConexion = ConfigurationManager
                   .ConnectionStrings["NWConnection"]
                   .ConnectionString;

                // Utiliza SqlConnectionStringBuilder para personalizar la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Asigna el nombre de la aplicación si se ha especificado
                conexionBuilder.ApplicationName =
                ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera si se ha configurado, de lo contrario usa el predeterminado
                conexionBuilder.ConnectTimeout = (ConnetionTimeout > 0)
                    ? ConnetionTimeout : conexionBuilder.ConnectTimeout;

                // Retorna la cadena de conexión personalizada
                return conexionBuilder.ToString();
            }

        }

        // Método que devuelve una conexión SQL abierta
        public static SqlConnection GetSql()
        {
            // Crea una nueva instancia de conexión utilizando la cadena de conexión definida
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión para interactuar con la base de datos
            conexion.Open();

            // Retorna la conexión SQL ya abierta
            return conexion;
        }

    }
}
