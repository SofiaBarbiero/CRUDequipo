using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Dominio
{
    class Posicion
    {
        public int IdPosicion { get; set; } 
        public string NombrePosicion { get; set; }

        public Posicion()
        {
            IdPosicion = 0;
            NombrePosicion = string.Empty;
        }
        public Posicion(int id,string nombre)
        {
            IdPosicion = id;
            NombrePosicion = nombre;
        }
        public override string ToString()
        {
            return NombrePosicion;
        }
    }
}
