//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_cita
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int doctorId { get; set; }
        public int pacienteId { get; set; }
        public int tipoCita { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string duracion { get; set; }
    
        public virtual tb_doctor tb_doctor { get; set; }
        public virtual tb_paciente tb_paciente { get; set; }
        public virtual tb_tipo_cita tb_tipo_cita { get; set; }
    }
}
