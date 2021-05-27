using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class Cantante
    {
        [Key]
        [Column(TypeName = "nvarchar(6)")]
        public string CantanteId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string CantanteName { get; set; }

        [ForeignKey("Pais")]
        public string PaisId { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
