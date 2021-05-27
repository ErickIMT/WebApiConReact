using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class Genero
    {
        [Key]
        [Column(TypeName = "nvarchar(4)")]
        public string GeneroId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string GeneroName { get; set; }
    }
}
