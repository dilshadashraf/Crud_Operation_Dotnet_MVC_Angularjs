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
    
    public partial class tblCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ShortDesc { get; set; }
        public string Image { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
