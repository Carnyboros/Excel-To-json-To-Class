using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Example : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        string text = File.ReadAllText(Application.dataPath + "/ExcelToClassParser/Demo/Json/CharacterInfo.json");
        Dictionary<string, CharacterInfo> charInfos = JsonToClass.DeserializeStringKeyDic<CharacterInfo>("Id", text);
        Dictionary<int, CharacterInfo> charInfosInt = JsonToClass.DeserializeIntKeyDic<CharacterInfo>("Power", text);
        foreach (KeyValuePair<string, CharacterInfo> pair in charInfos)
        {
            FieldInfo[] fields = pair.Value.GetType().GetFields();
            string infoStr = "";
            for (int i = 0; i < fields.Length; i++)
            {
                infoStr += fields[i] + " + ";
            }
            Debug.Log("Key: " + pair.Key + " Infos: " + infoStr);
        }
    }
}
public class CharacterInfo
{
    public string Id;
    public string Name;
    public string Race;
    public int Level;
    public int Power;
    public int Agility;
    public int Charisma;
    public int Intellect;
    public string[] PastTimes;
    public int[] Skills;
}