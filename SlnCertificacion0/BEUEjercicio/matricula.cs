//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUEjercicio
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class matricula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public matricula()
        {
            this.calificacions = new HashSet<calificacion>();
        }
    
        public int idmatricula { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> costo { get; set; }
        public string estado { get; set; }
        public string tipo { get; set; }
        public int idalumno { get; set; }
        public int idmateria { get; set; }
        [JsonIgnore]
        public virtual alumno alumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificacion> calificacions { get; set; }
        [JsonIgnore]
        public virtual materia materia { get; set; }
    }
}
