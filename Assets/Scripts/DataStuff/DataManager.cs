using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataStuff
{
    public static class DataManager
    {

        private static string filetype = ".json";
        private static string folderName = "Presets";
        
        private static string ConvertDataToJsonString<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }


        private static T ConvertJsonStringToData<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }


        private static void UpdateDataFromeJsonString<T>(string json, T gameData)
        {
            JsonUtility.FromJsonOverwrite(json, gameData);
        }


        private static void WriteJsonStringToFile<T>(string json)
        {
            File.WriteAllText(Path.Combine(Application.dataPath,folderName,typeof(T).Name + filetype), json);
        }
        private static void WriteJsonStringToFile<T>(string additionFolder, string json)
        {
            File.WriteAllText(Path.Combine(Application.dataPath,folderName, additionFolder, typeof(T).Name + filetype), json);
        }
        private static string ReadJsonToString<T>()
        {
            return Resources.Load<TextAsset>(
                        Path.Combine(
                            folderName, typeof(T).Name + filetype)
                    ).text;
            //return File.ReadAllText(Path.Combine(Application.dataPath, typeof(T).Name + "filetype"));
        }


        public static T InitData<T>()
        {
            string json = ReadJsonToString<T>();
            return ConvertJsonStringToData<T>(json);
        }
        public static void UpdateData<T>(T wahtToUpdate)
        {
            string json = ReadJsonToString<T>();
            UpdateDataFromeJsonString(json, wahtToUpdate);
        }

        public static void SaveData<T>(T whatToSave)
        {
            string json = ConvertDataToJsonString(whatToSave);
            WriteJsonStringToFile<T>(json);
        }
        public static void SaveData<T>(string additionFolder, T whatToSave)
        {
            string json = ConvertDataToJsonString(whatToSave);
            WriteJsonStringToFile<T>(additionFolder, json);
        }
    }
}
