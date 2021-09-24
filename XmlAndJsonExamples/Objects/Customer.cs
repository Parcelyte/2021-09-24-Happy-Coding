using System.Collections.Generic;

namespace XmlAndJsonExamples.Objects
{
    /// <summary>
    /// Klasse, welche für die Xml und Json Beispiele verwendet wird und einen Kunden repräsentiert.
    /// </summary>
    public class Customer
    {
        #region Public Properties

        /// <summary>
        /// Der Name des Kunden.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Der Standort des Kunden.
        /// </summary>
        public string Location { get; set; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Customer"/> Klasse.
        /// </summary>
        public Customer()
        {
            Name = "Keine Angabe";
            Location = "Keine Angabe";
        }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Customer"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Kunden.</param>
        /// <param name="location">Der Standort des Kunden.</param>
        public Customer(string name, string location)
        {
            Name = name;
            Location = location;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gibt eine Zeichenkette mit Informationen über die Eigenschaften des <see cref="Customer"/> zurück.
        /// </summary>
        /// <returns>Eine Zeichenkette mit Informationen über das <see cref="Customer"/> Objekt.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Standort: {Location}.";
        }

        /// <summary>
        /// Erstellt ein <see cref="Customer"/> Objekt, gefüllt mit Dummy Daten.
        /// </summary>
        /// <returns>Ein <see cref="Customer"/> Objekt.</returns>
        public static Customer CreateTestData()
        {
            return new Customer(
                "Kundenname",
                "Kundenstandort"
                );
        }

        /// <summary>
        /// Erstellt eine <see cref="Customer"/> Liste, gefüllt mit Dummy Daten.
        /// </summary>
        /// <param name="count">Die Anzahl der Kunden, welche erstellt werden sollen.</param>
        /// <returns>Eine <see cref="Customer"/> Liste, gefüllt mit Dummy Daten.</returns>
        public static List<Customer> CreateTestDataList(int count)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 1; i <= count; i++)
            {
                customers.Add(
                    new Customer(
                        $"Kundenname {i}",
                        $"Kundenstandort {i}"
                        )
                    );
            }

            return customers;
        }

        #endregion Public Methods
    }
}
