using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_Practica2
{
    public class Vuelo
    {
        public string Codigo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public int AsientosDisponibles { get; set; }

        public Vuelo(string codigo, string origen, string destino, DateTime fechaSalida, int asientos)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            FechaSalida = fechaSalida;
            AsientosDisponibles = asientos;
        }

        public bool ReservarAsientos(int cantidad)
        {
            if (cantidad <= AsientosDisponibles && cantidad > 0)
            {
                AsientosDisponibles -= cantidad;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Origen} a {Destino} | Salida: {FechaSalida:dd/MM/yyyy} | Asientos: {AsientosDisponibles}";
        }
    }
}
