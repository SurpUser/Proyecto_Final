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
        public string NombreProveedor { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
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

        public void AgregarProteinas(int ProteinaId, int Cantidad,double SubTotal)
        {
            this.proteina.Add(new Proteinas(ProteinaId, Cantidad, SubTotal));
        }

        public void AgregarProteinas(int ProteinaId,string Nombre,double Costo,double Precio,int Cantidad,double SubTotal)
        {
            this.proteina.Add(new Proteinas(ProteinaId,Nombre,Costo,Precio,Cantidad,SubTotal));
        }

        public void LimpiarList()
        {
            this.proteina.Clear();
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dtCompras = new DataTable();
            DataTable dtCompraProteina = new DataTable();

            bool retorno = false;

            try
            {
                dtCompras = conexion.ObtenerDatos(string.Format("select pr.ProveedorId as ProveedorId, pr.NombreRepresentante as NombreProveedor ,u.UsuarioId as UsuarioId, u.Nombre as NombreUsuario, c.ITBS as ITBS, c.Monto as Monto, c.NCF as NCF, c.Fecha as Fecha from Compras c inner join Proveedores pr on pr.ProveedorId = c.ProveedorId inner join Usuarios u on u.UsuarioId = c.UsuarioId where CompraId = {0}", IdBuscado));

                if (dtCompras.Rows.Count > 0)
                {
                    this.ProveedorId = (int)dtCompras.Rows[0]["ProveedorId"];
                    this.NombreProveedor = dtCompras.Rows[0]["NombreProveedor"].ToString();
                    this.UsuarioId = (int)dtCompras.Rows[0]["UsuarioId"];
                    this.NombreUsuario = dtCompras.Rows[0]["NombreUsuario"].ToString();
                    this.ITBS = (double)dtCompras.Rows[0]["ITBS"];
                    this.Monto = (double)dtCompras.Rows[0]["Monto"];                
                    this.NCF = dtCompras.Rows[0]["NCF"].ToString();
                    this.Fecha = dtCompras.Rows[0]["Fecha"].ToString();

                    dtCompraProteina = conexion.ObtenerDatos(String.Format("select cd.ProteinaId as ProteinaId, p.Nombre as Nombre, p.Costo as Costo, cd.Cantidad as Cantidad, p.Precio as Precio, cd.SubTotal as SubTotal from ComprasProteinas cd inner join Compras c on cd.CompraId = c.CompraId inner join Proteinas p on cd.ProteinaId = p.ProteinaId where c.CompraId = {0}", IdBuscado));

                    LimpiarList();
                    foreach (DataRow row in dtCompraProteina.Rows)
                    {
                        this.AgregarProteinas((int)row["ProteinaId"],row["Nombre"].ToString(),(double)row["Costo"],(double)row["Precio"],(int)row["Cantidad"],(double)row["SubTotal"]);
                    }
                    retorno = true;
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
                retorno = conexion.Ejecutar(String.Format("update Compras set ProveedorId = {0}, UsuarioId = {1}, ITBS = {2}, Monto = {3}, NCF = '{4}', Fecha = '{5}' where CompraId = {6} ", this.ProveedorId, this.UsuarioId, this.ITBS, this.Monto, this.NCF, this.Fecha, this.CompraId));

                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("delete from ComprasProteinas where CompraId = {0}", this.CompraId));
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into ComprasProteinas(CompraId, ProteinaId, Cantidad, SubTotal) values({0},{1},{2},{3})", this.CompraId, pro.ProteinaId, pro.Cantidad, pro.Importe));
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
                retorno = conexion.Ejecutar(String.Format("insert into Compras (ProveedorId, UsuarioId, ITBS, Monto, NCF, Fecha) values ({0},{1},{2},{3},'{4}','{5}')", this.ProveedorId, this.UsuarioId, this.ITBS, this.Monto, this.NCF, this.Fecha));

                if (retorno)
                {
                    this.CompraId = (int)conexion.ObtenerDatos(String.Format("select MAX(CompraId) as CompraId from Compras")).Rows[0]["CompraId"];
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into ComprasProteinas(CompraId, ProteinaId, Cantidad, SubTotal) values({0},{1},{2},{3})", this.CompraId, pro.ProteinaId, pro.Cantidad, pro.Importe));
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
