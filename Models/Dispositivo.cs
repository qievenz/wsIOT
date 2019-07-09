using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOT.Models
{
    public partial class Dispositivo
    {
        public Dispositivo()
        {
            Medicion = new HashSet<Medicion>();
        }

        [Column("Dispositivo_ID")]
        public long DispositivoId { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Funcion { get; set; }
        public string Ubicacion { get; set; }
        [Column("Voltaje_min")]
        public long? VoltajeMin { get; set; }
        [Column("Voltaje_max")]
        public long? VoltajeMax { get; set; }

        [InverseProperty("Dispositivo")]
        public virtual ICollection<Medicion> Medicion { get; set; }
    }
}
