using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace LSD_20
{
    class FileService
    {
        public static void WriteTextToFile(string path, string text)
        {
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine(text);
        }

        public static string ListOfObjectsToJsonString<T>(List<T> listOfObjects) where T: class
        {
            string jsonifiedObjects = "";

            foreach (var o in listOfObjects)
            {
                jsonifiedObjects += JsonConvert.SerializeObject(o) + ",";
            }

            return $"[{jsonifiedObjects}]"; // TODO: найти способ нормальной сериализации List<object>
        }
    }
}
