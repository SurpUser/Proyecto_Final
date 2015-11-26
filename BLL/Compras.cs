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
    public class Compras : ClaseMaestra
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public int ProteinaId { get; set; }
        public double ITBS { get; set; }
        public double Monto { get; set; }
        public string NCF { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public List<Proteinas> proteina { get; set; }

        ConexionDB conexion = new ConexionDB();

        public Compras()
        {
            this.CompraId = 0;
            this.ProveedorId = 0;
            this.UsuarioId = 0;
            this.ProteinaId = 0;
            this.ITBS = 0.0;
            this.Monto = 0.0;
            this.NCF = "";
            this.Fecha = "";
            this.Cantidad = 0;
            this.proteina = new List<Proteinas>();
        }

        public void AgregarProteinas(int ProteinaId, int Cantidad,double Importe)
        {
            this.proteina.Add(new Proteinas(ProteinaId, Cantidad,Importe));
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtCompra = new DataTable();

            bool retorno = false;

            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Compras where CompraId = {0}", IdBuscado));
                dtCompra = conexion.ObtenerDatos(string.Format("select pr.ProveedorId as ProveedorId, pr.NombreRepresentante as NombreProveedor ,u.UsuarioId as UsuarioId, u.Nombre as NombreUsuario, p.ProteinaId as ProteinaId , p.Nombre as NombreProteina, v.ITBS as ITBS, v.Monto as Monto, v.NCF as NCF, v.Fecha as Fecha, v.Cantidad as Cantidad from Compras v inner join Proveedores pr on pr.ProveedorId = v.ProveedorId inner join Usuarios u " +
                    "on u.UsuarioId = v.UsuarioId inner join Proteina p on p.ClienteId = v.ClienteId where CompraId = {0}", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.ProveedorId = (int)dt.Rows[0]["ProveedorId"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ProteinaId = (int)dt.Rows[0]["ProteinaId"];
                    this.ITBS = (double)dt.Rows[0]["ITBS"];
                    this.Monto = (double)dt.Rows[0]["Monto"];                
                    this.NCF = dt.Rows[0]["NCF"].ToString();
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                }
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
            StringBuilder comando = new StringBuilder();

            try
            {
                retorno = conexion.Ejecutar(String.Format("update Compras set ProveedorId = {0}, ProteinaId = {1}, UsuarioId = {2}, ITBS = {3}, Monto = {4}, NCF = '{5}', Fecha = '{6}', Cantidad = {7} where CompraId = {8} ", this.ProveedorId, this.ProteinaId, this.UsuarioId, this.ITBS, this.Monto, this.NCF, this.Fecha, this.Cantidad, this.CompraId));

                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("delete from ComprasProteinas where CompraId = {0}", this.CompraId));
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into ComprasProteinas(CompraId, ProteinaId, Cantidad, Costo) values({0},{1},{2},{3})", this.CompraId, pro.ProteinaId, pro.Cantidad, pro.Costo));
                    }
                    retorno = conexion.Ejecutar(comando.ToString());
                }
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
                retorno = conexion.Ejecutar(String.Format("delete from Compras where CompraId = {0};"+ "delete from ComprasProteinas where CompraId = {0}", this.CompraId));
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
            StringBuilder comando = new StringBuilder();
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Compras (ProveedorId, ProteinaId, UsuarioId, ITBS, Monto, NCF, Fecha, Cantidad) values ({0},{1},{2},{3},{4},'{5}','{6}',{7})", this.ProveedorId, this.ProteinaId, this.UsuarioId, this.ITBS, this.Monto, this.NCF, this.Fecha, this.Cantidad));

                if (retorno)
                {
                    this.CompraId = (int)conexion.ObtenerDatos(String.Format("select MAX(CompraId) as CompraId from Compras")).Rows[0]["CompraId"];
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into ComprasProteinas(CompraId, ProteinaId, Cantidad, Costo) values({0},{1},{2},{3})", this.CompraId, pro.ProteinaId, pro.Cantidad, pro.Costo));
                    }
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DataTable dtCompras = new DataTable();
            try
            {
               dtCompras = conexion.ObtenerDatos(String.Format("select " + Campos + " from Compras where " + Condicion + "" + Orden));
            }
            catch (Exception ex)
            {
                Seguridad.ErrorExcepcion(ex.ToString());
            }

            return dtCompras;
        }
    }
}
