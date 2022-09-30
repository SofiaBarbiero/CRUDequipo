using CRUDequipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Datos.Interfaz
{
    interface IDaoEquipo
    {
        int ObtenerProximo();
        List<Persona> ObtenerPersonas();
        List<Posicion> ObtenerPosiciones();
    }
}
