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
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.LongPlays = new HashSet<LongPlay>();
            this.Officials = new HashSet<Official>();
            this.PlayerGames = new HashSet<PlayerGame>();
            this.Scores = new HashSet<Score>();
            this.TeamGames = new HashSet<TeamGame>();
        }
    
        public string game_Id { get; set; }
        public string visId { get; set; }
        public string homeId { get; set; }
        public string visName { get; set; }
        public string homeName { get; set; }
        public string date_ { get; set; }
        public string location_ { get; set; }
        public string stadium { get; set; }
        public string leagueGame { get; set; }
        public string niteGame { get; set; }
        public string postseasonGame { get; set; }
        public string neutralGame { get; set; }
        public string duration { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string attendance { get; set; }
        public string temp { get; set; }
        public string wind { get; set; }
        public string weather { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LongPlay> LongPlays { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Official> Officials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerGame> PlayerGames { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Scores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGame> TeamGames { get; set; }
    }
}
