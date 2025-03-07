using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion_Practica2
{
    public partial class Form1 : Form
    {
        private List<Vuelo> vuelos = new List<Vuelo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarVuelo_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposVuelo()) return;

            var vuelo = new Vuelo(
                txtCodigoVuelo.Text.Trim(),
                txtOrigen.Text.Trim(),
                txtDestino.Text.Trim(),
                dtpFechaSalida.Value,
                int.Parse(txtAsientosDisponibles.Text.Trim()));

            vuelos.Add(vuelo);
            ActualizarListaVuelos();
            LimpiarCamposVuelo();
        }

        private bool ValidarCamposVuelo()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoVuelo.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtOrigen.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtDestino.Text)) return false;
            if (!int.TryParse(txtAsientosDisponibles.Text, out int asientos) || asientos <= 0) return false;
            return true;
        }

        private void ActualizarListaVuelos()
        {
            listBoxVuelos.Items.Clear();
            foreach (var vuelo in vuelos.Where(v => v.AsientosDisponibles > 0))
                listBoxVuelos.Items.Add(vuelo);
        }

        private void LimpiarCamposVuelo()
        {
            txtCodigoVuelo.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            txtAsientosDisponibles.Clear();
            dtpFechaSalida.Value = DateTime.Now;
        }

        private void btnReservarVuelo_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposReserva()) return;

            var codigo = txtCodigoReserva.Text.Trim();
            var cantidad = int.Parse(txtCantidadReservas.Text.Trim());
            var vuelo = vuelos.FirstOrDefault(v => v.Codigo == codigo);

            if (vuelo == null)
            {
                MessageBox.Show("Vuelo no encontrado.");
                return;
            }

            if (vuelo.ReservarAsientos(cantidad))
            {
                ActualizarListaVuelos();
                MessageBox.Show("Reserva exitosa.");
                LimpiarCamposReserva();
            }
            else
                MessageBox.Show("No hay suficientes asientos disponibles.");
        }

        private bool ValidarCamposReserva()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoReserva.Text)) return false;
            if (!int.TryParse(txtCantidadReservas.Text, out int cantidad) || cantidad <= 0) return false;
            return true;
        }

        private void LimpiarCamposReserva()
        {
            txtCodigoReserva.Clear();
            txtCantidadReservas.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
   
    

