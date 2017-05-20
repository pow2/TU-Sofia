using System;
using System.Text;
using Soul.Structures;
using Windows.Data.Json;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Soul.Controller
{
    public class JsonController
    {
        //-----------------------------------------------------------------------------------------------
        public static string CheckIfActiveToJson(CheckIfActiveStructure str)
        {
            JsonObject CheckIfActiveJsonObject = new JsonObject();
            CheckIfActiveJsonObject.SetNamedValue("number", JsonValue.CreateStringValue(str.Number));
            CheckIfActiveJsonObject.SetNamedValue("name", JsonValue.CreateStringValue(str.Name));
            CheckIfActiveJsonObject.SetNamedValue("date", JsonValue.CreateStringValue(str.Date));
            CheckIfActiveJsonObject.SetNamedValue("status", JsonValue.CreateStringValue(str.Status));
            return CheckIfActiveJsonObject.ToString();
        }
        //-----------------------------------------------------------------------------------------------
        public static CheckIfActiveStructure JsonToCheckIfActive(string json)
        {
            CheckIfActiveStructure str = new CheckIfActiveStructure();
            JsonObject CheckIfActiveJsonObject = JsonObject.Parse(json);
            str.Number = CheckIfActiveJsonObject.GetNamedString("number", String.Empty);
            str.Name = CheckIfActiveJsonObject.GetNamedString("name", String.Empty);
            str.Date = CheckIfActiveJsonObject.GetNamedString("date", String.Empty);
            str.Status = CheckIfActiveJsonObject.GetNamedString("status", String.Empty);
            return str;
        }
        //-----------------------------------------------------------------------------------------------
        public static string AppIdToJson(AppIdStructure str)
        {
            JsonObject CheckIfActiveJsonObject = new JsonObject();
            CheckIfActiveJsonObject.SetNamedValue("appId", JsonValue.CreateStringValue(str.AppId));
            CheckIfActiveJsonObject.SetNamedValue("status", JsonValue.CreateStringValue(str.Status));
            return CheckIfActiveJsonObject.ToString();
        }
        //-----------------------------------------------------------------------------------------------
        public static AppIdStructure JsonToAppId(string json)
        {
            AppIdStructure str = new AppIdStructure();
            JsonObject CheckIfActiveJsonObject = JsonObject.Parse(json);
            str.AppId = CheckIfActiveJsonObject.GetNamedString("appId", String.Empty);
            str.Status = CheckIfActiveJsonObject.GetNamedString("status", String.Empty);
            return str;
        }
        //-----------------------------------------------------------------------------------------------
        public static string CalculateToJson(CalcStructure str)
        {
            JsonObject CalcJsonObject = new JsonObject();
            CalcJsonObject.SetNamedValue("city", JsonValue.CreateStringValue(str.City));
            CalcJsonObject.SetNamedValue("vehicle", JsonValue.CreateStringValue(str.Vehicle));
            CalcJsonObject.SetNamedValue("capacity", JsonValue.CreateStringValue(str.Capacity));
            CalcJsonObject.SetNamedValue("sum", JsonValue.CreateStringValue(str.Sum));
            CalcJsonObject.SetNamedValue("status", JsonValue.CreateStringValue(str.Status));
            return CalcJsonObject.ToString();
        }
        //-----------------------------------------------------------------------------------------------
        public static CalcStructure JsonToCalculate(string json)
        {
            CalcStructure str = new CalcStructure();
            JsonObject CheckIfActiveJsonObject = JsonObject.Parse(json);
            str.City = CheckIfActiveJsonObject.GetNamedString("city", String.Empty);
            str.Vehicle = CheckIfActiveJsonObject.GetNamedString("vehicle", String.Empty);
            str.Capacity = CheckIfActiveJsonObject.GetNamedString("capacity", String.Empty);
            str.Sum = CheckIfActiveJsonObject.GetNamedString("sum", String.Empty);
            str.Status = CheckIfActiveJsonObject.GetNamedString("status", String.Empty);
            return str;
        }
        //-----------------------------------------------------------------------------------------------
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Dispose();
            return jsonString;
        }
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
        //-----------------------------------------------------------------------------------------------
    }
}
