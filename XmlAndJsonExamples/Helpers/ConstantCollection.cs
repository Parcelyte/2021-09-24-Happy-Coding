using System;

namespace XmlAndJsonExamples.Helpers
{
    /// <summary>
    /// Enhält eine Ansammlung an Konstanten für diverse Hilfsmethoden.
    /// </summary>
    public class ConstantCollection
    {
        #region Constants

        /// <summary>
        /// Der Titel der Konsolenapplikation.
        /// </summary>
        public const string Title = "2021-09-24 Happy Coding (Xml & Json)";

        /// <summary>
        /// Die Farbe des Textes in der Konsole.
        /// </summary>
        public const ConsoleColor ForegroundColor = ConsoleColor.White;

        /// <summary>
        /// Die Farbe des Hintergrunds in der Konsole.
        /// </summary>
        public const ConsoleColor BackgroundColor = ConsoleColor.Black;

        /// <summary>
        /// Die Farbe des Textes wenn eine Taste erwähnt wird.
        /// </summary>
        public const ConsoleColor KeyColor = ConsoleColor.Magenta;

        /// <summary>
        /// Die Farbe des Textes wenn ein Fehler in der Konsole ausgegeben wird.
        /// </summary>
        public const ConsoleColor ErrorColor = ConsoleColor.Red;

        /// <summary>
        /// Die Farbe des Textes, wenn etwas hervorgehoben werden soll.
        /// </summary>
        public const ConsoleColor HighlightColor = ConsoleColor.Cyan;

        /// <summary>
        /// Die Taste, welche zum Beenden des Programms gedrückt werden soll.
        /// </summary>
        public const ConsoleKey ExitKey = ConsoleKey.Enter;

        #endregion Constants
    }
}
