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
    
    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            this.PlayerGames = new HashSet<PlayerGame>();
        }
    
        public string player_Id { get; set; }
        public string name { get; set; }
        public string highSchool { get; set; }
        public string homeTown { get; set; }
        public string height { get; set; }
        public string weight_ { get; set; }
        public Nullable<System.DateTime> firstGame { get; set; }
        public Nullable<System.DateTime> lastGame { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerGame> PlayerGames { get; set; }
    }
}