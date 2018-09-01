using System.ComponentModel.DataAnnotations;
using CapacitacionMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace CapacitacionMVC.Web.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Fecha")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [DisplayName("Trama")]
        public string Plot { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Link del Poster")]
        public string CoverLink { get; set; }

        [Required]
        [Range(30, 300)]
        [DisplayName("Duración")]
        public int? Runtime { get; set; }

        [DisplayName("Generos")]
        public virtual ICollection<string> Genres { get; set; }
    }
}