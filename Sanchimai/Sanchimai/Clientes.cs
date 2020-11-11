using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanchimai
{
    class Clientes
    {
        int idCliente;
        string nombre;
        string apellido;
        Int64 documento;
        int tipoDocumento;
        int tipoCliente;
        string email;
        Int64 telefono;
        string calle;
        int altura;
        int barrio;

        public Clientes(int idCliente, string nombre, string apellido, Int64 documento, int tipoDocumento, int tipoCliente, string email, Int64 telefono, string calle, int altura, int barrio)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.tipoDocumento = tipoDocumento;
            this.tipoCliente = tipoCliente;
            this.telefono = telefono;
            this.email = email;
            this.calle = calle;
            this.altura = altura;
            this.barrio = barrio;
        }

        public Clientes()
        {
            this.idCliente = 0;
            this.nombre = "";
            this.apellido = "";
            this.documento = 0;
            this.tipoDocumento = 0;
            this.tipoCliente = 0;
            this.email = "";
            this.telefono = 0;
            this.calle = "";
            this.altura = 0;
            this.barrio = 0;
        }

        public int pIdCliente { get => idCliente; set => idCliente = value; }
        public string pNombre { get => nombre; set => nombre = value; }
        public string pApellido { get => apellido; set => apellido = value; }
        public Int64 pDocumento { get => documento; set => documento = value; }
        public int pTipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public int pTipoCliente { get => tipoCliente; set => tipoCliente = value; }
        public string pEmail { get => email; set => email = value; }
        public Int64 pTelefono { get => telefono; set => telefono = value; }
        public string pCalle { get => calle; set => calle = value; }
        public int pAltura { get => altura; set => altura = value; }
        public int pBarrio { get => barrio; set => barrio = value; }

        public override string ToString()
        {
            return apellido + ", " + nombre;
        }
    }
}
