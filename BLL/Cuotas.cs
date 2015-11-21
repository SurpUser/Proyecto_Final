﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Cuotas : ClaseMaestra
    {
        public int CuotaId { get; set; }
        public int ClienteId { get; set; }
        public string FechaCuota { get; set; }
        public double MontoCuota { get; set; }
        ConexionDB conexion = new ConexionDB();

        public override bool Buscar(int IdBuscado)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("select * from Cuotas where ClienteId = {0}",IdBuscado));
                ClienteId = (int)dt.Rows[0]["ClienteId"];
                FechaCuota = dt.Rows[0]["FechaCuota"].ToString();
                MontoCuota = (double)dt.Rows[0]["MontoCuota"];
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
                retorno = conexion.Ejecutar(String.Format("update Cuotas set ClienteId = {0}, FechaCuota = '{1}',MontoCuota = {2} where ClienteId = {0}",this.ClienteId,this.FechaCuota,this.MontoCuota));
            }
            catch (Exception)
            {
                retorno = false;               
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            try
            {
                return conexion.Ejecutar(String.Format("Delete from Cuotas where ClienteId = ",this.ClienteId));
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Insertar()
        {
            bool retorno = false;

            try
            {
                    retorno = conexion.Ejecutar(String.Format("insert into Cuotas (ClienteId,FechaCuota,MontoCuota) values ({0},'{1}',{2})",this.ClienteId,this.FechaCuota,this.MontoCuota));
            }
            catch (Exception)
            {

                retorno = false;
            }
            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return conexion.ObtenerDatos("select " + Campos + " from Cuotas where " + Condicion + " " + Orden);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
