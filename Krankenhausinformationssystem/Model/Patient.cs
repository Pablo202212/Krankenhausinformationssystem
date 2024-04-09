using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhausinformationssystem.Model
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public string Geburtsdatum { get; set; } = null!;
        public string Geschlecht { get; set; } = null!;
        public string Adresse { get; set; } = null!;
    }
}
