using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita los estilos visuales para la aplicación
            Application.EnableVisualStyles();

            // Configura el modo de renderizado de texto para ser compatible con las versiones anteriores
            Application.SetCompatibleTextRenderingDefault(false);

            // Establece el formulario inicial que se mostrará al iniciar la aplicación
            Application.Run(new Form1());
        }
    }
}
