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

        public int ProteinaId { get; set; }

        public string  Nombre { get; set; }

        public double Precio { get; set; }

        public double ITBS { get; set; }

        public int Cantidad { get; set; }

        public double Costo { get; set; }

        public Proteinas()
        {
            this.ProteinaId = 0;
            this.Nombre = ""; 
            this.Precio = 0.0;
            this.ITBS = 0.0;
            this.Cantidad = 0;
            this.Costo = 0.0;
        }

        public Proteinas(int ProteinaID, string Nombre, double Precio, double Itbs, int Cantidad, double Costo)
        {
            this.ProteinaId = ProteinaID;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.ITBS = Itbs;
            this.Cantidad = Cantidad;
            this.Costo = Costo;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = con.Ejecutar(string.Format("insert into Proteinas (Nombre, Precio, ITBS, Cantidad, Costo) values ('{0}',{1},{2},{3},{4})", this.Nombre, this.Precio, this.ITBS, this.Cantidad, this.Costo));
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
                retorno = con.Ejecutar(string.Format("update Proteinas set Nombre = '{0}', Precio = {1}, ITBS = {2}, Cantidad = {3}, Costo = {4} where ProteinaId = {5}", this.Nombre, this.Precio, this.ITBS, this.Cantidad, this.Costo, this.ProteinaId));
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
            bool retorno = false;
            try
            {
                dt = con.ObtenerDatos(string.Format("select * from Proteinas where ProteinaId = {0} ", IdBuscado));
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Precio = (double)dt.Rows[0]["Precio"];
                this.ITBS = (double)dt.Rows[0]["ITBS"];
                this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                this.Costo = (double)dt.Rows[0]["Costo"];

                retorno = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            return con.ObtenerDatos("select " + Campos + " from Proteinas " + Condicion + " " + Orden);
        }
    }
}
