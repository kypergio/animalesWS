using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AnimalesWS.Models
{
    public class Animal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        [JsonIgnore]
        public double pesoValor { get; set; }
        public string peso { get { return pesoValor.ToString() + " kg"; } }
        [JsonIgnore]
        public double alturaValor { get; set; }
        public string altura { get { return alturaValor.ToString() + " m"; } }
        public string habitat { get; set; }
        public string nombreCientifico { get; set; }
        [JsonIgnore]
        public bool vertebradoValor { get; set; }
        public string vertebrado { get { return vertebradoValor ? "Si" : "No"; } }
        [JsonIgnore]
        public bool oviparoValor { get; set; }
        public string oviparo { get { return oviparoValor ? "Si" : "No"; } }
        [JsonIgnore]
        public TipoAlimentacion tipoAlimentacionValor { get; set; }
        public string tipoAlimentacion
        {
            get
            {
                switch (tipoAlimentacionValor)
                {
                    case TipoAlimentacion.carnivoro:
                        return "Carnívoro";
                    case TipoAlimentacion.herbivoro:
                        return "Herbívoro";
                    case TipoAlimentacion.omnivoro:
                        return "Omnívoro";
                    default:
                        return "";
                }
            }
        }
    }
    public class AnimalRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double peso { get; set; }
        public double altura { get; set; }
        public string habitat { get; set; }
        public string nombreCientifico { get; set; }
        public bool vertebrado { get; set; }
        public bool oviparo { get; set; }
        public TipoAlimentacion tipoAlimentacionValor { get; set; }
    }

    public enum TipoAlimentacion
    {
        carnivoro,
        herbivoro,
        omnivoro
    }
}