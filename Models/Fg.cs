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
    
    public partial class Fg
    {
        public int fg_Id { get; set; }
        public Nullable<decimal> made { get; set; }
        public Nullable<decimal> att { get; set; }
        public Nullable<decimal> @long { get; set; }
        public Nullable<decimal> blkd { get; set; }
        public string playerGame_Id { get; set; }
    
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
