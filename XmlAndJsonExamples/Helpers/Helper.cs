using System;
using System.Collections.Generic;
using XmlAndJsonExamples.Worker;
using XmlAndJsonExamples.Objects;
using Consts = XmlAndJsonExamples.Helpers.ConstantCollection;

namespace XmlAndJsonExamples.Helpers
{
    /// <summary>
    /// Helferklasse, welche für diverse Hilfsmethoden zuständig ist, für welche nicht unbedingt eine eigene Klasse erstellt werden muss.
    /// </summary>
    public class Helper
    {
        #region Public Methods

        /// <summary>
        /// Setzt diverse Konsolenattribute wie etwa Name und Farbe.
        /// </summary>
        public static void SetConsoleAttributes()
        {
            Console.Title = Consts.Title;
            Console.ForegroundColor = Consts.ForegroundColor;
            Console.BackgroundColor = Consts.BackgroundColor;
        }

        /// <summary>
        /// "Stoppt" den Programmablauf bis eine bestimmte Taste gedrückt wird.
        /// </summary>
        /// <param name="key">Die Taste, welche gedrückt werden soll.</param>
        public static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            {
                // Wartet auf einen bestimmten Input.
            }
        }

        /// <summary>
        /// Erzeugt einen zufälligen <see cref="Boolean"/>.
        /// </summary>
        /// <returns>Ein zufälliger <see cref="Boolean"/>.</returns>
        public static bool GetRandomBool()
        {
            Random random = new Random();

            return random.Next() < (Int32.MaxValue / 2);
        }

        /// <summary>
        /// Erzeugt einen zufälligen <see cref="Int32"/> zwischen den angegebenen Grenzwerten.
        /// </summary>
        /// <param name="lowerBound">Die untere Grenze der zu erzeugenden Zahl.</param>
        /// <param name="upperBound">Die obere Grenze der zu erzeugenden Zahl.</param>
        /// <returns>Ein zufälliger <see cref="Int32"/> zwischen den angegebenen Grenzwerten.</returns>
        public static int GetRandomInteger(int lowerBound, int upperBound)
        {
            Random random = new Random();

            return random.Next(lowerBound, upperBound + 1);
        }

        /// <summary>
        /// Erzeugt eine Zeichenkette, welche ein gültiges Geschlecht repräsentiert.
        /// </summary>
        /// <returns>Zeichenkette, welche ein gültiges Geschlecht repräsentiert.</returns>
        public static string GetRandomGender()
        {
            return GetRandomBool() ? "männlich" : "weiblich";
        }

        /// <summary>
        /// Fordert den Nutzer zur Eingabe eines gültigen Pfades und Dateinamens auf.
        /// </summary>
        /// <param name="choiceFormat">Das vom Nutzer gewählte Format.</param>
        /// <returns>Einen vollständigen Pfad mit Verzeichnis, Dateiname und Dateiendung.</returns>
        public static string SelectPath(int choiceFormat)
        {
            Print.ClearPreviousLines(6);

            Console.Write("Bitte geben Sie ein gültiges Verzeichnis ein: ");
            string path = Verify.PathInput(Console.ReadLine());

            switch (choiceFormat)
            {
                case 1:
                case 2:
                    path += Verify.FileName(choiceFormat);
                    break;
                default:
                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                    break;
            }

            Print.ClearPreviousLines(2);

            return path;
        }

        /// <summary>
        /// Bestimmt den Aufruf von Funktionen basierend auf den Eingaben des Benutzers.
        /// </summary>
        /// <param name="choiceFormat">Das gewählte Format. (JSON/XML)</param>
        /// <param name="choiceIO">Der gewählte Modus. (Read/Write)</param>
        /// <param name="choiceType">Der gewählte Klassentyp</param>
        /// <param name="choiceSoM">Der gewählte Modus. (Single/Multi)</param>
        /// <param name="path">Der vollständige Pfad zur Datei.</param>
        public static void ChoiceHandler(int choiceFormat, int choiceIO, string choiceType, int choiceSoM, string path)
        {
            /* Format: 1 = JSON, 2 = XML. 
               IO: 1 = Lesen, 2 = Schreiben.
               SoM: 1 = Single, 2 = Multi.
               Type: "Customer", "Project", "Trainee".
            */

            string jsonFromFile = "";
            string jsonFromObject = "";
            string xmlFromObject = "";

            if (choiceFormat == 1)
            {
                switch (choiceIO)
                {
                    case 1:
                        jsonFromFile = JsonWorker.ReadFromFile(path);

                        if (choiceSoM == 1)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    Customer customer = JsonWorker.ConvertJsonStringToObject<Customer>(jsonFromFile);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + customer.ToString() + "\n", Consts.HighlightColor);
                                    break;
                                case "Project":
                                    Project project = JsonWorker.ConvertJsonStringToObject<Project>(jsonFromFile);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + project.ToString() + "\n", Consts.HighlightColor);
                                    break;
                                case "Trainee":
                                    Trainee trainee = JsonWorker.ConvertJsonStringToObject<Trainee>(jsonFromFile);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + trainee.ToString() + "\n", Consts.HighlightColor);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }
                        }
                        else if (choiceSoM == 2)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    List<Customer> customers = JsonWorker.ConvertJsonStringToObject<List<Customer>>(jsonFromFile);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Customer customer in customers)
                                    {
                                        Console.WriteLine(customer.ToString());
                                    }
                                    break;
                                case "Project":
                                    List<Project> projects = JsonWorker.ConvertJsonStringToObject<List<Project>>(jsonFromFile);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Project project in projects)
                                    {
                                        Console.WriteLine(project.ToString());
                                    }
                                    break;
                                case "Trainee":
                                    List<Trainee> trainees = JsonWorker.ConvertJsonStringToObject<List<Trainee>>(jsonFromFile);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Trainee trainee in trainees)
                                    {
                                        Console.WriteLine(trainee.ToString());
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        }

                        Print.NewLine("[JSON:]" + "\n", Consts.HighlightColor);
                        Console.WriteLine(jsonFromFile + "\n");
                        break;
                    case 2:
                        if (choiceSoM == 1)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    Customer customer = Customer.CreateTestData();
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(customer, true);
                                    break;
                                case "Project":
                                    Project project = Project.CreateTestData();
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(project, true);
                                    break;
                                case "Trainee":
                                    Trainee trainee = Trainee.CreateTestData();
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(trainee, true);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }
                        }
                        else if (choiceSoM == 2)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    List<Customer> customers = Customer.CreateTestDataList(10);
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(customers, true);
                                    break;
                                case "Project":
                                    List<Project> projects = Project.CreateTestDataList(10);
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(projects, true);
                                    break;
                                case "Trainee":
                                    List<Trainee> trainees = Trainee.CreateTestDataList(10);
                                    jsonFromObject = JsonWorker.CreateJsonStringFromObject(trainees, true);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        }

                        JsonWorker.WriteToFile(jsonFromObject, path);
                        break;
                    default:
                        Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        break;
                }
            }
            else if (choiceFormat == 2)
            {
                switch (choiceIO)
                {
                    case 1:
                        if (choiceSoM == 1)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    Customer customer = XmlWorker.CreateObjectFromXmlFile<Customer>(path);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + customer.ToString() + "\n", Consts.HighlightColor);
                                    Print.NewLine("[XML:]" + "\n", Consts.HighlightColor);

                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(customer);
                                    break;
                                case "Project":
                                    Project project = XmlWorker.CreateObjectFromXmlFile<Project>(path);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + project.ToString() + "\n", Consts.HighlightColor);
                                    Print.NewLine("[XML:]" + "\n", Consts.HighlightColor);

                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(project);
                                    break;
                                case "Trainee":
                                    Trainee trainee = XmlWorker.CreateObjectFromXmlFile<Trainee>(path);
                                    Print.NewLine("\n" + "[Objekt:] " + "\n\n" + trainee.ToString() + "\n", Consts.HighlightColor);
                                    Print.NewLine("[XML:]" + "\n", Consts.HighlightColor);

                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(trainee);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }

                            Console.WriteLine(xmlFromObject + "\n");
                        }
                        else if (choiceSoM == 2)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    List<Customer> customers = XmlWorker.CreateObjectFromXmlFile<List<Customer>>(path);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Customer customer in customers)
                                    {
                                        Console.WriteLine(customer.ToString());
                                    }

                                    Print.NewLine("\n" + "[XML:]" + "\n", Consts.HighlightColor);
                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(customers);
                                    break;
                                case "Project":
                                    List<Project> projects = XmlWorker.CreateObjectFromXmlFile<List<Project>>(path);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Project project in projects)
                                    {
                                        Console.WriteLine(project.ToString());
                                    }

                                    Print.NewLine("\n" + "[XML:]" + "\n", Consts.HighlightColor);
                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(projects);
                                    break;
                                case "Trainee":
                                    List<Trainee> trainees = XmlWorker.CreateObjectFromXmlFile<List<Trainee>>(path);

                                    Print.NewLine("\n" + "[Objekte:] " + "\n", Consts.HighlightColor);

                                    foreach (Trainee trainee in trainees)
                                    {
                                        Console.WriteLine(trainee.ToString());
                                    }

                                    Print.NewLine("\n" + "[XML:]" + "\n", Consts.HighlightColor);
                                    xmlFromObject = XmlWorker.CreateXmlStringFromObject(trainees);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }

                            Console.WriteLine(xmlFromObject + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        }

                        break;
                    case 2:
                        if (choiceSoM == 1)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    XmlWorker.CreateXmlFileFromObject(Customer.CreateTestData(), path);
                                    break;
                                case "Project":
                                    XmlWorker.CreateXmlFileFromObject(Project.CreateTestData(), path);
                                    break;
                                case "Trainee":
                                    XmlWorker.CreateXmlFileFromObject(Trainee.CreateTestData(), path);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }
                        }
                        else if (choiceSoM == 2)
                        {
                            switch (choiceType)
                            {
                                case "Customer":
                                    XmlWorker.CreateXmlFileFromObject(Customer.CreateTestDataList(GetRandomInteger(1, 5)), path);
                                    break;
                                case "Project":
                                    XmlWorker.CreateXmlFileFromObject(Project.CreateTestDataList(GetRandomInteger(1, 5)), path);
                                    break;
                                case "Trainee":
                                    XmlWorker.CreateXmlFileFromObject(Trainee.CreateTestDataList(GetRandomInteger(1, 5)), path);
                                    break;
                                default:
                                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        }
                        break;
                    default:
                        Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
            }
        }

        /// <summary>
        /// Verarbeitet die Abfrage, ob die Programmlogik erneut ablaufen soll.
        /// </summary>
        /// <returns>Wahrheitswert der bestimmt, ob die Programmlogik erneut ablaufen soll.</returns>
        public static bool ContinueHandler()
        {
            bool isContinue = false;
            int choice;

            Console.WriteLine("\n\n\n\n" + "Möchten Sie das Programm erneut ausführen?" + "\n");

            Print.NewLine("[1] : Ja", Consts.KeyColor);
            Print.NewLine("[2] : Nein", Consts.KeyColor);

            Console.Write("\n" + "Bitte wählen Sie einen der Menüpunkte aus: ");

            choice = Verify.IntegerInput(Console.ReadLine(), 1, 2);

            switch (choice)
            {
                case 1:
                    isContinue = true;
                    break;
                case 2:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                    break;
            }

            return isContinue;
        }

        #endregion Public Methods
    }
}
