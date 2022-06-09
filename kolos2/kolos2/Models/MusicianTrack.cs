using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class MusicianTrack
    {
        [Key]
        public int IdTrack { get; set; }
        [Key]
        public int IdMusician { get; set; }

        [ForeignKey("IdTrack")]
        public virtual Track Track { get; set; }
        [ForeignKey("IdMusician")]
        public virtual Musician Musician { get; set; }
    }
}
