//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rush
    {
        public int rush_Id { get; set; }
        public decimal att { get; set; }
        public decimal yds { get; set; }
        public decimal gain { get; set; }
        public decimal loss { get; set; }
        public decimal td { get; set; }
        public decimal @long { get; set; }
        public string playerGame_Id { get; set; }
    
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
