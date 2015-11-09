using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Ciudades : ClaseMaestra
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }

        ConexionDB conexion = new ConexionDB();

        public Ciudades()
        {
            this.CiudadId = 0;
            this.Nombre = "";
        }

        public override bool Buscar(int IdBuscado)
        {
            try
            {
                DataTable dtCiudad = new DataTable();
                dtCiudad = conexion.ObtenerDatos(string.Format("select * from Ciudades where CiudadId = {0}",IdBuscado));
                this.Nombre = dtCiudad.Rows[0]["Nombre"].ToString();
                return true;
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
               return conexion.Ejecutar(String.Format("update Ciudades set Nombre = '{0}'",this.Nombre));
                
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
                return conexion.Ejecutar(String.Format("delete from Ciudades where CiudadId = {0}",this.CiudadId));
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Insertar()
        {
            try
            {
                return conexion.Ejecutar(String.Format("insert into Ciudades(Nombre) values('{0}')",this.Nombre));
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
                return conexion.ObtenerDatos("select "+Campos +" from Ciudades where "+Condicion +" "+Orden);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ObtenerCiudadId(string Nombre)
        {
            return conexion.ObtenerDatos(String.Format("select CiudadId from Ciudades where Nombre = '{0}'",Nombre)); 
        }
    }
}
