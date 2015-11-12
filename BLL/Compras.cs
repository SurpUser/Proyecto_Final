using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Compras : ClaseMaestra
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public int ProteinaId { get; set; }
        public float ITBS { get; set; }
        public float Monto { get; set; }
        public string NCF { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
       
        ConexionDB conexion = new ConexionDB();

        public override bool Buscar(int IdBuscado)
        {
            try
            {
                conexion.ObtenerDatos("");
            }
            catch (Exception e)
            {

                throw e;

            }
            return false;
        }

        public override bool Editar()
        {
            try
            {
                return conexion.Ejecutar(String.Format(""));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override bool Eliminar()
        {
            try
            {
                return conexion.Ejecutar(String.Format(""));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public override bool Insertar()
        {
            try
            {
                return conexion.Ejecutar(String.Format(""));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DataTable dtCompras = new DataTable();
            try
            {
               dtCompras = conexion.ObtenerDatos(String.Format(" select "+Campos +" from Compras where "+Condicion +""+Orden));
            }
            catch (Exception e)
            {

                throw e;
            }
            return dtCompras;
        }
    }
}
