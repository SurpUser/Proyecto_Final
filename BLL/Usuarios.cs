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
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("select IdUsuario from Usuarios where Nombre = '{0}' And Contrasena = '{1}'",this.Nombre,this.Contrasena));
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

                throw;
            }
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return conexion.ObtenerDatos("Select "+Campos +" From Usuarios "+Condicion +" "+Orden);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
