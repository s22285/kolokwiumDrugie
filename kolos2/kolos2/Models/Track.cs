using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        [Key]
        public int IdMusicAlbum { get; set; }

        public ICollection<MusicianTrack> MusicanTrack { get; set; }
        [ForeignKey("IdMusicAlbum")]
        public virtual Album Album { get; set; }

    }
}
