using System;

namespace Krankenhausinformationssystem
{
    internal class Behandlung
    {
        public int BehandlungsId { get; set; }
        public int PatientId { get; set; }
        public string Diagnose { get; set; }
        public string Medikation { get; set; }
        public DateTime BehandlungsDatum { get; set; }
        public string Arzt { get; set; }
    }
}
