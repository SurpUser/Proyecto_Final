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
            bool retorno = false;

            try
            {
                DataTable dtCiudad = new DataTable();
                dtCiudad = conexion.ObtenerDatos(string.Format("select * from Ciudades where CiudadId = {0}",IdBuscado));
                this.Nombre = dtCiudad.Rows[0]["Nombre"].ToString();
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
               retorno = conexion.Ejecutar(String.Format("update Ciudades set Nombre = '{0}' where CiudadId = {1}",this.Nombre,this.CiudadId));
                
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
                retorno = conexion.Ejecutar(String.Format("delete from Ciudades where CiudadId = {0};",this.CiudadId));
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
                retorno = conexion.Ejecutar(String.Format("insert into Ciudades(Nombre) values('{0}')",this.Nombre));
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
                dt = conexion.ObtenerDatos("select "+Campos +" from Ciudades where "+Condicion +" "+Orden);
            }
            catch (Exception ex)
            {
                Seguridad.ErrorExcepcion(ex.ToString());
            }

            return dt;
        }
    }
}
