using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string FechaInicio { get; set; }
        public string Area { get; set; }
        ConexionDB conexion = new ConexionDB();

        public Usuarios()
        {
            IdUsuario = 0;
            Nombre = "";
            Contrasena = "";
            FechaInicio = "";
            Area = "";
        }

        public override bool Insertar()
        {
            try
            { 

                return conexion.Ejecutar(String.Format("Insert into Usuarios(Nombre,Contrasena,FechaInicio,Area)"+
                    " Values('{0}','{1}','{2}','{3}')",this.Nombre,this.Contrasena,this.FechaInicio,this.Area));

            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Editar()
        {
            try
            {
                return conexion.Ejecutar(String.Format("update Usuarios set Nombre = '{0}' , Contrasena='{1}', Area = '{2}' where UsuarioId = {3}",this.Nombre,this.Contrasena,this.Area,this.IdUsuario));               
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Eliminar()
        {
            try
            {
                return conexion.Ejecutar(String.Format("delete from Usuarios where UsuarioId = {0}",this.IdUsuario));
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InicioSesion()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("select UsuarioId from Usuarios where Nombre = '{0}' And Contrasena = '{1}'", this.Nombre, this.Contrasena));
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Permisos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = conexion.ObtenerDatos(String.Format("select Area from Usuarios where Nombre = '{0}'",this.Nombre));
                this.Area = dt.Rows[0]["Area"].ToString();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public override bool Buscar(int IdBuscado)
        {
            DataTable bt = new DataTable();
            try
            {
                bt = conexion.ObtenerDatos(String.Format("select * from Usuarios where UsuarioId = {0}", IdBuscado));
                this.Nombre = bt.Rows[0]["Nombre"].ToString();
                this.FechaInicio = bt.Rows[0]["FechaInicio"].ToString();
                this.Area = bt.Rows[0]["Area"].ToString();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return conexion.ObtenerDatos("Select "+Campos +" From Usuarios where "+Condicion +" "+Orden);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public DataTable GraficoUsuario()
        {
            try
            {
                return conexion.ObtenerDatos(String.Format("select Area,COUNT(Area) as Cantidad from Usuarios group by Area"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
