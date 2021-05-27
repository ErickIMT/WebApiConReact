using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class Pais

    {
        [Key]
        [Column(TypeName = "nvarchar(2)")]
        public string PaisId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Pais_Nom { get; set; }
    }
}
