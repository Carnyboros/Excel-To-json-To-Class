using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using JsonFx.Json;

public class JsonToClass : MonoBehaviour
{

    public static T[] Deserialize<T>(string json)
    {
        T[] parsedClass = JsonReader.Deserialize<T[]>(json);
        return parsedClass;
    }
    public static Dictionary<string, T> DeserializeStringKeyDic<T>(string keyValue, string json)
    {
        //keyvalue 에 들어있는 실제 값을 키로 사용하여 dictionary에 넣는다. 중복될 경우가 없어야 한다.    
        T[] parsedClass = JsonReader.Deserialize<T[]>(json);
        Dictionary<string, T> dic = new Dictionary<string, T>();
        for (int i = 0; i < parsedClass.Length; i++)
        {
            object o = parsedClass[i].GetType().GetField(keyValue);
            if (o == null)
                o = parsedClass[i].GetType().GetProperty(keyValue).GetValue(parsedClass[i], null);
            else
                o = parsedClass[i].GetType().GetField(keyValue).GetValue(parsedClass[i]);
            string currKey = (string)o;
            if (dic.ContainsKey(currKey))
                Debug.LogError("Json Parsing Error: " + keyValue + "'s key ->" + currKey + " Already exist. Must use Different Key Value");
            dic.Add(currKey, parsedClass[i]);
        }
        return dic;
    }
    public static Dictionary<int, T> DeserializeIntKeyDic<T>(string keyValue, string json)
    {
        //keyvalue 에 들어있는 실제 값을 키로 사용하여 dictionary에 넣는다. 중복될 경우가 없어야 한다.        
        T[] parsedClass = JsonReader.Deserialize<T[]>(json);
        Dictionary<int, T> dic = new Dictionary<int, T>();
        for (int i = 0; i < parsedClass.Length; i++)
        {
            object o = parsedClass[i].GetType().GetField(keyValue);
            if (o == null)
                o = parsedClass[i].GetType().GetProperty(keyValue).GetValue(parsedClass[i], null);
            else
                o = parsedClass[i].GetType().GetField(keyValue).GetValue(parsedClass[i]);
            int currKey = (int)o;
            if (dic.ContainsKey(currKey))
                Debug.LogError("Json Parsing Error: " + keyValue + "'s key ->" + currKey + " Already exist. Must use Different Key Value");
            dic.Add(currKey, parsedClass[i]);
        }
        return dic;
    }

}
