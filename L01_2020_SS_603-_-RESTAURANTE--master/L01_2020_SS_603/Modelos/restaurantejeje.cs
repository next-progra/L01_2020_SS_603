
using System.ComponentModel.DataAnnotations;

namespace L01_2020_SS_603.Modelos
{
    public class restaurantejeje
    {
        [Key]
        public int Clienteid { get; set; }
        public int nombreCliente { get; set; }
        public int direccion { get; set; }

    }
}
