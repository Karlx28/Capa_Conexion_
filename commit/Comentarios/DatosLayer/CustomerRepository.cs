using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla "Customers"
        public List<customers> ObtenerTodos()
        {
            // Abre una conexión con la base de datos
            using (var conexion = DataBase.GetSql())
            {
                // Construye la consulta SQL para seleccionar todos los campos de la tabla "Customers"
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT " + "\n";
                selectFrom = selectFrom + "      [CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Ejecuta la consulta SQL y devuelve los resultados
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crea una lista para almacenar los resultados obtenidos
                    List<customers> Customers = new List<customers>();

                    // Itera sobre los resultados para mapearlos a objetos "customers"
                    while (reader.Read())
                    {
                        var customers = LeerDelDataReader(reader);
                        Customers.Add(customers); // Agrega cada objeto a la lista
                    }
                    return Customers; // Devuelve la lista de clientes
                }
            }
        }

        // Método para obtener un cliente específico a partir de su ID
        public customers ObtenerPorID(string id)
        {
            // Establece la conexión a la base de datos
            using (var conexion = DataBase.GetSql())
            {
                // Prepara la consulta SQL para seleccionar un cliente específico
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + $"  WHERE CustomerID = @customerId";

                // Ejecuta la consulta con el ID del cliente como parámetro
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    // Asigna el valor del ID del cliente al parámetro de la consulta
                    comando.Parameters.AddWithValue("customerId", id);

                    // Ejecuta la consulta y obtiene el resultado
                    var reader = comando.ExecuteReader();

                    customers customers = null;

                    // Si existe un resultado, lo convierte en un objeto "customers"
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    return customers; // Devuelve el cliente encontrado
                }
            }
        }

        // Método para convertir una fila del SqlDataReader en un objeto "customers"
        public customers LeerDelDataReader(SqlDataReader reader)
        {
            // Crea un nuevo objeto "customers" y asigna los valores obtenidos del SqlDataReader
            customers customers = new customers();
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            return customers; // Devuelve el objeto "customers" con los datos asignados
        }
    }
}

