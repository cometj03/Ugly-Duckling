using UnityEngine;

[System.Serializable]
public class SaveSettingData : SaveData
{
    public override void Save(eSaveType saveType)
    {
        strSave = "";

        strSave += "musicVol:" + PlayerData.Instance.musicVolume;
        strSave += "/sfxVol:" + PlayerData.Instance.sfxVolume;

        base.Save(saveType);
    }

    public override void Load(eSaveType saveType)
    {
        // 저장된 정보가 없으면 (처음 실행하면) 오류남
        if (!PlayerPrefs.HasKey(saveType.ToString()))
            return;    // 해결
            
        base.Load(saveType);

        PlayerData.Instance.musicVolume = System.Convert.ToSingle(loadDataDictionary["musicVol"]);
        PlayerData.Instance.sfxVolume = System.Convert.ToSingle(loadDataDictionary["sfxVol"]);
    }
}
