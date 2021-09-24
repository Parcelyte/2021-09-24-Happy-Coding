using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using CreateDynamicJsonOnRuntime.Helpers;
using XmlAndJsonExamples.Worker;

namespace CreateDynamicJsonOnRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            object objValue = new object();
            int propAmount = 0;

            propAmount = Helper.VerifyPropertyAmountInput();                  

            for (int i = 0; i < propAmount; i++)
            {

                string propType = Helper.VerifyPropertyTypeInput();

                Console.Write($"Geben Sie den Namen für das {i + 1}. Property ein: ");
                string propName = Console.ReadLine();

                switch (propType)
                {
                    case "int":
                        Console.Write($"Geben Sie nun den Wert für das {i + 1}. Property ein: ");
                        objValue = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "bool":
                        Console.Write($"Geben Sie nun den Wert für das {i + 1}. Property ein: ");
                        objValue = Convert.ToBoolean(Console.ReadLine());
                        break;
                    case "string":
                        Console.Write($"Geben Sie nun den Wert für das {i + 1}. Property ein: ");
                        objValue = Console.ReadLine();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                properties.Add(propName, objValue);
            }

            Console.Write("\n" + "Geben Sie den Pfad für das JSON-Dokument ein: ");

            string path = Console.ReadLine();

            path += path.EndsWith(".json") ? "" : ".json";

            string jsonStr = JsonWorker.CreateJsonStringFromObject(properties, true);

            Console.WriteLine("\n" + jsonStr);

            JsonWorker.WriteToFile(jsonStr, path);
        }
    }
}
