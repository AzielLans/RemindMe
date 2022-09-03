using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remindme.Models
{
    public class Note
    {
        public string Filename { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
}
