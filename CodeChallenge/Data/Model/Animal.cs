using Microsoft.AspNetCore.Http;
using System;
using static CodeChallenge.Data.ZoologicoServicio;

namespace CodeChallenge.Data.Model
{
    public class Animal
    {
        public DateTime FechaIngreso { get; set; }
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public double PorcentajeAlimento { get; set; }
        public double ValorFijoAlimento { get; set; }
        public double PorcentajeAlimentoHierbas { get; set; } // Porcentaje de peso en hierbas
        public int CambioPielPeriodo { get; set; }

        public double CalcularConsumoDiario()
        {
            switch (Tipo)
            {
                case "Carnívoro":
                    return Peso * PorcentajeAlimento / 100;
                case "Hervíboro":
                    return (2 * Peso) + ValorFijoAlimento;
                case "Reptil":
                    int diasDesdeCambioPiel = (DateTime.Now - FechaIngreso).Days % CambioPielPeriodo;
                    if (diasDesdeCambioPiel < 3)
                    {
                        return (Peso * PorcentajeAlimento / 100) + ((2 * Peso) + ValorFijoAlimento) * 7;
                    }
                    else
                    {
                        return (Peso * PorcentajeAlimento / 100) * 4;
                    }
            }
            return 0;
        }
    }
}