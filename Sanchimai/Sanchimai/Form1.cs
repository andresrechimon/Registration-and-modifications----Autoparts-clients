using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanchimai
{
    public partial class Form1 : Form
    {
        Datos dateli = new Datos();
        const int tam = 100000000;
        Clientes[] aClientes = new Clientes[tam];
        private bool crearClienteNuevo = false;
        int con;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < tam; i++)
            {
                aClientes[i] = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo(cboTipoDoc, "TIPO_IDENTIFICACION");
            CargarCombo(cboTipoCliente, "TIPOS_CLIENTES");
            CargarCombo(cboBarrio, "BARRIOS");
            CargarLista("CLIENTES");
        }

        private void CargarLista(string nombreTabla)
        {
            dateli.leerTabla(nombreTabla);
            con = 0;
            while (dateli.pLector.Read())
            {
                Clientes c = new Clientes();

                if (!dateli.pLector.IsDBNull(0))
                    c.pIdCliente = dateli.pLector.GetInt32(0);

                if (!dateli.pLector.IsDBNull(1))
                    c.pNombre = dateli.pLector.GetString(1);

                if (!dateli.pLector.IsDBNull(2))
                    c.pApellido = dateli.pLector.GetString(2);

                if (!dateli.pLector.IsDBNull(3))
                    c.pDocumento = dateli.pLector.GetInt64(3);

                if (!dateli.pLector.IsDBNull(4))
                    c.pTipoDocumento = dateli.pLector.GetInt32(4);

                if (!dateli.pLector.IsDBNull(5))
                    c.pTipoCliente = dateli.pLector.GetInt32(5);

                if (!dateli.pLector.IsDBNull(6))
                    c.pEmail = dateli.pLector.GetString(6);

                if (!dateli.pLector.IsDBNull(7))
                    c.pTelefono = dateli.pLector.GetInt64(7);

                if (!dateli.pLector.IsDBNull(8))
                    c.pCalle = dateli.pLector.GetString(8);

                if (!dateli.pLector.IsDBNull(9))
                    c.pAltura = dateli.pLector.GetInt32(9);

                if (!dateli.pLector.IsDBNull(10))
                    c.pBarrio = dateli.pLector.GetInt32(10);

                aClientes[con] = c;
                con++;
            }

            dateli.pLector.Close();
            dateli.desconectar();

            lstClientes.Items.Clear();

            for (int i = 0; i < con; i++)
            {
                lstClientes.Items.Add(aClientes[i].ToString());
            }
        }

        private void Habilitar(bool x)
        {
            txtNombre.Enabled = x;
            txtApellido.Enabled = x;
            txtDocumento.Enabled = x;
            cboTipoDoc.Enabled = x;
            cboTipoCliente.Enabled = x;
            txtEmail.Enabled = x;
            txtTelefono.Enabled = x;
            txtCalle.Enabled = x;
            txtAltura.Enabled = x;
            cboBarrio.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            btnEliminar.Enabled = x;
            lstClientes.Enabled = x;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            cboTipoDoc.SelectedIndex = -1;
            cboTipoCliente.SelectedIndex = -1;
            txtEmail.Clear();
            txtTelefono.Clear();
            txtCalle.Clear();
            txtAltura.Clear();
            cboBarrio.SelectedIndex = -1;
        }

        private bool validarCampos()
        {
            bool ok = true;

            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingrese: NOMBRE");
            }

            if (txtApellido.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingrese: APELLIDO");
            }

            if (txtDocumento.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingrese: DOCUMENTO");
            }

            if (cboTipoDoc.SelectedItem == null)
            {
                ok = false;
                errorProvider1.SetError(cboTipoDoc, "Ingrese: TIPO DOC.");
            }

            if (cboTipoCliente.SelectedItem == null)
            {
                ok = false;
                errorProvider1.SetError(cboTipoCliente, "Ingrese: TIPO CLIENTE");
            }

            if (txtEmail.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtEmail, "Ingrese: E-MAIL");
            }

            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Ingrese: TELÉFONO");
            }

            if (txtCalle.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCalle, "Ingrese: CALLE");
            }

            if (txtAltura.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtAltura, "Ingrese: ALTURA");
            }

            if (cboBarrio.SelectedItem == null)
            {
                ok = false;
                errorProvider1.SetError(cboBarrio, "Ingrese: BARRIO");
            }
            return ok;
        }

        private void BorrarMensajeError()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtDocumento, "");
            errorProvider1.SetError(cboTipoDoc, null);
            errorProvider1.SetError(cboTipoCliente, null);
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtTelefono, "");
            errorProvider1.SetError(txtCalle, "");
            errorProvider1.SetError(txtAltura, "");
            errorProvider1.SetError(cboBarrio, null);
        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = dateli.consultartabla(nombreTabla);
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            crearClienteNuevo = true;
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Saliendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Habilitar(true);
            crearClienteNuevo = true;
            Limpiar();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            Habilitar(true);
            crearClienteNuevo = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            BorrarMensajeError();
            if (validarCampos())
            {
                string consultaSQL = "";
                if (crearClienteNuevo)
                {
                    Clientes c = new Clientes();
                    c.pNombre = txtNombre.Text;
                    c.pApellido = txtApellido.Text;
                    c.pDocumento = Convert.ToInt64(txtDocumento.Text);
                    c.pTipoDocumento = (int)cboTipoDoc.SelectedValue;
                    c.pTipoCliente = (int)cboTipoCliente.SelectedValue;
                    c.pEmail = txtEmail.Text;
                    c.pTelefono = Convert.ToInt64(txtTelefono.Text);
                    c.pCalle = txtCalle.Text;
                    c.pAltura = Convert.ToInt32(txtAltura.Text);
                    c.pBarrio = (int)cboBarrio.SelectedValue;

                    //if (!existe(j.pCodigo))
                    //{
                    consultaSQL = $"INSERT INTO CLIENTES (nombre, apellido, doc, id_tipo_identificacion, id_tipo_cliente, email, telefono, calle, altura, id_barrio)VALUES('{c.pNombre}', '{c.pApellido}', '{c.pDocumento}',{c.pTipoDocumento},{c.pTipoCliente},'{c.pEmail}', '{c.pTelefono}', '{c.pCalle}', '{c.pAltura}', {c.pBarrio})";
                    //}
                    dateli.actualizar(consultaSQL);
                }
                //GUARDAR UN EDITAR
                else
                {
                    int i = lstClientes.SelectedIndex;
                    aClientes[i].pNombre = txtNombre.Text;
                    aClientes[i].pApellido = txtApellido.Text;
                    aClientes[i].pDocumento = int.Parse(txtDocumento.Text);
                    aClientes[i].pTipoDocumento = (int)cboTipoDoc.SelectedValue;
                    aClientes[i].pTipoCliente = (int)cboTipoCliente.SelectedValue;
                    aClientes[i].pEmail = txtEmail.Text;
                    aClientes[i].pTelefono = Convert.ToInt64(txtTelefono.Text);
                    aClientes[i].pCalle = txtCalle.Text;
                    aClientes[i].pAltura = int.Parse(txtAltura.Text);
                    aClientes[i].pBarrio = (int)cboBarrio.SelectedValue;

                    consultaSQL = $"UPDATE CLIENTES SET nombre='{aClientes[i].pNombre}', apellido='{aClientes[i].pApellido}', doc='{aClientes[i].pDocumento}',id_tipo_identificacion={aClientes[i].pTipoDocumento}, id_tipo_cliente={aClientes[i].pTipoCliente}, email='{aClientes[i].pEmail}', telefono='{aClientes[i].pTelefono}', calle='{aClientes[i].pCalle}', altura='{aClientes[i].pAltura}',id_barrio={aClientes[i].pBarrio}" + $"WHERE id_cliente={aClientes[i].pIdCliente}";

                    dateli.actualizar(consultaSQL);
                }
                CargarLista("CLIENTES");
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try 
            {
                if (MessageBox.Show("¿Estás seguro de eliminar el registro de este cliente?", "Eliminando...",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string consultaSQL = $"DELETE FROM CLIENTES WHERE id_cliente={aClientes[lstClientes.SelectedIndex].pIdCliente}";
                    dateli.actualizar(consultaSQL);
                    CargarLista("CLIENTES");
                    Habilitar(false);
                }
            }
            catch 
            {
                MessageBox.Show("No pueden eliminar clientes que tengan facturación registrada.");
            } 
        }
    }
    }

