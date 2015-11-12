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

        public string ClienteImagen { get; set; }

        public string Nombre { get; set; }

        public int Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public double Peso { get; set; }

        public double Altura { get; set; }

        public Clientes()
        {
            this.ClienteId = 0;
            this.CiudadId = 0;
            this.CiudadNombre = "";
            this.ClienteImagen = "";
            this.Nombre = "";
            this.Sexo = 0;
            this.Direccion = "";
            this.Telefono = "";
            this.Celular = "";
            this.Peso = 0.0;
            this.Altura = 0.0;
        }

        public Clientes(int Clienteid, int Ciudadid, string Imagen, string Nombre, int Sexo, string Direccion, string Telefono, string Celular, double Peso, double Altura)
        {
            this.ClienteId = Clienteid;
            this.CiudadId = Ciudadid;
            this.ClienteImagen = Imagen;
            this.Nombre = Nombre;
            this.Sexo = Sexo;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Celular = Celular;
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
                dtCliente = conexion.ObtenerDatos(String.Format("select * from Clientes where ClienteId = {0} ", IdBuscado));
                this.CiudadId = (int)dtCliente.Rows[0]["CiudadId"];
                this.Nombre = dtCliente.Rows[0]["Nombre"].ToString();
                this.Sexo = (int)dtCliente.Rows[0]["Sexo"];
                this.Direccion = dtCliente.Rows[0]["Direccion"].ToString();
                this.Telefono = dtCliente.Rows[0]["Telefono"].ToString();
                this.Celular = dtCliente.Rows[0]["Celular"].ToString();
                this.Peso = (double)dtCliente.Rows[0]["Peso"];
                this.Altura = (double)dtCliente.Rows[0]["Altura"];

                dtCiudad = conexion.ObtenerDatos(String.Format("select * from Ciudades where CiudadId = {0}", this.CiudadId));
                this.CiudadNombre = dtCiudad.Rows[0]["Nombre"].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;

            try
            {
                retorno = conexion.Ejecutar(String.Format("update Clientes set CiudadId = {0}, Imagen = '{1}', Nombre = '{2}', Sexo = {3}, Direccion = '{4}', Telefono = '{5}', Celular = '{6}', Peso = {7}, Altura = {8} where ClienteId = {9} ",
                                                this.CiudadId, this.ClienteImagen, this.Nombre, this.Sexo, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura, this.ClienteId));
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
                retorno = conexion.Ejecutar(String.Format("insert into Clientes (CiudadId, Imagen, Nombre, Sexo, Direccion, Telefono, Celular, Peso, Altura) values ({0},'{1}','{2}',{3},'{4}','{5}','{6}',{7},{8})",
                                                this.CiudadId, this.ClienteImagen, this.Nombre, this.Sexo, this.Direccion, this.Telefono, this.Celular, this.Peso, this.Altura));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            return conexion.ObtenerDatos("select " + Campos + " from Clientes where " + Condicion + " " + Orden);
        }
    }
}
