using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOT.Models
{
    public partial class Log
    {
        [Column("Log_ID", TypeName = "NUMERIC")]
        public string LogId { get; set; }
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Column("Valor_1")]
        public string Valor1 { get; set; }
        [Column("Valor_2")]
        public string Valor2 { get; set; }
        [Column("Valor_3")]
        public string Valor3 { get; set; }
        [Column("Valor_4")]
        public string Valor4 { get; set; }
    }
}
