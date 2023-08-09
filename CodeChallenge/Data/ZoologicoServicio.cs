using CodeChallenge.Data.Model;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        public enum TipoAnimal
        {
            Carnivoro,
            Herbivoro,
            Reptil
        }

        public class ConsumoMes
        {
            public ConsumoMes()
            {
                Carne = 0;
                Hierbas = 0;
                ConsumoTotal = 0;
            }
            public double Carne { get; set; }
            public double Hierbas { get; set; }
            public double ConsumoTotal { get; set; }
        }

        public List<Animal> _animales;
        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }
        public List<string> TiposAnimales => new List<string>() { "Carnívoro", "Hervíboro", "Reptil" };

        public void AgregarAnimal(Animal animal)
        {
            _animales.Add(animal);
        }
        public ConsumoMes CalcularConsumoMensual()
        {
            double consumoTotalCarne = 0.0;
            double consumoTotalHierbas = 0.0;

            foreach (var animal in _animales)
            {
                double consumoDiario = animal.CalcularConsumoDiario();

                switch (animal.Tipo)
                {
                    case "Carnívoro":
                        consumoTotalCarne += consumoDiario * 30;
                        break;
                    case "Hervíboro":
                        consumoTotalHierbas += consumoDiario * 30;
                        break;
                    case "Reptil":
                        consumoTotalCarne += (consumoDiario * 30) * (animal.PorcentajeAlimento / 100);
                        consumoTotalHierbas += (consumoDiario * 30) * (animal.PorcentajeAlimentoHierbas / 100);
                        break;
                }
            }

            return new ConsumoMes
            {
                Carne = consumoTotalCarne,
                Hierbas = consumoTotalHierbas,
                ConsumoTotal = consumoTotalCarne + consumoTotalHierbas
            };
        }
        public string AdvertirExcesoConsumo()
        {
            double consumoMensual = CalcularConsumoMensual().ConsumoTotal;
            if (consumoMensual > 1500)
            {
                return "Advertencia: El consumo de comida supera los 1500 kg en el mes.";
            }

            return "";
        }
    }
}
