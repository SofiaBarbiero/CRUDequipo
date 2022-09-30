using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRUDequipo.Dominio;
using System.Net.Http.Headers;

namespace CRUDequipo.Datos
{
     class Helper
    {
        SqlConnection cnn = new SqlConnection(Properties.Resources.cnnString);
        private static Helper instancia;

        public static Helper ObtenerInstancia()
        {
            if(instancia == null)
                instancia = new Helper();
            return instancia;
        }
        public int ObtenerProximo(string sp_nombre, string pOut_nombre)
        {
            cnn.Open();
            SqlCommand cmdNext = new SqlCommand();
            cmdNext.Connection = cnn;
            cmdNext.CommandText = sp_nombre;
            cmdNext.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = pOut_nombre;
            pOut.Direction = ParameterDirection.Output;
            pOut.DbType = DbType.Int32;
            cmdNext.Parameters.Add(pOut);
            cmdNext.ExecuteReader();
            cnn.Close();
            return (int)pOut.Value;
        }

        public DataTable CargarCombo(string sp)
        {
            DataTable table = new DataTable();
            SqlCommand cmdCombo = new SqlCommand();
            cnn.Open();
            cmdCombo.Connection = cnn;
            cmdCombo.CommandType = CommandType.StoredProcedure;
            cmdCombo.CommandText = sp;
            table.Load(cmdCombo.ExecuteReader());
            cnn.Close();
            return table;
        }

        public bool ConfirmarEquipo(Equipo oEquipo)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                SqlCommand cmdMaestro = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction = t;
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.CommandText = "sp_insert_equipo";
                cmdMaestro.Parameters.AddWithValue("@nombre", oEquipo.Nombre);
                cmdMaestro.Parameters.AddWithValue("@dt", oEquipo.DirectorTecnico);
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id_equipo";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(pOut);
                cmdMaestro.ExecuteNonQuery();

                int idEquipo = (int)pOut.Value;
                foreach(Jugador j in oEquipo.LstJugadores)
                {
                    SqlCommand cmdDetalle = new SqlCommand();
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = t;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.CommandText = "sp_cargar_jugador";
                    cmdDetalle.Parameters.AddWithValue("@id_persona", j.Persona.IdPersona);
                    cmdDetalle.Parameters.AddWithValue("@id_posicion", j.Posicion.IdPosicion);
                    cmdDetalle.Parameters.AddWithValue("@camiseta", j.Camiseta);
                    cmdDetalle.Parameters.AddWithValue("@id_equipo", idEquipo);
                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch(Exception)
            {
                if(t != null)
                {
                    t.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return ok;
        }
    }
}
