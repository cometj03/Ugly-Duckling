using System.Collections.Generic;
using UnityEngine;

public enum eSaveType
{
    eAll, eUser, eSetting
}

public class SaveData
{
    protected string strSave = "";
    protected string strLoad = "";

    protected Dictionary<string, string> loadDataDictionary = new Dictionary<string, string>();

    public virtual void Save(eSaveType saveType)
    {
        Debug.Log("Save : " + saveType);
        PlayerPrefs.SetString(saveType.ToString(), strSave);
    }

    public virtual void Load(eSaveType saveType)
    {
        // ex) nickname:닉네임/money:1000/currentSkin:2

        strLoad = PlayerPrefs.GetString(saveType.ToString());

        Debug.Log("Load : " + strLoad);

        string[] splitData = strLoad.Split('/');

        for(int i = 0; i < splitData.Length; i++)
        {
            string[] splitLoadData = splitData[i].Split(':');

            //Add Data Dictionary
            loadDataDictionary.Add(splitLoadData[0], splitLoadData[1]);
        }
    }
}