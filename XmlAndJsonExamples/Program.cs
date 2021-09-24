using System;
using XmlAndJsonExamples.Helpers;

namespace XmlAndJsonExamples
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Helper.SetConsoleAttributes();
            
            bool isContinue;

            do
            {
                Print.Start();

                Print.MenuFormat();
                int choiceFormat = Verify.IntegerInput(Console.ReadLine(), 1, 2);

                Print.MenuIO(choiceFormat);
                int choiceIO = Verify.IntegerInput(Console.ReadLine(), 1, 2);

                Print.MenuType();
                string choiceType = Verify.TypeInput(Console.ReadLine());

                Print.MenuSingleOrMulti();
                int choiceSoM = Verify.IntegerInput(Console.ReadLine(), 1, 2);

                string path = Helper.SelectPath(choiceFormat);

                Helper.ChoiceHandler(choiceFormat, choiceIO, choiceType, choiceSoM, path);

                isContinue = Helper.ContinueHandler();
            } while (isContinue);
        }
    }
}
