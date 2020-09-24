using UnityEngine;

[System.Serializable]
public class SaveSkinListData : SaveData
{
    public override void Save(eSaveType saveType)
    {
        strSave = "";

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