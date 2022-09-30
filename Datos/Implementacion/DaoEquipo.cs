using CRUDequipo.Datos.Interfaz;
using CRUDequipo.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUDequipo.Datos.Implementacion
{
    class DaoEquipo : IDaoEquipo
    {
        public List<Persona> ObtenerPersonas()
        {
            List<Persona> lst = new List<Persona>();
            string sp = "sp_cargar_personas";
            DataTable table = Helper.ObtenerInstancia().CargarCombo(sp);
            foreach(DataRow dr in table.Rows)
            {
                int id = int.Parse(dr["id_persona"].ToString());
                string nombre = dr["nombre_completo"].ToString();
                Persona p = new Persona(id, nombre);
                lst.Add(p);
            }
            return lst;
            
        }

        public List<Posicion> ObtenerPosiciones()
        {
            List<Posicion> lst = new List<Posicion>();
            string sp = "sp_cargar_posiciones";
            DataTable table = Helper.ObtenerInstancia().CargarCombo(sp);
            foreach(DataRow dr in table.Rows)
            {
                int id = int.Parse(dr["id_posicion"].ToString());
                string nombre = dr["nombre_posicion"].ToString();
                Posicion p = new Posicion(id, nombre);
                lst.Add(p);
            }
            return lst;
        }

        public int ObtenerProximo()
        {
            string sp = "sp_proximo";
            string output = "@next";
            return Helper.ObtenerInstancia().ObtenerProximo(sp, output);
        }
    }
}
