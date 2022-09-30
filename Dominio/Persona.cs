using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Dominio
{
     class Persona
    {
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        {
            IdPersona = 0;
            NombreCompleto = string.Empty;
            Dni = 0;
            FechaNacimiento = DateTime.Now;
        }
        public Persona(int id, string nombre,int dni,DateTime fecha)
        {
            IdPersona = id;
            NombreCompleto = nombre;    
            Dni = dni;
            FechaNacimiento=fecha;
        }
        public Persona(int id, string nombre)
        {
            IdPersona = id;
            NombreCompleto = nombre;
        }
        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
