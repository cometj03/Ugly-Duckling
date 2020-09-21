using UnityEngine;

[System.Serializable]
public class SaveUserData : SaveData
{
    public override void Save(eSaveType saveType)
    {
        strSave = "";

        strSave += "money:" + PlayerData.Instance.MoneyProperty.Value;
        strSave += "/currentSkin:" + PlayerData.Instance.currentSkin;

        base.Save(saveType);
    }

    public override void Load(eSaveType saveType)
    {
        // 저장된 정보가 없으면 (처음 실행하면) 오류남
        if (!PlayerPrefs.HasKey(saveType.ToString()))
            return;    // 해결
        
        base.Load(saveType);

        PlayerData.Instance.MoneyProperty.Value = System.Convert.ToInt32(loadDataDictionary["money"]);
        PlayerData.Instance.currentSkin = loadDataDictionary["currentSkin"];
    }
}