//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud_Operation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOutPatient
    {
        public int OutPatientId { get; set; }
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> Age { get; set; }
        public string Disease { get; set; }
    }
}