using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCliente { get; set; }
        public int ClienteId { get; set; }
        public int ProteinaId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double ITBS { get; set; }
        public string Fecha { get; set; }
        public string NCF { get; set; }
        public double TotalVenta { get; set; }
        public List<Proteinas> proteina { get; set; }

        ConexionDB conexion = new ConexionDB();

        public Ventas()
        {
            this.VentaId = 0;
            this.UsuarioId = 0;
            this.ClienteId = 0;
            this.ITBS = 0.0;
            this.Fecha = "";
            this.NCF = "";
            this.TotalVenta = 0.0;
            this.ProteinaId = 0;
            this.Cantidad = 0;
            this.Precio = 0.0;
            this.proteina = new List<Proteinas>();
        }

        public Ventas(int Ventaid, int Usuarioid, int Clienteid, double Itbs, string Fecha, string Nfc, double Totalventa,int ProteinaId,int Cantidad, double Precio)
        {
            this.VentaId = Ventaid;
            this.UsuarioId = Usuarioid;
            this.ClienteId = Clienteid;
            this.ITBS = Itbs;
            this.Fecha = Fecha;
            this.NCF = Nfc;
            this.TotalVenta = Totalventa;
            this.ProteinaId = ProteinaId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }

        public void AgregarProteinas(int ProteinaId,int Cantidad,double Importe)
        {
            this.proteina.Add(new Proteinas(ProteinaId,Cantidad,Importe));
        }

        public void AgregarProteinas(int ProteinaId,string Nombre,double Precio, int Cantidad, double Importe)
        {
            this.proteina.Add(new Proteinas(ProteinaId,Nombre,Precio, Cantidad, Importe));
        }

        public void LimpiarList()
        {
            this.proteina.Clear();
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dtVentas = new DataTable();
            DataTable dtVentaProteinas = new DataTable();
            bool retorno = false;

            try
            {
                dtVentas = conexion.ObtenerDatos(string.Format("select u.UsuarioId as UsuarioId, u.Nombre as NombreUsuario, c.ClienteId as ClienteId , c.Nombre as NombreCliente, v.NCF as NCF, v.Fecha as Fecha,v.ITBS as ITBS, v.TotalVenta as TotalVenta from Ventas v inner join Usuarios u " +
                    "on u.UsuarioId = v.UsuarioId inner join Clientes c on c.ClienteId = v.ClienteId where VentaId = {0}", IdBuscado));
                if (dtVentas.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dtVentas.Rows[0]["UsuarioId"];
                    this.NombreUsuario = dtVentas.Rows[0]["NombreUsuario"].ToString();
                    this.ClienteId = (int)dtVentas.Rows[0]["ClienteId"];
                    this.NombreCliente = dtVentas.Rows[0]["NombreCliente"].ToString();
                    this.ITBS = (double)dtVentas.Rows[0]["ITBS"];
                    this.Fecha = dtVentas.Rows[0]["Fecha"].ToString();
                    this.NCF = dtVentas.Rows[0]["NCF"].ToString();
                    this.TotalVenta = (double)dtVentas.Rows[0]["TotalVenta"];

                    dtVentaProteinas = conexion.ObtenerDatos(String.Format("select vd.ProteinaId as ProteinaId, p.Nombre as Nombre, p.Precio as Precio, vd.Cantidad as Cantidad, vd.Importe as Importe from VentasProteinas vd inner join " +
                        "Ventas v on vd.VentaId = v.VentaId inner join Proteinas p on vd.ProteinaId = p.ProteinaId where v.VentaId =  {0}", IdBuscado));
                     
                    LimpiarList();
                    foreach (DataRow row in dtVentaProteinas.Rows)
                    {
                        AgregarProteinas((int)row["ProteinaId"],(string)row["Nombre"],(double)row["Precio"],(int)row["Cantidad"],(double)row["Importe"]);
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
                retorno = conexion.Ejecutar(String.Format("update Ventas set UsuarioId = {0}, ClienteId = {1}, ITBS = {2}, Fecha = '{3}', NCF = '{4}', TotalVenta = {5} where VentaId = {6}", this.UsuarioId, this.ClienteId, this.ITBS, this.Fecha, this.NCF, this.TotalVenta, this.VentaId));
                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("delete from VentasProteinas where VentaId = {0}", this.VentaId));
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into VentasProteinas(UsuarioId,ProteinaId,VentaId,Cantidad,Importe) values({0},{1},{2},{3},{4})", this.UsuarioId, pro.ProteinaId, this.VentaId, pro.Cantidad, pro.Importe));
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
                retorno = conexion.Ejecutar("Delete from Ventas where VentaId = "+ this.VentaId+";" +"Delete from VentasProteinas where VentaId ="+ this.VentaId);
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
                retorno = conexion.Ejecutar(String.Format("Insert into Ventas (UsuarioId, ClienteId, ITBS, Fecha, NCF, TotalVenta) Values ({0},{1},{2},'{3}','{4}',{5}) ",
                                            this.UsuarioId, this.ClienteId, this.ITBS, this.Fecha, this.NCF, this.TotalVenta));
                if (retorno)
                {
                    this.VentaId = (int)conexion.ObtenerDatos(String.Format("select MAX(VentaId) as VentaId from Ventas")).Rows[0]["VentaId"];
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into VentasProteinas(UsuarioId,ProteinaId,VentaId,Cantidad,Importe) values({0},{1},{2},{3},{4})", this.UsuarioId, pro.ProteinaId, this.VentaId,pro.Cantidad,pro.Importe));
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
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(String.Format("Select " + Campos + " from Ventas where " +Condicion +" " +Orden));
            }
            catch (Exception e)
            {
                Seguridad.ErrorExcepcion(e.ToString());
            }

            return dt;
        }
    }
}
