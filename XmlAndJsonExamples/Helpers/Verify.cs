using System;
using System.IO;
using System.Collections.Generic;
using Consts = XmlAndJsonExamples.Helpers.ConstantCollection;

namespace XmlAndJsonExamples.Helpers
{
    /// <summary>
    /// Klasse, welche für die Verifizierung der Nutzereingaben zuständig ist.
    /// </summary>
    public class Verify
    {
        #region Public Methods

        /// <summary>
        /// Überprüft, ob eine Integereingabe des Nutzers gültig ist durch Parsen und Validierung der Grenzwerte.
        /// </summary>
        /// <param name="input">Die Nutzereingabe.</param>
        /// <param name="min">Der gültige Mindestwert.</param>
        /// <param name="max">Der gültige Maximalwert.</param>
        /// <returns>Eine Zahl, welche die Auswahl des Nutzers widerspiegelt.</returns>
        public static int IntegerInput(string input, int min, int max)
        {
            int validInput;

            while (!Int32.TryParse(input, out validInput) || (validInput < min) || (validInput > max))
            {
                Print.ClearPreviousLines(1);

                Print.InLine($"Bitte geben Sie einen gültigen Wert ein. (Von [{min}] bis [{max}]): ", Consts.KeyColor);
                input = Console.ReadLine();
            }

            return validInput;
        }

        /// <summary>
        /// Überprüft, ob die Eingabe für die Auswahl des Objekttypen gültig ist.
        /// </summary>
        /// <param name="input">Die Nutzereingabe.</param>
        /// <returns>Eine Zeichenkette, welche den Typ eines gültigen Objekts widerspiegelt.</returns>
        public static string TypeInput(string input)
        {
            List<string> types = new List<string>
            {
                "Customer",
                "Project",
                "Trainee"
            };

            while (!types.Contains(input))
            {
                Print.ClearPreviousLines(1);

                Print.InLine($"Bitte geben Sie einen gültigen Wert ein. ({types[0]}, {types[1]} und {types[2]}): ", Consts.KeyColor);

                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// Überprüft, ob die Eingabe mit einem existierenden PFad übereinstimmt.
        /// </summary>
        /// <param name="input">Die Nutzereingabe.</param>
        /// <returns>Ein existierendes Verzeichnis.</returns>
        public static string PathInput(string input)
        {
            while (!Directory.Exists(input) || String.IsNullOrEmpty(input))
            {
                Print.ClearPreviousLines(1);

                Console.Write("Bitte geben Sie ein gültiges Verzeichnis ein: ");
                input = Console.ReadLine();
            }

            input += @"\";

            return input;
        }

        /// <summary>
        /// Überprüft, ob die Eingabe für den Dateinamen ungültige Symbole enthält.
        /// </summary>
        /// <param name="choiceFormat">Die Nutzerauswahl des Dateiformats.</param>
        /// <returns>Den gültigen, gewählten Dateinamen mit ausgewählter Dateiendung.</returns>
        public static string FileName(int choiceFormat)
        {
            string fileName;

            do
            {
                Print.ClearPreviousLines(1);

                Console.Write("Bitte geben Sie einen gültigen Dateinamen ohne Dateiendung ein: ");
                fileName = Console.ReadLine();
            } while ((fileName.IndexOfAny(Path.GetInvalidPathChars()) != -1) || String.IsNullOrEmpty(fileName));

            fileName += choiceFormat == 1 ? ".json" : ".xml";

            return fileName;
        }

        #endregion Public Methods
    }
}
