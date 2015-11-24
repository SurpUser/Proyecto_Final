using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;

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
            bool retorno = false;

            try
            { 
                retorno = conexion.Ejecutar(String.Format("Insert into Usuarios(Nombre,Contrasena,FechaInicio,Area)"+
                    " Values('{0}','{1}','{2}','{3}')",this.Nombre,this.Contrasena,this.FechaInicio,this.Area));

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
                retorno = conexion.Ejecutar(String.Format("update Usuarios set Nombre = '{0}' , Contrasena='{1}', Area = '{2}' where UsuarioId = {3}",this.Nombre,this.Contrasena,this.Area,this.IdUsuario));               
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
                retorno = conexion.Ejecutar(String.Format("delete from Usuarios where UsuarioId = {0}",this.IdUsuario));
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public bool InicioSesion()
        {
            DataTable dt = new DataTable();
            bool retorno = false;

            try
            {
                dt = conexion.ObtenerDatos(String.Format("select UsuarioId from Usuarios where Nombre = '{0}' And Contrasena = '{1}'", this.Nombre, this.Contrasena));
                if (dt.Rows.Count > 0)
                {
                    this.IdUsuario = (int)dt.Rows[0]["UsuarioId"];
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }

            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public bool Permisos()
        {
            bool retorno = false;

            try
            {
                DataTable dt = new DataTable();
                dt = conexion.ObtenerDatos(String.Format("select Area from Usuarios where Nombre = '{0}'",this.Nombre));
                this.Area = dt.Rows[0]["Area"].ToString();
                retorno = true;
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            DataTable bt = new DataTable();
            bool retorno = false;

            try
            {
                bt = conexion.ObtenerDatos(String.Format("select * from Usuarios where UsuarioId = {0}", IdBuscado));
                this.Nombre = bt.Rows[0]["Nombre"].ToString();
                this.FechaInicio = bt.Rows[0]["FechaInicio"].ToString();
                this.Area = bt.Rows[0]["Area"].ToString();
                retorno = true;
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
                return conexion.ObtenerDatos("Select "+Campos +" From Usuarios where "+Condicion +" "+Orden);
            }
            catch (Exception e)
            {
                Seguridad.ErrorExcepcion(e.ToString());
            }

            return dt;
        }

        public DataTable GraficoUsuario()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(String.Format("select Area,COUNT(Area) as Cantidad from Usuarios group by Area"));
            }
            catch (Exception e)
            {
                Seguridad.ErrorExcepcion(e.ToString());
            }

            return dt;
        }
    }
}
