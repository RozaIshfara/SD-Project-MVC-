//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Template.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblContact
    {
        public int contactId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}