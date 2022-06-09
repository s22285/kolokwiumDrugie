﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public class MusicLabel
    {

        [Key]
        public int IdMusicLabel { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Album> Album { get; set; }
    }
}
