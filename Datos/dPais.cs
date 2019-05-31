using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dPais
    {
        Database db = new Database();
        public string Insertar(ePais obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into pais (nombre) values ('{0}')", obj.Nombrepais);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto dato";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Modificar(ePais obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("update pais set nombre='{0}' where idpais={1}", obj.Nombrepais, obj.Idpais);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico dato";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from pais where idpais={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino dato";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<ePais>ListarTodo()
        {
            try
           {
                List<ePais> lspais = new List<ePais>();
                ePais pais = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select idpais,nombre from pais", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pais = new ePais();
                    pais.Idpais = (int)reader["idpais"];
                    pais.Nombrepais = (string)reader["nombre"];
                    lspais.Add(pais);

                }
                reader.Close();
                return lspais;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }


        }
        
        
          
    }
}
