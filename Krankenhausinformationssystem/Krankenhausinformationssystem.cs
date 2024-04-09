using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Text.Json;
using Krankenhausinformationssystem.Daten;
using Krankenhausinformationssystem.Model;

namespace Aufgabe_GSOKrankenhausinformationssystem
{
    internal class GSOKrankenhausinformationssystem_App
    {
        private KrankenhausContext dbContext = new KrankenhausContext();
        public void AppStart()
        {
            Console.Clear();
            Console.WriteLine("Krankenhausinformationssystem\n");
            Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
            Console.WriteLine("[1] Patienten Menü");
            Console.WriteLine("[2] Behandlungs Menü");
            Console.Write("\nBitte wählen Sie eine Option: ");

            string option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    PatientMenu();
                    break;
                case "2":
                    BehandlungsMenu();
                    break;
                case "exit":
                    return;
            }
        }

        public void PatientMenu()
        {
            Console.Clear();
            Console.WriteLine("Patient Menü\n");
            Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
            Console.WriteLine("[1] Patient anlegen");
            Console.WriteLine("[2] Patient bearbeiten");
            Console.WriteLine("[3] Patient anzeigen");
            Console.Write("\nBitte wählen Sie eine Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    PatientenAnlegen();
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "exit":
                    return;
            }
        }

        public async void PatientenAnlegen()
        {
            Console.Clear();
            Console.WriteLine("Patienten Anlegen\n");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Geburtsdatum: ");
            string geburtsdatum = Console.ReadLine();
            Console.Write("Geschlecht: ");
            string geschlecht = Console.ReadLine();
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();

            Patient neuerPartient = new Patient
            {
                Name = name,
                Geburtsdatum = geburtsdatum,
                Geschlecht = geschlecht,
                Adresse = adresse,
            };

            dbContext.Patienten.Add(neuerPartient);
            await dbContext.SaveChangesAsync();

            Console.WriteLine($"\nDer Partient mit dem Namen: {name} wurde erfolgreich angelegt!");
            Console.ReadKey();
            AppStart();
        }

        public void BehandlungsMenu()
        {
            Console.Clear();
            Console.WriteLine("Behandlungs Menü\n");
            Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
            Console.WriteLine("[1] Behandlung anlegen");
            Console.WriteLine("[2] Behandlung bearbeiten");
            Console.WriteLine("[3] Behandlung anzeigen");
            Console.Write("\nBitte wählen Sie eine Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "exit":
                    return;
            }
        }
    }
}
