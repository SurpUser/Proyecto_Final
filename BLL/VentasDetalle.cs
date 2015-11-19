using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentasDetalle : ClaseMaestra
    {
        public int VentaDetalleId { get; set; }
        public int UsuarioId { get; set; }
        public int ProteinaId { get; set; }
        public int VentaId { get; set; }

        ConexionDB conexion = new ConexionDB();

        public VentasDetalle()
        {
            this.VentaDetalleId = 0;
            this.UsuarioId = 0;
            this.ProteinaId = 0;
            this.VentaId = 0;
        }

        public VentasDetalle(int VentaDetalleid, int Usuarioid, int Proteinaid, int Ventaid)
        {
            this.VentaDetalleId= VentaDetalleid;
            this.UsuarioId = Usuarioid;
            this.ProteinaId = Proteinaid;
            this.VentaId = Ventaid;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(string.Format("Select * from VentasDetalle where VentaDetalleId = {0} ", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ProteinaId = (int)dt.Rows[0]["ProteinaId"];
                    this.VentaId = (int)dt.Rows[0]["VentaId"];
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
                retorno = conexion.Ejecutar(String.Format("(Update VentasDetalle set UsuarioId = {0}, ProteinaId = {1}, VentaId = {2} where VentaDetalleId = {3}", this.UsuarioId, this.ProteinaId, this.VentaId, this.VentaDetalleId));
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
                retorno = conexion.Ejecutar(String.Format("Delete from VentasDetalle where VentaDetalleId = {0} ", this.VentaDetalleId));
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
                retorno = conexion.Ejecutar(String.Format("Insert into VentasDetalle (UsuarioId, ProteinaId, VentaId) Values ({0},{1},{2}) ", this.UsuarioId, this.ProteinaId, this.VentaId));
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
                dt = conexion.ObtenerDatos(String.Format("Select " + Campos + " from VentasDetalle where " + Condicion + " " + Orden));
            }
            catch (Exception e)
            {

                throw e;
            }
            return dt;
        }
    }
}
