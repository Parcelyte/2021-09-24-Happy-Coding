using System;
using System.Text.RegularExpressions;
using Consts = XmlAndJsonExamples.Helpers.ConstantCollection;

namespace XmlAndJsonExamples.Helpers
{
    /// <summary>
    /// Helferklasse, welche für die Schreibarbeit in der Konsole zuständig ist.
    /// </summary>
    public class Print
    {
        #region Public Methods

        /// <summary>
        /// Schreibt den Header/die Begrüßungsnachricht in die Konsole.
        /// </summary>
        public static void Start()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            NewLine("------ [Happy Coding am 24.09.2021] ------", Consts.HighlightColor);
            Console.WriteLine("----------------------------------------" + "\n");
        }

        /// <summary>
        /// Schreibt eine Abschiedsnachricht in die Konsole und fordert den Nutzer zu einer Eingabe auf.
        /// </summary>
        public static void Exit()
        {
            NewLine($"Drücken Sie [{Consts.ExitKey}], um das Programm zu beenden...", Consts.KeyColor);

            Helper.WaitForKey(Consts.ExitKey);
        }

        /// <summary>
        /// Schreibt das Formatmenü in die Konsole.
        /// </summary>
        public static void MenuFormat()
        {
            Console.WriteLine("Welches der folgenden Formate möchten Sie benutzen?\n");

            NewLine("[1] : JSON", Consts.KeyColor);
            NewLine("[2] : XML", Consts.KeyColor);

            Console.Write("\n" + "Bitte wählen Sie einen der Menüpunkte aus: ");
        }

        /// <summary>
        /// Schreibt das Menü für die Einlesen/Auslesen Auswahl.
        /// </summary>
        /// <param name="choice">Die Auswahl des Nutzers.</param>
        public static void MenuIO(int choice)
        {
            switch (choice)
            {
                case 1:
                case 2:
                    ClearPreviousLines(6);

                    Console.WriteLine("Welches der folgenden Optionen möchten Sie benutzen?" + "\n");

                    NewLine($"[1] : Lesen aus {(choice == 1 ? "JSON" : "XML")} Dokument", Consts.KeyColor);
                    NewLine($"[2] : Schreiben in {(choice == 1 ? "JSON" : "XML")} Dokument", Consts.KeyColor);

                    Console.Write("\n" + "Bitte wählen Sie einen der Menüpunkte aus: ");
                    break;
                default:
                    Console.WriteLine("Dieser Fall sollte nicht eintreten, da Eingabe validiert wurde.");
                    break;
            }
        }

        /// <summary>
        /// Schreibt das Menü für die Auswahl des Objekttyps.
        /// </summary>
        public static void MenuType()
        {
            ClearPreviousLines(6);

            Console.WriteLine("Welches der folgenden Objekttypen möchten Sie benutzen?" + "\n");

            NewLine("[Customer] : Customer", Consts.KeyColor);
            NewLine("[Project] : Project", Consts.KeyColor);
            NewLine("[Trainee] : Trainee", Consts.KeyColor);

            Console.Write("\n" + "Bitte wählen Sie einen der folgenden Menüpunkte aus: ");
        }

        /// <summary>
        /// Schreibt das Menü für die Auswahl Einzelobjekt/Liste.
        /// </summary>
        public static void MenuSingleOrMulti()
        {
            ClearPreviousLines(7);

            Console.WriteLine("Welche der folgenden Optionen möchten Sie benutzen?" + "\n");

            NewLine("[1] : Einzelobjekt", Consts.KeyColor);
            NewLine("[2] : Liste von Objekten", Consts.KeyColor);

            Console.Write("\n" + "Bitte wählen Sie einen der folgenden Menüpunkte aus: ");
        }

        /// <summary>
        /// Schreibt die Nachricht des <see cref="Exception"/> Objekts in die Konsole.
        /// </summary>
        /// <param name="ex">Das <see cref="Exception"/> Objekt.</param>
        public static void Error(Exception ex)
        {
            NewLine($"\nEs ist ein Fehler aufgetreten. Details: [{ex.Message}]", Consts.ErrorColor);
        }

        /// <summary>
        /// "Löscht" eine gewisse Anzahl an Zeilen, welche bereits in der Konsole ausgegeben wurden.
        /// </summary>
        /// <param name="count">Die Anzahl der Zeilen, welche gelöscht werden sollen.</param>
        public static void ClearPreviousLines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        /// <summary>
        /// Ermöglicht Inline-Farbveränderungen für Substrings, welche in der Konsole ausgegeben werden.
        /// <br></br>
        /// Um Substrings zu färben werden diese in [] Klammern gesetzt.
        /// </summary>
        /// <param name="message">Der vollständige String.</param>
        /// <param name="color">Die Farbe für den/die Substring/s.</param>
        public static void InLine(string message, ConsoleColor color)
        {
            string[] pieces = Regex.Split(message, @"(\[[^\]]*\])");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);

                Console.ForegroundColor = Consts.ForegroundColor;
            }
        }

        /// <summary>
        /// Ermöglicht Inline-Farbveränderungen für Substrings, welche in der Konsole ausgegeben werden.
        /// <br></br>
        /// Um Substrings zu färben werden diese in [] Klammern gesetzt.
        /// </summary>
        /// <param name="message">Der vollständige String.</param>
        /// <param name="color">Die Farbe für den/die Substring/s.</param>
        public static void NewLine(string message, ConsoleColor color)
        {
            string[] pieces = Regex.Split(message, @"(\[[^\]]*\])");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);

                Console.ForegroundColor = Consts.ForegroundColor;
            }

            Console.WriteLine();
        }

        #endregion Public Methods
    }
}
