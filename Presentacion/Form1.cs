using CRUDequipo.Datos;
using CRUDequipo.Dominio;
using CRUDequipo.Servicios.Implementacion;
using CRUDequipo.Servicios.Intefaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDequipo
{
    public partial class FrmAlta : Form
    {
        private IServicio gestor;
        private Equipo nuevo;
        public FrmAlta()
        {
            InitializeComponent();
            gestor = new Servicio();
            nuevo = new Equipo();
        }

        private void FrmAlta_Load(object sender, EventArgs e)
        {
            ObtenerProximo();
            ObtenerPersonas();
            ObtenerPosiciones();
        }

        private void ObtenerPosiciones()
        {
            cboPosicion.ValueMember = "IdPosicion";
            cboPosicion.DisplayMember = "NombrePosicion";
            cboPosicion.DataSource = gestor.ObtenerPosiciones();
            cboPosicion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ObtenerPersonas()
        {
            cboPersona.ValueMember = "IdPersona";
            cboPersona.DisplayMember = "NombreCompleto";
            cboPersona.DataSource = gestor.ObtenerPersonas();
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ObtenerProximo()
        {
            int next = gestor.ObtenerProximo();
            if(next > 0)
            {
                lblNext.Text = "Equipo N°: " + next;
            }
            else
            {
                MessageBox.Show("No se puede obtener el numero de equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboPersona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una persona", "Control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if(cboPosicion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una posicion", "Control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if(txtCamiseta.Text == "")
            {
                MessageBox.Show("Debe elegir una camiseta ", "Control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            Persona persona = (Persona)cboPersona.SelectedItem;
            Posicion posicion = (Posicion)cboPosicion.SelectedItem;
            string camiseta = txtCamiseta.Text;
            Jugador j = new Jugador(persona, posicion, camiseta);
            nuevo.AgregarJugador(j);
            dgvEquipo.Rows.Add(j.Persona.IdPersona, j.Persona.NombreCompleto, j.Posicion.NombrePosicion, j.Camiseta);

            txtCant.Text = nuevo.CalcularTotal().ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre de equipo", "Control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (txtDirector.Text == "")
            {
                MessageBox.Show("Debe ingresar un director técnico", "Control", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            GuardarEquipo();
        
        }

        private void GuardarEquipo()
        {
            nuevo.Nombre = txtNombre.Text;
            nuevo.DirectorTecnico = txtDirector.Text;
            if(Helper.ObtenerInstancia().ConfirmarEquipo(nuevo))
            {
                MessageBox.Show("Se inserto el equipo con exito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No se pudo insertar el equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
