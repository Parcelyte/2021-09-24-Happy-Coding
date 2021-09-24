using System;
using System.Collections.Generic;
using System.IO;
using XmlAndJsonExamples.Helpers;

namespace CreateDynamicJsonOnRuntime.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Erstellt oder überschreibt ein (bereits existierendes) Json Dokument im angegebenen Pfad.
        /// </summary>
        /// <param name="jsonStr">Die Zeichenkette, welche das/die Json Objekt/e enthält.</param>
        /// <param name="path">Der Ausgabepfad.</param>
        public static void WriteToTextFile(string jsonStr, string path)
        {
            try
            {
                File.WriteAllText(path, jsonStr);
                Console.WriteLine("\n" + $"JSON-Datei erfolgreich erstellt/überschrieben im Pfad [{path}]" + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es ist ein Fehler aufgetreten. Details: {ex.Message}");
            }
        }

        /// <summary>
        /// Überprüft die Eingabe, welche die Anzahl der Eigenschaften bestimmt.
        /// </summary>
        /// <returns>Die Anzahl der Eigenschaften.</returns>
        public static int VerifyPropertyAmountInput()
        {
            int propAmount;
            string input;

            Console.WriteLine("Wie viele Eigenschaften soll ihr Objekt besitzen?");

            do
            {
                Console.Write("Geben Sie die Anzahl der Eigenschaften ein: ");
                input = Console.ReadLine();
                Print.ClearPreviousLines(1);
            } while (!Int32.TryParse(input, out propAmount));

            return propAmount;
        }

        /// <summary>
        /// Überprüft die Eingabe, welche den Datentyp der aktuellen Eigenschaft besitzt.
        /// </summary>
        /// <returns></returns>
        public static string VerifyPropertyTypeInput()
        {
            string propType;

            List<string> validTypes = new List<string>
            {
                "bool",
                "int",
                "string"
            };

            do
            {
                Console.WriteLine("\n" + "Unterstützte Datentypen: 'string', 'int', 'bool'");
                Console.Write($"Geben Sie den Datentyp für die Eigenschaft ein: ");
                propType = Console.ReadLine();
                Print.ClearPreviousLines(1);
            } while (!validTypes.Contains(propType));

            return propType;
        }
    }
}
