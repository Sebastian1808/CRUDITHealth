//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDITHealth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class paciente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Nullable<int> documento { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public Nullable<int> telefono { get; set; }
        public string contactoEmergencia { get; set; }
        public Nullable<int> telefonoContactoE { get; set; }
    }
}