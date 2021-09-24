using System;
using System.IO;
using Newtonsoft.Json;
using XmlAndJsonExamples.Helpers;
using Consts = XmlAndJsonExamples.Helpers.ConstantCollection;

namespace XmlAndJsonExamples.Worker
{
    /// <summary>
    /// Regelt das Schreiben und Lesen von Json Objekten und Dokumenten.
    /// </summary>
    public class JsonWorker
    {
        #region Public Methods

        /// <summary>
        /// Erstellt aus jedem beliebigen Objekt eine Json Zeichenkette.
        /// </summary>
        /// <param name="obj">Das Objekt</param>
        /// <param name="prettyPrint">Soll PrettyPrint aktiviert sein?</param>
        /// <returns>Eine Json Zeichenkette ggf. mit PrettyPrint-Formatierung.</returns>
        public static string CreateJsonStringFromObject(object obj, bool prettyPrint)
        {
            return prettyPrint ? JsonConvert.SerializeObject(obj, Formatting.Indented) : JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Nimmt eine Json Zeichenkette und konvertiert diese in ein Objekt.
        /// </summary>
        /// <typeparam name="T">Der Typ des Objekts.</typeparam>
        /// <param name="jsonStr">Die Json Zeichenkette, welche deserialisiert werden soll.</param>
        /// <returns>Das Objekt mit dem übergebenen Typ.</returns>
        public static T ConvertJsonStringToObject<T>(string jsonStr) where T : class
        {
            T obj = null;

            try
            {
                obj = JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch (Exception ex)
            {
                Print.Error(ex);
            }

            return obj;
        }

        /// <summary>
        /// Erstellt oder überschreibt ein (bereits existierendes) Json Dokument im angegebenen Pfad.
        /// </summary>
        /// <param name="jsonStr">Die Zeichenkette, welche das/die Json Objekt/e enthält.</param>
        /// <param name="path">Der Ausgabepfad.</param>
        public static void WriteToFile(string jsonStr, string path)
        {
            try
            {
                File.WriteAllText(path, jsonStr);
                Print.NewLine("\n" + $"JSON-Datei erfolgreich erstellt/überschrieben im Pfad [{path}]" + "\n", Consts.HighlightColor);
            }
            catch (Exception ex)
            {
                Print.Error(ex);
            }
        }

        /// <summary>
        /// Liest den Inhalt einer Textdatei ein.
        /// </summary>
        /// <param name="path">Der vollständige Pfad der Textdatei.</param>
        /// <returns>Eine Zeichenkette mit dem Inhalt der eingelesenen Textdatei.</returns>
        public static string ReadFromFile(string path)
        {
            string textFromFile = "";

            try
            {
                textFromFile = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Print.Error(ex);
            }

            return textFromFile;
        }

        #endregion Public Methods
    }
}
