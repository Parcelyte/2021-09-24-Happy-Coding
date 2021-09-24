using System.Collections.Generic;
using XmlAndJsonExamples.Helpers;

namespace XmlAndJsonExamples.Objects
{
    /// <summary>
    /// Klasse, welche für die Xml und Json Beispiele verwendet wird und ein Projekt repräsentiert.
    /// </summary>
    public class Project
    {
        #region Public Properties

        /// <summary>
        /// Der Name/Titel des Projekts.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Die Rolle des Auszubildenden im Projekt.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Die Details des Kunden.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Ob das Projekt abgeschlossen ist oder aktuell noch läuft.
        /// </summary>
        public bool IsFinished { get; set; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Project"/> Klasse.
        /// </summary>
        public Project()
        {
            Name = "Unbekannt";
            Role = "Unbekannt";
            Customer = new Customer();
            IsFinished = false;
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Project"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Projekts.</param>
        public Project(string name)
        {
            Name = name;
            Role = "Unbekannt";
            Customer = new Customer();
            IsFinished = false;
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Project"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Projekts.</param>
        /// <param name="role">Die Rolle des Auszubildenden im Projekt.</param>
        public Project(string name, string role)
        {
            Name = name;
            Role = role;
            Customer = new Customer();
            IsFinished = false;
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Project"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Projekts.</param>
        /// <param name="role">Die Rolle des Auszubildenden im Projekt.</param>
        /// <param name="customer">Der Kunde des Projekts.</param>
        public Project(string name, string role, Customer customer)
        {
            Name = name;
            Role = role;
            Customer = customer;
            IsFinished = false;
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Project"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Projekts.</param>
        /// <param name="role">Die Rolle des Auszubildenden im Projekt.</param>
        /// <param name="customer">Der Kunde des Projekts.</param>
        /// <param name="isFinished">Ist das Projekt abgeschlossen?</param>
        public Project(string name, string role, Customer customer, bool isFinished)
        {
            Name = name;
            Role = role;
            Customer = customer;
            IsFinished = isFinished;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gibt eine Zeichenkette mit Informationen über die Eigenschaften des <see cref="Project"/> Objekts zurück.
        /// </summary>
        /// <returns>Eine Zeichenkette mit Informationen über das <see cref="Project"/> Objekt.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Role: {Role}, Name Kunde: {Customer.Name}, Standort Kunde: {Customer.Location}, Stand: {(!IsFinished ? "In Bearbeitung" : "Abgeschlossen")}.";
        }

        /// <summary>
        /// Erstellt ein <see cref="Project"/> Einzelobjekt, gefüllt mit Dummy Daten.
        /// </summary>
        /// <returns>Ein <see cref="Project"/> Objekt.</returns>
        public static Project CreateTestData()
        {
            return new Project(
                "Projektname",
                "Rolle des Trainee",
                new Customer
                {
                    Name = $"Kundenname",
                    Location = "Kundenstandort"
                },
                Helper.GetRandomBool()
                );
        }

        /// <summary>
        /// Erstellt eine <see cref="Project"/> Liste, gefüllt mit Dummy Daten.
        /// </summary>
        /// <param name="count">Die Anzahl der Projekte, welche erstellt werden sollen.</param>
        /// <returns>Eine <see cref="Project"/> Liste, gefüllt mit Dummy Daten.</returns>
        public static List<Project> CreateTestDataList(int count)
        {
            List<Project> projects = new List<Project>();

            for (int i = 1; i <= count; i++)
            {
                projects.Add(
                    new Project(
                        $"Projektname {i}",
                        $"Rolle des Trainee {i}",
                        new Customer
                        {
                            Name = $"Kundenname {i}",
                            Location = $"Kundenstandort {i}"
                        },
                        Helper.GetRandomBool())
                    );
            }

            return projects;
        }

        #endregion Public Methods
    }
}
