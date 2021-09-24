using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XmlAndJsonExamples.Helpers;

namespace XmlAndJsonExamples.Objects
{
    /// <summary>
    /// Klasse, welche für das XmlAttribut Beispiel verwendet wird und einen Praktikanten repräsentiert.
    /// </summary>
    //[XmlRoot("Intern")] // [Serializable]
    public class Intern
    {
        #region Private Fields

        /// <summary>
        /// Das Geschlecht des Praktikanten.
        /// </summary>
        private string _gender;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Der Name des Praktikanten.
        /// </summary>
        public string Name { get; set; }

        //[XmlAttribute("Age")]
        /// <summary>
        /// Das Alter des Praktikanten.
        /// </summary>
        public int Age { get; set; }

        //[XmlAttribute("Gender")]
        /// <summary>
        /// Das Geschlecht des Praktikanten. Kann die Werte "männlich" oder "weiblich" annehmen.
        /// </summary>
        public string Gender
        {
            get => _gender;
            set => _gender = value == "männlich" || value == "weiblich"
                ? value
                : throw new ArgumentOutOfRangeException(nameof(_gender), "Das Geschlecht muss entweder 'männlich' oder 'weiblich' sein.");
        }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Intern"/> Klasse.
        /// </summary>
        public Intern() { }

        /// <summary>
        /// Erstellt eine neue Instanz der <see cref="Intern"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Praktikanten.</param>
        /// <param name="age">Das Alter des Praktikanten.</param>
        /// <param name="gender">Das Geschlecht des Praktikanten.</param>
        public Intern(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Erstellt ein <see cref="Intern"/> Objekt, gefüllt mit Dummy Daten.
        /// </summary>
        /// <returns>Ein <see cref="Intern"/> Objekt.</returns>
        public static Intern CreateTestData()
        {
            return new Intern(
                "Intern",
                20,
                "männlich"
                );
        }

        /// <summary>
        /// Erstellt eine <see cref="Intern"/> Liste, gefüllt mit Dummy Daten.
        /// </summary>
        /// <param name="count">Die Anzahl der Praktikanten, welche erstellt werden sollen.</param>
        /// <returns>Eine <see cref="Intern"/> Liste, gefüllt mit Dummy Daten.</returns>
        public static List<Intern> CreateTestDataList(int count)
        {
            List<Intern> interns = new List<Intern>();

            for (int i = 1; i <= count; i++)
            {
                interns.Add(
                    new Intern(
                        $"Name {i}",
                        Helper.GetRandomInteger(18, 30),
                        Helper.GetRandomGender()
                        )
                    );
            }

            return interns;
        }

        #endregion Public Methods
    }
}
