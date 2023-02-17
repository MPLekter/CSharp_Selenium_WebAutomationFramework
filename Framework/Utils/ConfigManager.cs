using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1.Utils
{
    public class ConfigManager
    {
        public static string DriverType { get; set; }
        public static string Url { get; set; }

        public void ChooseUrl()
        {
            string config = LoadJSON("ConfigData");
            Dictionary<string, string> configDictionary = StringToDictionary(config);
            Url = configDictionary["Url"];
        }

        public static void ChooseBrowser()
        {
            string config = LoadJSON("ConfigData");
            Dictionary<string, string> configDictionary = StringToDictionary(config);
            DriverType = configDictionary["Browser"];
        }

        public static string LoadJSON(string fileName)
        {
            string savedData = File.ReadAllText($"../../../Data/{fileName}.json");
            return savedData;
        }

        public static object StringToListOfDictionaries(string data) //TODO: check if needed.
        {
            var dataList = new List<Dictionary<string, string>>();
            dataList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
            return dataList;
        }

        public static Dictionary<string, string> StringToDictionary(string data)
        {
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            return dict;
        }

        public Dictionary<string, string> PrepareAlertsTestData()
        {
            Dictionary<string, string> testData = new();
            string rawData;
            rawData = LoadJSON("TestData_Alerts");
            testData = StringToDictionary(rawData);

            return testData;
        }
        public Dictionary<string, string> PrepareTablesTestData()
        {
            Dictionary<string, string> testData = new();
            string rawData;
            rawData = LoadJSON("TestData_Tables");
            testData = StringToDictionary(rawData);

            return testData;
        }

    }
}
