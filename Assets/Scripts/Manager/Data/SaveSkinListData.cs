using SimpleJSON;
using UnityEngine;

[System.Serializable]
public class SaveSkinListData : SaveData
{
    private string path = "/Datas/Skins.json";

    public override void Save(eSaveType saveType)
    {
        strSave = "";
        
        JSONNode data;

        BetterStreamingAssets.Initialize();
        data = JSON.Parse(BetterStreamingAssets.ReadAllText(path));

        foreach(var iter in data){
            strSave += iter.Value["skinName"] + ":";

			if (PlayerData.Instance.skinList.ContainsKey(iter.Value["skinName"]))
			{
                strSave += PlayerData.Instance.skinList[iter.Value["skinName"]].ToString();
			}
			else
			{
                strSave += false.ToString();
			}

            strSave += "/";
		}

        strSave = strSave.Remove(strSave.Length - 1);

        base.Save(saveType);
    }

    public override void Load(eSaveType saveType)
    {
        // 저장된 정보가 없으면 (처음 실행하면) 오류남
        if (!PlayerPrefs.HasKey(saveType.ToString()))
            return;    // 해결

        base.Load(saveType);

        foreach(var iter in loadDataDictionary)
		{
            PlayerData.Instance.skinList.Add(iter.Key, bool.Parse(iter.Value));
		}
    }
}