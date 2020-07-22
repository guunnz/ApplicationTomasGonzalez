using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UIData : MonoBehaviour
{
    private string jsonString;
    private string title;
    private string[] columns;
    private List<List<KeyValuePair<string, string>>> userDataList = new List<List<KeyValuePair<string, string>>>();

    public void DecodeJson()
    {
        userDataList = new List<List<KeyValuePair<string, string>>>();
        jsonString = File.ReadAllText(Application.dataPath + "/StreamingAssets/JsonChallenge.json");
        Data data = new Data();
        JObject jObject = JObject.Parse(jsonString);
        foreach (var item in jObject)
        {
            data.SetProperty(item.Key, item.Value);
        }
        title = data.fields.Values.ElementAt(0).ToString();
        columns = ((JArray)data.fields.Values.ElementAt(1)).ToObject<string[]>();
        JArray users = (JArray)data.fields.Values.ElementAt(2);
        foreach (JToken user in users)
        {
            List<KeyValuePair<string, string>> userData = new List<KeyValuePair<string, string>>();
            foreach (JProperty userProperty in user)
            {
                userData.Add(new KeyValuePair<string, string>(userProperty.Name, userProperty.Value.ToString()));
            }
            userDataList.Add(userData);
        }
    }

    public string GetTitle()
    {
        return title;
    }

    public string[] GetColumns()
    {
        return columns;
    }

    public List<List<KeyValuePair<string, string>>> GetUsersData()
    {
        return userDataList;
    }
}

public class Data
{
    private Type _type;
    public Data()
    {
        fields = new Dictionary<string, object>();
        _type = GetType();
    }
    public Dictionary<string, object> fields { get; set; }

    public void SetProperty(string key, object value)
    {
        var propertyInfo = _type.GetProperty(key);
        if (null == propertyInfo)
        {
            fields.Add(key, value);
            return;
        }
        propertyInfo.SetValue(this, value.ToString());
    }
}


