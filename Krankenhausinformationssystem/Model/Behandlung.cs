using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhausinformationssystem.Model
{
    internal class Behandlung
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Diagnose { get; set; } = null!;
        public string Medikation { get; set; } = null!;
        public string BehandlungsDatum { get; set; } = null!;
        public string Arzt { get; set; } = null!;
    }
}
