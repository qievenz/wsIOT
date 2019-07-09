using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOT.Models
{
    public partial class Medicion
    {
        [Column("Medicion_ID")]
        public long MedicionId { get; set; }
        [Column("Dispositivo_ID")]
        public long DispositivoId { get; set; }
        [Column("Sensor_ID")]
        public long SensorId { get; set; }
        [Required]
        public string Inicio { get; set; }
        [Required]
        public string Fin { get; set; }
        public string Nombre { get; set; }
        [Column("Valor_1")]
        public double? Valor1 { get; set; }
        [Column("Valor_2")]
        public double? Valor2 { get; set; }
        [Column("Valor_3")]
        public double? Valor3 { get; set; }

        [ForeignKey("DispositivoId")]
        [InverseProperty("Medicion")]
        public virtual Dispositivo Dispositivo { get; set; }
        [ForeignKey("SensorId")]
        [InverseProperty("Medicion")]
        public virtual Sensor Sensor { get; set; }
    }
}
