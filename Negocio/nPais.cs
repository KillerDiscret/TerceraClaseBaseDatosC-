using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
     public class nPais
    {
        dPais paisd;
        public nPais()
        {
            paisd = new dPais();
        }
        public string Registrarpais(string nombre)
        {
            ePais pais = new ePais()
            {
                Nombrepais = nombre
            };
            return paisd.Insertar(pais);
        }
        public string Modificarpais(int idpais,string nombrepais)
        {
            ePais pais = new ePais()
            {
                Idpais = idpais,
                Nombrepais = nombrepais
            };
            return paisd.Modificar(pais);

        }
        public string EliminarPais(int id)
        {
            return paisd.Eliminar(id);
        }
        public List<ePais>Listarpais()
        {
            return paisd.ListarTodo();
        }




    }
}
