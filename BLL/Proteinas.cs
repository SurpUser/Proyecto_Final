using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Proteinas : ClaseMaestra
    {
        ConexionDB conexion = new ConexionDB();
        TiposProteinas TiposProteina = new TiposProteinas();

        public int ProteinaId { get; set; }
        public int TiposProteinaId { get; set; }
        public string NombreProteina { get; set; }
        public string  Nombre { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }

        public Proteinas()
        {
            this.ProteinaId = 0;
            this.TiposProteinaId = 0;
            this.NombreProteina = "";
            this.Nombre = ""; 
            this.Precio = 0.0;
            this.Costo = 0.0;
        }

        public Proteinas(int ProteinaID, int TiposProteinaId,string Nombreproteina, string Nombre, double Precio, double Costo)
        {
            this.ProteinaId = ProteinaID;
            this.TiposProteinaId = TiposProteinaId;
            this.NombreProteina = Nombreproteina;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Costo = Costo;
        }

        public Proteinas(int Proteinaid)
        {
            this.ProteinaId = ProteinaId;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            try
            {
                retorno = conexion.Ejecutar(string.Format("insert into Proteinas (TipoProteinaId, Nombre, Precio, Costo) values ({0},'{1}',{2},{3})",this.TiposProteinaId, this.Nombre, this.Precio, this.Costo));
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
                retorno = conexion.Ejecutar(string.Format("update Proteinas set TipoProteinaId = {0}, Nombre = '{1}', Precio = {2}, Costo = {3} where ProteinaId = {4}", this.TiposProteinaId, this.Nombre, this.Precio, this.Costo, this.ProteinaId));
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
                retorno = conexion.Ejecutar(string.Format("delete from Proteinas where ProteinaId = {0}", this.ProteinaId));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            bool retorno = false;
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Proteinas where ProteinaId = {0} ", IdBuscado));
                
                if (dt.Rows.Count > 0)
                {
                    this.TiposProteinaId = (int)dt.Rows[0]["TipoProteinaId"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Precio = (double)dt.Rows[0]["Precio"];
                    this.Costo = (double)dt.Rows[0]["Costo"];

                    dt2 = conexion.ObtenerDatos(string.Format("select Nombre from TiposProteinas where TipoProteinaId = {0} ", this.TiposProteinaId));

                    this.NombreProteina = dt2.Rows[0]["Nombre"].ToString();
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
                
            }
            catch (Exception ex)
            {
               throw ex;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            return conexion.ObtenerDatos("select " + Campos + " from Proteinas where " + Condicion + " " + Orden);
        }
    }
}
