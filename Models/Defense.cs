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
    
    public partial class Defense
    {
        public int defense_Id { get; set; }
        public Nullable<decimal> tackUA { get; set; }
        public Nullable<decimal> tackA { get; set; }
        public Nullable<decimal> tflUA { get; set; }
        public Nullable<decimal> tflA { get; set; }
        public Nullable<decimal> sacks { get; set; }
        public Nullable<decimal> sackYds { get; set; }
        public Nullable<decimal> brup { get; set; }
        public Nullable<decimal> qbh { get; set; }
        public Nullable<decimal> ints { get; set; }
        public Nullable<decimal> intYds { get; set; }
        public Nullable<decimal> ff { get; set; }
        public Nullable<decimal> fr { get; set; }
        public string playerGame_Id { get; set; }
        public Nullable<decimal> tflYds { get; set; }
        public Nullable<decimal> blkd { get; set; }
        public Nullable<decimal> frYds { get; set; }
    
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
