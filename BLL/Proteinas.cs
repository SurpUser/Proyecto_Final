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
        ConexionDB con = new ConexionDB();
        TiposProteinas TiposProteina = new TiposProteinas();

        public int ProteinaId { get; set; }

        public int TiposProteinaId { get; set; }

        public string  Nombre { get; set; }

        public double Precio { get; set; }

        public double ITBS { get; set; }

        public int Cantidad { get; set; }

        public double Costo { get; set; }

        public Proteinas()
        {
            this.ProteinaId = 0;
            this.TiposProteinaId = 0;
            this.Nombre = ""; 
            this.Precio = 0.0;
            this.ITBS = 0.0;
            this.Cantidad = 0;
            this.Costo = 0.0;
        }

        public Proteinas(int ProteinaID, int TiposProteinaId, string Nombre, double Precio, double Itbs, int Cantidad, double Costo)
        {
            this.ProteinaId = ProteinaID;
            this.TiposProteinaId = TiposProteinaId; 
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.ITBS = Itbs;
            this.Cantidad = Cantidad;
            this.Costo = Costo;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            try
            {
                retorno = con.Ejecutar(string.Format("insert into Proteinas (TipoProteinaId, Nombre, Precio, ITBS, Cantidad, Costo) values ({0},'{1}',{2},{3},{4},{5})",this.TiposProteinaId, this.Nombre, this.Precio, this.ITBS, this.Cantidad, this.Costo));
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
                retorno = con.Ejecutar(string.Format("update Proteinas set TipoProteinaId = {0}, Nombre = '{1}', Precio = {2}, ITBS = {3}, Cantidad = {4}, Costo = {5} where ProteinaId = {6}", this.TiposProteinaId, this.Nombre, this.Precio, this.ITBS, this.Cantidad, this.Costo, this.ProteinaId));
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
                retorno = con.Ejecutar(string.Format("delete from Proteinas where ProteinaId = {0}", this.ProteinaId));
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
                dt = con.ObtenerDatos(string.Format("select * from Proteinas where ProteinaId = {0} ", IdBuscado));
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Precio = (double)dt.Rows[0]["Precio"];
                this.ITBS = (double)dt.Rows[0]["ITBS"];
                this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                this.Costo = (double)dt.Rows[0]["Costo"];

                dt2 = con.ObtenerDatos(string.Format("select Nombre from TiposProteinas where TipoProteinaId = {0} ", this.TiposProteinaId));
                this.TiposProteina.Nombre = dt2.Rows[0]["Nombre"].ToString();

                retorno = true;
            }
            catch (Exception ex)
            {
                return false;
               // throw ex;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            return con.ObtenerDatos("select " + Campos + " from Proteinas where " + Condicion + " " + Orden);
        }
    }
}
