using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Configuracion : ClaseMaestra
    {
        ConexionDB conexion = new ConexionDB();

        public int ConfiguracionId { get; set; }
        public int Semana { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public double ITBIS { get; set; }

        public Configuracion()
        {
            this.ConfiguracionId = 0;
            this.Semana = 0;
            this.Dia = 0;
            this.Mes = 0;
            this.Ano = 0;
            this.ITBIS = 0.0;
        }

        public Configuracion(int ConfiguracionId,int Semana, int Dia, int Mes, int Ano)
        {
            this.ConfiguracionId = ConfiguracionId;
            this.Semana = Semana;
            this.Dia = Dia;
            this.Mes = Mes;
            this.Ano = Ano;
        }

        public Configuracion(int ConfiguracionId)
        {
            this.ConfiguracionId = ConfiguracionId;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            try
            {
                retorno = conexion.Ejecutar(string.Format("insert into Configuraciones (Dia, Semana, Mes, Ano, ITBIS) values ({0},{1},{2},{3},{4}) ", this.Dia, this.Semana, this.Mes, this.Ano,this.ITBIS));
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
                retorno = conexion.Ejecutar(string.Format("update Configuraciones set Dia = {0}, Semana = {1}, Mes = {2}, Ano = {3}, ITBIS = {4}", this.Dia, this.Semana ,this.Mes, this.Ano,this.ITBIS));
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
                retorno = conexion.Ejecutar(string.Format("Delete from Configuraciones where ConfiguracionId = {0}", this.ConfiguracionId));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            bool retorno = false;
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Configuraciones where ConfiguracionId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.Dia = (int)dt.Rows[0]["Dia"];
                    this.Semana = (int)dt.Rows[0]["Semana"];
                    this.Mes = (int)dt.Rows[0]["Mes"];
                    this.Ano = (int)dt.Rows[0]["Ano"];
                    this.ITBIS = (double)dt.Rows[0]["ITBIS"];
                }
                else
                {
                    retorno = false;
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
            return conexion.ObtenerDatos("select " + Campos + " from Configuraciones where " + Condicion + " " + Orden);
        }
    }
}
