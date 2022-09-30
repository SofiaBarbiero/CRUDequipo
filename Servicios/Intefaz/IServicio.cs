using CRUDequipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Servicios.Intefaz
{
    interface IServicio
    {
        int ObtenerProximo();
        List<Persona> ObtenerPersonas();
        List<Posicion> ObtenerPosiciones();
    }
}
