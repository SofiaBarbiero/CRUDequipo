using System.Collections.Generic;

namespace CRUDequipo.Dominio
{
    class Equipo
    {
        public string Nombre { get; set; }
        public string DirectorTecnico { get; set; }
        public List<Jugador> LstJugadores { get; set; }
        public Equipo()
        {
            Nombre = string.Empty;
            DirectorTecnico = string.Empty;
            LstJugadores = new List<Jugador>();
        }
        public Equipo(string nombre, string director, List<Jugador> jugadores)
        {            
            Nombre = nombre;
            DirectorTecnico = director;
            LstJugadores = jugadores;
        }

        public void AgregarJugador(Jugador j)
        {
            LstJugadores.Add(j);
        }

        public int CalcularTotal()
        {
            int total = 0;
            foreach(Jugador item in LstJugadores)
            {
                total++;
            }
            return total;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
