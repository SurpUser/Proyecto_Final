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
            throw new NotImplementedException();
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
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
