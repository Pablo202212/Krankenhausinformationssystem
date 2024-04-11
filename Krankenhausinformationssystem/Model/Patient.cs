using System;

namespace Krankenhausinformationssystem
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string Geschlecht { get; set; }
        public string Adresse { get; set; }
        public string GetPatientenInfo()
        {
            return $"Patient ID: {PatientId}, Name: {Name}, Geburtsdatum: {Geburtsdatum}, Geschlecht: {Geschlecht}, Adresse: {Adresse}";
        }
    }
}
