using CRUDequipo.Datos.Implementacion;
using CRUDequipo.Datos.Interfaz;
using CRUDequipo.Dominio;
using CRUDequipo.Servicios.Intefaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDequipo.Servicios.Implementacion
{
    class Servicio : IServicio
    {
        private IDaoEquipo dao;

        public Servicio()
        {
            dao = new DaoEquipo();
        }

        public List<Persona> ObtenerPersonas()
        {
            return dao.ObtenerPersonas();
        }

        public List<Posicion> ObtenerPosiciones()
        {
            return dao.ObtenerPosiciones();
        }

        public int ObtenerProximo()
        {
            return dao.ObtenerProximo();
        }
    }
}
