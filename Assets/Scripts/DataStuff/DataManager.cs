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
        private static AllGameDataPresets gameData;

        private static string fileName = "AllDataPresets.json";
        private static string fileName1 = "AllDataPresets";

        private static string ConvertDataToJsonString(AllGameDataPresets gameData)
        {
            Debug.Log("game data to json " + JsonUtility.ToJson(gameData));
            return JsonUtility.ToJson(gameData);
        }
        private static string ConvertDataToJsonString()
        {
            return ConvertDataToJsonString(gameData);
        }


        private static void ConvertJsonStringToData(string json)
        {
            gameData = JsonUtility.FromJson<AllGameDataPresets>(json);
        }

        public static AllGameDataPresets GetData()
        {
            return gameData;
        }

        private static void UpdateDataFromeJsonString(string json, AllGameDataPresets gameData)
        {
            JsonUtility.FromJsonOverwrite(json, gameData);
        }


        private static void WriteJsonStringToFile(string json)
        {
            File.WriteAllText(Path.Combine(Application.dataPath,fileName), json);
        }
        private static string ReadJsonToString()
        {
            return Resources.Load<TextAsset>(fileName1)?.text;
            //return File.ReadAllText(Path.Combine(Application.dataPath, fileName));
        }


        public static void InitData()
        {
            string json = ReadJsonToString();
            ConvertJsonStringToData(json);
        }
        public static void UpdateData()
        {
            string json = ReadJsonToString();
            UpdateDataFromeJsonString(json, gameData);
        }

        public static void LoadData()
        {
            if(gameData == null)
            {
                InitData();
            }
            else
            {
                UpdateData();
            }
        }
        public static void SaveData()
        {
            string json = ConvertDataToJsonString();
            WriteJsonStringToFile(json);
        }
        public static void SaveData(AllGameDataPresets gd)
        {
            string json = ConvertDataToJsonString(gd);
            WriteJsonStringToFile(json);
        }
    }
}
