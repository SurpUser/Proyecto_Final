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

        public void AgregarProteinas(int ProteinaId,int Cantidad)
        {
            this.proteina.Add(new Proteinas(ProteinaId,Cantidad));
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            bool retorno = false;

            try
            {
                dt = conexion.ObtenerDatos(string.Format("Select * from Ventas where VentaId = {0} ", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                    this.ITBS = (double)dt.Rows[0]["ITBS"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.NCF = dt.Rows[0]["NCF"].ToString();
                    this.TotalVenta = (double)dt.Rows[0]["TotalVenta"];

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
                retorno = conexion.Ejecutar(String.Format("(Update Ventas set UsuarioId = {0}, ClienteId = {1}, ITBS = {2}, Fecha = '{3}', NCF = '{4}', TotalVenta = {5} where VentaId = {7}", this.UsuarioId, this.ClienteId, this.ITBS, this.Fecha, this.NCF, this.TotalVenta, this.VentaId));
                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("delete from VentasProteinas where VentaId = {0}", this.VentaId));
                    foreach (var pro in proteina)
                    {
                        comando.AppendLine(String.Format("insert into VentasProteinas(UsuarioId,ProteinaId,VentaId,Cantidad) values({0},{1},{2},{3})", this.UsuarioId, pro.ProteinaId, this.VentaId,pro.Cantidad));
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
                        comando.AppendLine(String.Format("insert into VentasProteinas(UsuarioId,ProteinaId,VentaId,Cantidad) values({0},{1},{2},{3})", this.UsuarioId, pro.ProteinaId, this.VentaId,pro.Cantidad));
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
