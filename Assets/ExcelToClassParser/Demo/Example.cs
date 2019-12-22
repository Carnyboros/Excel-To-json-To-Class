using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.ComponentModel;

public class Example : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        string text = File.ReadAllText(Application.dataPath + "/ExcelToClassParser/Demo/Json/CharacterInfo.json");
        Dictionary<string, CharacterInfo> charInfos = JsonToClass.DeserializeStringKeyDic<CharacterInfo>("Id", text);
        Dictionary<int, CharacterInfo> charInfosInt = JsonToClass.DeserializeIntKeyDic<CharacterInfo>("Power", text);
        foreach (KeyValuePair<string, CharacterInfo> pair in charInfos)
        {
            string type = "";
            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(pair.Value))
            {
                type += descriptor.Name + ": ";
                var value = descriptor.GetValue(pair.Value);
                type += value.ToString() + ", ";
            }
            Debug.Log("Key: " + pair.Key + " Infos: " + type);
        }
    }
}
public class CharacterInfo
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Race { get; private set; }
    public int Level { get; private set; }
    public int Power { get; private set; }
    public int Agility { get; private set; }
    public float Charisma { get; private set; }
    public int Intellect { get; private set; }
    public string[] PastTimes { get; private set; }
    public int[] Skills { get; private set; }
}