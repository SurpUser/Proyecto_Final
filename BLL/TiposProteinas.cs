using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TiposProteinas : ClaseMaestra
    {
        public int TipoProteinaId { get; set; }

        public string Nombre { get; set; }

        ConexionDB con = new ConexionDB();

        public TiposProteinas()
        {
            this.TipoProteinaId = 0;
            this.Nombre = "";
        }

        public TiposProteinas(int Id, string Nombre)
        {
            this.TipoProteinaId = Id;
            this.Nombre = Nombre;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            bool retorno = false;

            try
            {
                dt = con.ObtenerDatos(string.Format("select Nombre from TiposProteinas where TipoProteinaId = {0} ", IdBuscado));
                this.Nombre = dt.Rows[0]["Nombre"].ToString();

                retorno = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Editar()
        {          
            bool retorno = false;
            try
            {
                retorno = con.Ejecutar(string.Format("update TiposProteinas set Nombre = '{0}' where TipoProteinaId = {1} ", this.Nombre, this.TipoProteinaId));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = con.Ejecutar(string.Format("delete from TiposProteinas where TipoProteinaId = {0} ", this.TipoProteinaId));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = con.Ejecutar(string.Format("insert into TiposProteinas (Nombre) values ('{0}') ", this.Nombre));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return con.ObtenerDatos("select " + Campos + " from TiposProteinas where " + Condicion + " " + Orden);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ObtenerTipoProteinaId(string Nombre)
        {
            return con.ObtenerDatos(String.Format("select TipoProteinaId from TiposProteinas where Nombre = '{0}' ", Nombre));
        }
    }
}
