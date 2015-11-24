using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Clientes : ClaseMaestra
    {
        ConexionDB conexion = new ConexionDB();

        public int ClienteId { get; set; }

        public int CiudadId { get; set; }

        public string CiudadNombre { get; set; }

        public string Imagen { get; set; }

        public string Nombre { get; set; }

        public bool Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public double Peso { get; set; }

        public double Altura { get; set; }

        public string Fecha { get; set; }

        public Clientes()
        {
            this.ClienteId = 0;
            this.CiudadId = 0;
            this.CiudadNombre = "";
            this.Imagen = "";
            this.Nombre = "";
            this.Sexo = false;
            this.Direccion = "";
            this.Telefono = "";
            this.Celular = "";
            this.Peso = 0.0;
            this.Altura = 0.0;
            this.Fecha = "";
        }

        public Clientes(int Clienteid, int Ciudadid, string Imagen, string Nombre, bool Sexo, string Direccion, string Telefono, string Celular,string Fecha, double Peso, double Altura)
        {
            this.ClienteId = Clienteid;
            this.CiudadId = Ciudadid;
            this.Imagen = Imagen;
            this.Nombre = Nombre;
            this.Sexo = Sexo;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Fecha = Fecha;
            this.Peso = Peso;
            this.Altura = Altura;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dtCliente = new DataTable();
            DataTable dtCiudad = new DataTable();
            bool retorno = false;

            try
            {
                 dtCliente = conexion.ObtenerDatos(String.Format("select * from Clientes where ClienteId = {0}", IdBuscado));
                 this.CiudadId = (int)dtCliente.Rows[0]["CiudadId"];
                 this.Nombre = dtCliente.Rows[0]["Nombre"].ToString();
                 this.Imagen = dtCliente.Rows[0]["Imagen"].ToString();
                 this.Sexo = (bool)dtCliente.Rows[0]["Sexo"];
                 this.Direccion = dtCliente.Rows[0]["Direccion"].ToString();
                 this.Telefono = dtCliente.Rows[0]["Telefono"].ToString();
                 this.Celular = dtCliente.Rows[0]["Celular"].ToString();
                 this.Fecha = dtCliente.Rows[0]["Fecha"].ToString();
                 this.Peso = Convert.ToDouble(dtCliente.Rows[0]["Peso"]);
                 this.Altura = Convert.ToDouble(dtCliente.Rows[0]["Altura"]);
                 
                 dtCiudad = conexion.ObtenerDatos(String.Format("select * from Ciudades where CiudadId = {0}", this.CiudadId));
                 this.CiudadNombre = dtCiudad.Rows[0]["Nombre"].ToString();
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
                if (this.Sexo)
                {
                    retorno = conexion.Ejecutar(String.Format("update Clientes set CiudadId = {0}, Imagen = '{1}', Nombre = '{2}', Sexo = {3}, Direccion = '{4}', Telefono = '{5}', Celular = '{6}', Peso = {7}, Altura = {8},Fecha = '{9}' where ClienteId = {10} ",
                                                this.CiudadId, this.Imagen, this.Nombre, 1, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura, this.Fecha, this.ClienteId));
                }
                else
                {
                    retorno = conexion.Ejecutar(String.Format("update Clientes set CiudadId = {0}, Imagen = '{1}', Nombre = '{2}', Sexo = {3}, Direccion = '{4}', Telefono = '{5}', Celular = '{6}', Peso = {7}, Altura = {8},Fecha = '{9}' where ClienteId = {10} ",
                                                this.CiudadId, this.Imagen, this.Nombre, 0, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura, this.Fecha, this.ClienteId));
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("delete from Clientes where ClienteId = {0}" , this.ClienteId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Insertar()
        {
            bool retorno = false;

            try
            {
                if (this.Sexo)
                {
                    retorno = conexion.Ejecutar(String.Format("insert into Clientes (CiudadId, Imagen, Nombre, Sexo, Direccion, Telefono, Celular, Peso, Altura,Fecha) values ({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}')",
                                               this.CiudadId, this.Imagen, this.Nombre, 1, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura, this.Fecha));
                }
                else
                {
                    retorno = conexion.Ejecutar(String.Format("insert into Clientes (CiudadId, Imagen, Nombre, Sexo, Direccion, Telefono, Celular, Peso, Altura,Fecha) values ({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}')",
                                                this.CiudadId, this.Imagen, this.Nombre, 0, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura, this.Fecha));
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            return conexion.ObtenerDatos("select " + Campos + " from Clientes where " + Condicion + " " +Orden);
        }
    }
}
