using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOT.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            Medicion = new HashSet<Medicion>();
        }

        [Column("Sensor_ID")]
        public long SensorId { get; set; }
        [Required]
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        [Column("Voltaje_min")]
        public long? VoltajeMin { get; set; }
        [Column("Voltaje_max")]
        public long? VoltajeMax { get; set; }

        [InverseProperty("Sensor")]
        public virtual ICollection<Medicion> Medicion { get; set; }
    }
}
