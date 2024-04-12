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
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Krankenhausinformationssystem\n");
                Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
                Console.WriteLine("[1] Patienten Menü");
                Console.WriteLine("[2] Behandlungs Menü");
                Console.Write("\nBitte wählen Sie eine Option: ");

                option = Console.ReadLine();

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
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                        Console.ReadKey();
                        break;
                }
            } while (option != "exit");
        }

        public void PatientMenu()
        {
            string option;
            do
            { 
                Console.Clear();
                Console.WriteLine("Patient Menü\n");
                Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
                Console.WriteLine("[1] Anlegen");
                Console.WriteLine("[2] Bearbeiten");
                Console.WriteLine("[3] Anzeigen");
                Console.Write("\nBitte wählen Sie eine Option: ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        PatientenAnlegen();
                        break;
                    case "2":
                        PatientenBearbeiten();
                        break;
                    case "3":
                        PatientenAnzeigen();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                        Console.ReadKey();
                        break;
                }
            } while (option != "exit");
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

        public void PatientenBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("Patient bearbeiten\n");

            Console.Write("ID des Patienten eingeben: ");
            int patientId = int.Parse(Console.ReadLine());

            var patient = dbContext.Patienten.Find(patientId);

            if (patient == null)
            {
                Console.WriteLine($"Patient mit der ID {patientId} konnte nicht gefunden werden.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Was möchten Sie ändern?\n");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Geburtsdatum");
            Console.WriteLine("[3] Geschlecht");
            Console.WriteLine("[4] Adresse");
            Console.Write("\nBitte wählen Sie eine Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Name: ");
                    patient.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Geburtsdatum: ");
                    patient.Geburtsdatum = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Geschlecht: ");
                    patient.Geschlecht = Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Adresse: ");
                    patient.Adresse = Console.ReadLine();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                    Console.ReadKey();
                    break;
            }

            dbContext.SaveChanges();

            Console.WriteLine($"\nDer Patient mit der ID {patientId} wurde erfolgreich bearbeitet.");
            Console.ReadKey();
            AppStart();
        }

        public void PatientenAnzeigen()
        {
            Console.Clear();
            Console.WriteLine("Patienten anzeigen\n");

            var patienten = dbContext.Patienten.ToList();

            foreach (var patient in patienten)
            {
                Console.WriteLine("ID: {0}", patient.Id);
                Console.WriteLine("Name: {0}", patient.Name);
                Console.WriteLine("Geburtsdatum: {0}", patient.Geburtsdatum);
                Console.WriteLine("Geschlecht: {0}", patient.Geschlecht);
                Console.WriteLine("Adresse: {0}", patient.Adresse);
                Console.WriteLine("---------------------");
            }

            Console.ReadKey();
            AppStart();
        }

        public void BehandlungsMenu()
        {
            string option;
            do
            { 
                Console.Clear();
                Console.WriteLine("Behandlungs Menü\n");
                Console.WriteLine("Eingabe: exit  ->  beendet das Programm\n");
                Console.WriteLine("[1] Anlegen");
                Console.WriteLine("[2] Bearbeiten");
                Console.WriteLine("[3] Anzeigen");
                Console.Write("\nBitte wählen Sie eine Option: ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        BehandlungAnlegen();
                        break;
                    case "2":
                        BehandlungBearbeiten();
                        break;
                    case "3":
                        BehandlungAnzeigen();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                        Console.ReadKey();
                        break;
                }
            } while (option != "exit");
        }

        public async void BehandlungAnlegen()
        {
            Console.Clear();
            Console.WriteLine("Behandlung Anlegen\n");
            Console.Write("PatientId: ");
            int patientId = int.Parse(Console.ReadLine());

            var patient = dbContext.Patienten.Find(patientId);

            if (patient == null)
            {
                Console.WriteLine($"Patient mit der ID {patientId} konnte nicht gefunden werden.");
                Console.ReadKey();
                return;
            }
            Console.Write("Diagnose: ");
            string diagnose = Console.ReadLine();
            Console.Write("Medikation: ");
            string medikation = Console.ReadLine();
            Console.Write("BehandlungsDatum: ");
            string behandlungsDatum = Console.ReadLine();
            Console.Write("Arzt: ");
            string arzt = Console.ReadLine();

            Behandlung neuerBehandlung = new Behandlung
            {
                PatientId = patientId,
                Diagnose = diagnose,
                Medikation = medikation,
                BehandlungsDatum = behandlungsDatum,
                Arzt = arzt,

            };

            dbContext.Behandlungen.Add(neuerBehandlung);
            await dbContext.SaveChangesAsync();

            Console.WriteLine($"\nDer Partient mit der ID: {patientId} wurde erfolgreich angelegt!");
            Console.ReadKey();
            AppStart();
        }

        public void BehandlungBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("Behandlung bearbeiten\n");

            Console.Write("ID der Behandlung eingeben: ");
            int behandlungId = int.Parse(Console.ReadLine());

            var behandlung = dbContext.Behandlungen.Find(behandlungId);

            if (behandlung == null)
            {
                Console.WriteLine($"Behandlung mit der ID {behandlungId} konnte nicht gefunden werden.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Was möchten Sie ändern?\n");
            Console.WriteLine("[1] PatientId");
            Console.WriteLine("[2] Diagnose");
            Console.WriteLine("[3] Medikation");
            Console.WriteLine("[4] BehandlungsDatum");
            Console.WriteLine("[5] Arzt");
            Console.Write("\nBitte wählen Sie eine Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("PatientId: ");
                    behandlung.PatientId = Convert.ToInt32(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Diagnose: ");
                    behandlung.Diagnose = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Medikation: ");
                    behandlung.Medikation = Console.ReadLine();
                    break;
                case "4":
                    Console.Write("BehandlungsDatum: ");
                    behandlung.BehandlungsDatum = Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Arzt: ");
                    behandlung.Arzt = Console.ReadLine();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut eingeben.");
                    Console.ReadKey();
                    break;
            }

            dbContext.SaveChanges();

            Console.WriteLine($"\nDie Behandlung mit der ID {behandlungId} wurde erfolgreich bearbeitet.");
            Console.ReadKey();
            AppStart();
        }

        public void BehandlungAnzeigen()
        {
            Console.Clear();
            Console.WriteLine("Behandlung anzeigen\n");

            var behandlungen = dbContext.Behandlungen.ToList();

            foreach (var behandlung in behandlungen)
            {
                Console.WriteLine($"PatientId: {behandlung.PatientId}");
                Console.WriteLine($"Diagnose: {behandlung.Diagnose}");
                Console.WriteLine($"Medikation: {behandlung.Medikation}");
                Console.WriteLine($"BehandlungsDatum: {behandlung.BehandlungsDatum}");
                Console.WriteLine($"Arzt: {behandlung.Arzt}");
                Console.WriteLine("---------------------");
            }

            Console.ReadKey();
            AppStart();
        }
    }
}
