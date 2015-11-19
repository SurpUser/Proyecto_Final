using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public double ITBS { get; set; }
        public string Fecha { get; set; }
        public string NCF { get; set; }
        public double TotalVenta { get; set; }
        public double Descuento { get; set; }

        ConexionDB conexion = new ConexionDB();

        public Ventas()
        {
            this.VentaId = 0;
            this.UsuarioId = 0;
            this.ClienteId = 0;
            this.ITBS = 0.0;
            this.Fecha = "";
            this.NCF = "";
            this.TotalVenta = 0.0;
            this.Descuento = 0.0;
        }

        public Ventas(int Ventaid, int Usuarioid, int Clienteid, double Itbs, string Fecha, string Nfc, double Totalventa, double Descuento)
        {
            this.VentaId = Ventaid;
            this.UsuarioId = Usuarioid;
            this.ClienteId = Clienteid;
            this.ITBS = Itbs;
            this.Fecha = Fecha;
            this.NCF = Nfc;
            this.TotalVenta = Totalventa;
            this.Descuento = Descuento;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("Select * from Ventas where VentaId = {0} ", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                    this.ITBS = (double)dt.Rows[0]["ITBS"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.NCF = dt.Rows[0]["NCF"].ToString();
                    this.TotalVenta = (double)dt.Rows[0]["TotalVenta"];
                    this.Descuento = (double)dt.Rows[0]["Descuento"];
                }            
            }
            catch (Exception e)
            {
                throw e;
            }

            return dt.Rows.Count > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("(Update Ventas set UsuarioId = {0}, ClienteId = {1}, ITBS = {2}, Fecha = '{3}', NCF = '{4}', TotalVenta = {5}, Descuento = {6} where VentaId = {7}", this.UsuarioId, this.ClienteId, this.ITBS, this.Fecha, this.NCF, this.TotalVenta, this.Descuento, this.VentaId));
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("Delete from Ventas where VentaId = {0} ", this.VentaId));
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }

        public override bool Insertar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("Insert into Ventas (UsuarioId, ClienteId, ITBS, Fecha, NCF, TotalVenta, Descuento) Values ({0},{1},{2},'{3}','{4}',{5},{6}) ",this.UsuarioId, this.ClienteId, this.ITBS, this.Fecha, this.NCF, this.TotalVenta, this.Descuento));
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("Select " + Campos + " from Ventas where " + Condicion + "" + Orden));
            }
            catch (Exception e)
            {

                throw e;
            }
            return dt;
        }
    }
}
