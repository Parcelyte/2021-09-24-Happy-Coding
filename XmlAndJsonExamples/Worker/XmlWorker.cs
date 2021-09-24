using System;
using System.IO;
using System.Xml.Serialization;
using XmlAndJsonExamples.Helpers;
using Consts = XmlAndJsonExamples.Helpers.ConstantCollection;

namespace XmlAndJsonExamples.Worker
{
    /// <summary>
    /// Regelt das Schreiben und Lesen von Xml Dokumenten.
    /// </summary>
    public class XmlWorker
    {
        #region Public Methods

        /// <summary>
        /// Erstellt eine Zeichenkette im XML Format.
        /// </summary>
        /// <param name="obj">Das Objekt.</param>
        /// <returns>Eine Zeichenkette im XML Format.</returns>
        public static string CreateXmlStringFromObject(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
            xmlNS.Add("", "");

            using StringWriter strWr = new StringWriter();
            xmlSerializer.Serialize(strWr, obj, xmlNS);

            string xmlStr = strWr.ToString();

            return xmlStr;
        }

        /// <summary>
        /// Erstellt ein Objekt aus dem Inhalt eines XML Dokuments.
        /// </summary>
        /// <typeparam name="T">Der Typ.</typeparam>
        /// <param name="path">Der vollständige Pfad.</param>
        /// <returns>Das Objekt, welches aus der XML Datei erstellt wurde.</returns>
        public static T CreateObjectFromXmlFile<T>(string path) where T : class
        {
            T obj = null;

            try
            {
                XmlSerializer xmlSr = new XmlSerializer(typeof(T));

                using StreamReader sRdr = new StreamReader(path);

                obj = (T)xmlSr.Deserialize(sRdr);
            }
            catch(Exception ex)
            {
                Print.Error(ex);
            }

            return obj;
        }

        /// <summary>
        /// Erstellt ein XML Dokument aus einem Objekt.
        /// </summary>
        /// <typeparam name="T">Der Typ.</typeparam>
        /// <param name="obj">Das Objekt.</param>
        /// <param name="path">Der vollständige Pfad.</param>
        public static void CreateXmlFileFromObject<T>(T obj, string path)
        {
            try
            {
                XmlSerializer xmlSr = new XmlSerializer(obj.GetType());

                XmlSerializerNamespaces xmlNS = new XmlSerializerNamespaces();
                xmlNS.Add("", "");

                using StreamWriter sWr = new StreamWriter(path);
                xmlSr.Serialize(sWr, obj, xmlNS);

                Print.NewLine("\n" + $"XML-Datei erfolgreich erstellt. Pfad: [{path}]" + "\n", Consts.HighlightColor);
            }
            catch(Exception ex)
            {
                Print.Error(ex);
            }
        }

        #endregion Public Methods
    }
}
