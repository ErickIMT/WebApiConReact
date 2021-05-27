using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Final.Models
{
    public class QueryAlbums
    {
        public string albumid { get; set; }
        public string albumtit { get; set; }
        public DateTime albumfech { get; set; }
        public string cantanteid { get; set; }
        public string cantantename { get; set; }
        public string paisID { get; set; }
        public string paisnom { get; set; }

        public string generoid { get; set; }
        public string generoname { get; set; }
        public decimal precio { get; set; }
        public string tipo { get; set; }
        public int stock { get; set; }
    }
}