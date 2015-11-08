using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    class TiposProteinas : ClaseMaestra
    {
        public int TipoProteinaId { get; set; }

        public string Nombre { get; set; }

        ConexionDB con = new ConexionDB();

        public TiposProteinas()
        {
            this.TipoProteinaId = 0;
            this.Nombre = "";
        }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return con.ObtenerDatos("select " + Campos + " from TiposProteinas where " + Condicion + " " + Orden);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ObtenerTipoProteinaId(string Nombre)
        {
            return con.ObtenerDatos(String.Format("select TipoProteinaId from TiposProteinas where Nombre = '{0}'", Nombre));
        }
    }
}
