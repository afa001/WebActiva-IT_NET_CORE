using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; } //id album
        public string title { get; set; }
    }
}
