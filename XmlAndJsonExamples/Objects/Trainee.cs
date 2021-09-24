using System;
using System.Collections.Generic;
using XmlAndJsonExamples.Helpers;

namespace XmlAndJsonExamples.Objects
{
    /// <summary>
    /// Klasse, welche für die Xml und Json Beispiele verwendet wird und einen Auszubildenden repräsentiert.
    /// </summary>
    public class Trainee
    {
        #region Private Fields

        /// <summary>
        /// Das Ausbildungsjahr, in welchem sich der Auszubildende befindet.
        /// </summary>
        private int _traineeYear;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Der vollständige Name des Auszubildenden.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Das Alter des Auszubildenden.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Das Ausbildungsjahr, in welchem sich der Auszubildende befindet.
        /// <br></br>
        /// Kann nur einen Wert zwischen 1 und 3 annehmen.
        /// </summary>
        public int Year
        {
            get => _traineeYear;
            set => _traineeYear = value >= 1 && value <= 3
                ? value
                : throw new ArgumentOutOfRangeException(nameof(_traineeYear), "Das Ausbildungsjahr kann nur die Werte 1, 2 oder 3 annehmen.");
        }

        /// <summary>
        /// Der Wohnort des Auszubildenden.
        /// </summary>
        public string Residence { get; set; }

        /// <summary>
        /// Die Liste vorheriger und aktueller Projekte des Auszubildenden.
        /// </summary>
        public List<Project> Projects { get; set; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Trainee"/> Klasse.
        /// </summary>
        public Trainee() { }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Trainee"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Auszubildenden.</param>
        /// <param name="age">Das Alter des Auszubildenden.</param>
        /// <param name="year">Das Ausbildungsjahr des Auszubildenden.</param>
        /// <param name="residence">Der Wohnort des Auszubildenden.</param>
        public Trainee(string name, int age, int year, string residence)
        {
            Name = name;
            Age = age;
            Year = year;
            Residence = residence;
            Projects = new List<Project>();
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Trainee"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Auszubildenden.</param>
        /// <param name="age">Das Alter des Auszubildenden.</param>
        /// <param name="year">Das Ausbildungsjahr des Auszubildenden.</param>
        /// <param name="residence">Der Wohnort des Auszubildenden.</param>
        /// <param name="projects">Die Liste vorheriger und aktueller Projekte des Auszubildenden.</param>
        public Trainee(string name, int age, int year, string residence, List<Project> projects)
        {
            Name = name;
            Age = age;
            Year = year;
            Residence = residence;
            Projects = projects;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gibt eine Zeichenkette mit Informationen über die Eigenschaften des <see cref="Trainee"/> Objekts zurück.
        /// </summary>
        /// <returns>Eine Zeichenkette mit Informationen über das <see cref="Trainee"/> Objekt.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Alter: {Age}, Ausbildungsjahr: {Year}, Wohnort: {Residence}, Anzahl Projekte: {Projects.Count}";
        }     

        /// <summary>
        /// Erstellt ein <see cref="Trainee"/> Einzelobjekt, gefüllt mit Dummy Daten.
        /// </summary>
        /// <returns>Ein <see cref="Trainee"/> Objekt.</returns>
        public static Trainee CreateTestData()
        {
            return new Trainee(
                "Traineename",
                Helper.GetRandomInteger(18, 50),
                Helper.GetRandomInteger(1, 3),
                "Traineewohnort",
                Project.CreateTestDataList(
                    Helper.GetRandomInteger(1, 5)
                    )
                );
        }

        /// <summary>
        /// Erstellt eine <see cref="Trainee"/> Liste, gefüllt mit Dummy Daten.
        /// </summary>
        /// <param name="count">Die Anzahl der Trainees, welche erstellt werden sollen.</param>
        /// <returns>Eine <see cref="Trainee"/> Liste, gefüllt mit Dummy Daten.</returns>
        public static List<Trainee> CreateTestDataList(int count)
        {
            List<Trainee> trainees = new List<Trainee>();

            for (int i = 1; i <= count; i++)
            {
                trainees.Add(
                    new Trainee(
                        $"Traineename {i}",
                        Helper.GetRandomInteger(18, 50),
                        Helper.GetRandomInteger(1, 3),
                        $"Traineewohnort {i}",
                        Project.CreateTestDataList(
                            Helper.GetRandomInteger(1, 5)
                            )
                        )
                    );
            }

            return trainees;
        }

        /// <summary>
        /// Gibt die Eigenschaften eines jeden <see cref="Project"/> in der <see cref="Project"/> Liste des <see cref="Trainee"/> aus.
        /// </summary>
        public void PrintProjects()
        {
            Console.WriteLine("Der Trainee ist/war in folgenden Projekten:");

            foreach (Project project in Projects)
            {
                Console.WriteLine("\n" + $"Name: {project.Name}");
                Console.WriteLine($"Rolle: {project.Role}");
                Console.WriteLine($"Name Kunde: {project.Customer.Name}");
                Console.WriteLine($"Standort Kunde: {project.Customer.Location}");
                Console.WriteLine(!project.IsFinished ? "Stand: In Bearbeitung" : "Stand: Abgeschlossen" + "\n");
            }

            Console.WriteLine($"Die Liste enthält {Projects.Count} Projekte.");
        }

        #endregion Public Methods
    }
}
