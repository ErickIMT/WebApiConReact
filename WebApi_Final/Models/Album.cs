using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class Album
    {
        [Key]
        [Column(TypeName = "nvarchar(5)")]
        public string AlbumId { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string AlbumTit { get; set; }

        public DateTime AlbumFec { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Precio  { get; set; }
        [Column(TypeName = "nvarchar(4)")]
        public string Tipo { get; set; }
        public int stock { get; set; }

        [ForeignKey("Cantante")]
        public string CantanteId { get; set; }
        public virtual Cantante Cantante { get; set; }

        [ForeignKey("Genero")]
        public string GeneroId { get; set; }
        public virtual Genero Genero { get; set; }

        [ForeignKey("Pais")]

        public string PaisId { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
