using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace LSD_20
{
    /// <summary>
    /// Функции для работы с файлами и подготовки данных к записи в файл
    /// </summary>
    static class FileService
    {
        public static void WriteTextToFile(string path, string text)
        {
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine(text);
        }

        /// <summary>
        /// Сериализация списка объектов заданного типа
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="listOfObjects">Список объектов</param>
        /// <returns>Возвращает строку сериализованных объектов в формате массива JSON ( [ { }, { } ] )</returns>
        public static string ListOfObjectsToJsonString<T>(List<T> listOfObjects) where T: class
        {
            string jsonifiedObjects = JsonConvert.SerializeObject(listOfObjects);
            return jsonifiedObjects; 
        }
    }
}
