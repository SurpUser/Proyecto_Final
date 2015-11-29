using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Cuotas : ClaseMaestra
    {

        ConexionDB conexion = new ConexionDB();

        public int CuotaId { get; set; }
        public int ClienteId { get; set; }
        public string FechaCuota { get; set; }
        public double MontoCuota { get; set; }
        public string FechaVencimiento { get; set; }

        public override bool Buscar(int IdBuscado)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("select * from Cuotas where ClienteId = {0}",IdBuscado));
                ClienteId = (int)dt.Rows[0]["ClienteId"];
                FechaCuota = dt.Rows[0]["FechaCuota"].ToString();
                MontoCuota = (double)dt.Rows[0]["MontoCuota"];
                FechaVencimiento = dt.Rows[0]["FechaVence"].ToString();
                retorno = true;
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("update Cuotas set FechaCuota = '{0}',MontoCuota = {1},FechaVence = '{2}' where ClienteId ={3}", this.FechaCuota,this.MontoCuota,this.FechaVencimiento,this.ClienteId));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("Delete from Cuotas where ClienteId = ",this.ClienteId));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override bool Insertar()
        {
            bool retorno = false;

            try
            {
                 retorno = conexion.Ejecutar(String.Format("insert into Cuotas (ClienteId,FechaCuota,MontoCuota,FechaVence) values ({0},'{1}',{2},'{3}')", this.ClienteId,this.FechaCuota,this.MontoCuota,this.FechaVencimiento));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos("select " + Campos + " from Cuotas where " + Condicion + " " + Orden);
            }
            catch (Exception ex)
            {
                Seguridad.ErrorExcepcion(ex.ToString());
            }

            return dt;
        }
    }
}
