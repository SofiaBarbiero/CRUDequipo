using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Dominio
{
     class Jugador : Persona
    {
        public Persona Persona { get; set; }        
        public string Camiseta { get; set; }
        public Posicion Posicion { get; set; }
        public Jugador()
        {
            Persona = new Persona();            
            Camiseta = string.Empty;
        }
        public Jugador(Persona per, Posicion tipo, string cam)
        {
            Persona = per;
            Camiseta = cam;
            Posicion = tipo;
        }

        public override string ToString()
        {
            return Camiseta;
        }

    }
}
