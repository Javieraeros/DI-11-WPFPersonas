using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_11_WPFPersonas_ENT
{
    public class Persona
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Persona(){
            id = 0;
            Nombre = "";
            Apellidos = "";
            FechaNac = new DateTime();
            direccion = "Mi casa";
            telefono = "teléeefono";
            }

        public Persona(int parId,string nombre, string apellidos, DateTime fechaNac,
            string direccion,string telefono)
        {
            this.id = parId;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNac = fechaNac;
            this.telefono = telefono;
            this.direccion = direccion;
        }
    }
}
