using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Sanchimai
{
    class Datos
    {
        OleDbConnection Conexion = new OleDbConnection();
        OleDbCommand Comando = new OleDbCommand();
        OleDbDataReader Lector;
        string CadenaConexion = @"Provider=SQLNCLI11;Data Source=DESKTOP-IMM89LP\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=FABRICA_AUTOMOTRIZ";

        public Datos()
        {
            Conexion = new OleDbConnection();
            Conexion.ConnectionString = CadenaConexion;
            Comando = new OleDbCommand();
        }

        public Datos(string cadenaconexion)
        {
            Conexion = new OleDbConnection();
            Comando = new OleDbCommand();
        }

        public string pCadenaConexio { get => CadenaConexion; set => CadenaConexion = value; }
        public OleDbDataReader pLector { get => Lector; set => Lector = value; }

        public void conectar()
        {
            Conexion.ConnectionString = CadenaConexion;
            Conexion.Open();
            Comando.Connection = Conexion;
            Comando.CommandType = CommandType.Text;
        }

        public void desconectar()
        {
            Conexion.Close();
            Conexion.Dispose();
        }

        public DataTable consultartabla(string nombreTabla)
        {
            conectar();
            Comando.CommandText = "select * from " + nombreTabla;
            DataTable tabla = new DataTable();
            tabla.Load(Comando.ExecuteReader());

            desconectar();
            return tabla;
        }

        public void leerTabla(string nombreTabla)
        {
            conectar();

            Comando.CommandText = "select * from " + nombreTabla;
            Lector = Comando.ExecuteReader();
        }

        public void actualizar(string consultaSQL)
        {
            conectar();
            Comando.CommandText = consultaSQL;
            Comando.ExecuteNonQuery();
            desconectar();
        }
    }
}
