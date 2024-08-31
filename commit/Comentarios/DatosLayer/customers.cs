using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Representa la tabla "Customers" de la base de datos
    public class customers
    {
        // Nombre de la compañía
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        // Dirección de la compañía
        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        // Número de teléfono de la compañía
        public string Phone { get; set; }

        public string Fax { get; set; }
    }
}

